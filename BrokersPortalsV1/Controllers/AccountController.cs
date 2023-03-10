using BrokersPortalsV1.Class;
using BrokersPortalsV1.Enum;
using BrokersPortalsV1.Models;
using BrokersPortalsV1.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace BrokersPortalsV1.Controllers
{

    public class AccountController : BaseController
    {
        private readonly ISessionHandler _SessionHandler; 
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountController(ISessionHandler sessionHandler,  IHttpClientFactory httpClientFactory)
        {
            _SessionHandler = sessionHandler; 
            _httpClientFactory = httpClientFactory;
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login 
        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = userLoginView.UserId + ":" + userLoginView.Password;
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7244/api/Users/authenticate");

                    var UserbyteArray = Encoding.UTF8.GetBytes(user);
                    var User64 = Convert.ToBase64String(UserbyteArray);

                    var jsonContent = JsonConvert.SerializeObject(new AuthenticarRequest() { companyId = userLoginView.companyId, loginCredential = User64 });
                    request.Content = new StringContent(jsonContent);
                    request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var byteArray = Encoding.UTF8.GetBytes("Brokers.Portal.Frontend:bp4321");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var users = await response.Content.ReadAsStringAsync();
                        var userde = JsonConvert.DeserializeObject<AuthenticarResponse>(users);

                        var request2 = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7244/api/Users/getprofile?userId={userde.data.userId}");

                        var client2 = _httpClientFactory.CreateClient();
                        client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                        var response2 = await client2.SendAsync(request2);
                        if (response2.IsSuccessStatusCode)
                        {
                            var userProfile = await response2.Content.ReadAsStringAsync();
                            var userProfileResponse = JsonConvert.DeserializeObject<ProfileResponse>(userProfile);
                            _SessionHandler.setSession(SessionVariable.LOGGEDUSER, userProfileResponse);

                            Notify("Login successfully");
                            return RedirectToAction("CompanyDashboard", "Dashboard");
                        }
                        else
                        {
                            Notify("Could not get user profile", notificationType: NotificationType.error);
                            return View();
                        }
                    }
                    else
                    {
                        Notify("Invalid Credentials", notificationType: NotificationType.error);
                        return View();
                    }
                }
                catch
                {
                    Notify("Could not get user profile", notificationType: NotificationType.error);
                    return View(userLoginView);
                }

            }
            else
            {
                return View(userLoginView);
            }
             
        }

        //Log me out
        [HttpGet]
        public IActionResult LogOut()
        {
            _SessionHandler.setLogOut();
            return RedirectToAction("Login", "Account");
        }


    }
}
