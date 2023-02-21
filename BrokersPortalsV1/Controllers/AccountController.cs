using BrokersPortalsV1.Class;
using BrokersPortalsV1.Models; 
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BrokersPortalsV1.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly ISessionHandler _SessionHandler;
        private readonly IUserPermission _UserPermissionTo;

        public AccountController(ISessionHandler sessionHandler, IUserPermission userPermissionTo)
        {
            _SessionHandler = sessionHandler;
            _UserPermissionTo = userPermissionTo;
        }
      
        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login 
        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLoginViewModel userLoginView)
        {
            if (ModelState.IsValid)
            {

                using (StreamReader r = new StreamReader("UserPayload.json"))
                {
                    if (userLoginView.CompanyId == "cli1234" && userLoginView.UserId == "get@james.com" && userLoginView.Password == "welcome")
                    {
                        string json = r.ReadToEnd();
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);
                         
                        _SessionHandler.setSession(SessionVariable.LOGGEDUSER, myDeserializedClass);
                      
                        _UserPermissionTo.initialize();
                        return RedirectToAction("CompanyDashboard", "Dashboard");
                    }
                    else
                    {
                        TempData["Error"] = "Invalid Credentials";
                        return View();
                    }
                   
                }
                //string endpoint = $"endpont";
                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri("baseUrl");
                //    client.DefaultRequestHeaders.Accept.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");

                //    var response = await client.GetAsync(endpoint);
                //    if (response.IsSuccessStatusCode)
                //    {
                //        string content = await response.Content.ReadAsStringAsync();
                //        return View();
                //    }
                //    else
                //    {
                //        string content = await response.Content.ReadAsStringAsync();
                //        return View();
                //    }
                //} 

            }

            return View();

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
