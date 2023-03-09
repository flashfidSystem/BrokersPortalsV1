using BrokersPortalsV1.Class;
using BrokersPortalsV1.Security.Filter;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using BrokersPortalsV1.Session;
using BrokersPortalsV1.Models;
using BrokersPortalsV1.Enum;
using static BrokersPortalsV1.Models.PackageViewModel;
using System.Text;

namespace BrokersPortalsV1.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticationFilter))]
    public class UnderwritingController : BaseController
    { 
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISessionHandler _SessionHandler;
        public UnderwritingController(IHttpClientFactory httpClientFactory, ISessionHandler sessionHandler)
        {
            _httpClientFactory = httpClientFactory;
            _SessionHandler = sessionHandler;
        }
        [HttpGet]
        public IActionResult SalesQuote()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult SalesQuote(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult PolicyProposal()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult PolicyProposal(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreditNote()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult CreditNote(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Customers()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult Customers(int id)
        {
            return View();
        }


        //forms
        [HttpGet]
        public IActionResult GenerateQuote()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GenerateQuote(int id)
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult>  MotorForm(int packageId)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7244/api/Products/getpackages?productId={packageId}");

                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var byteArray = System.Text.Encoding.UTF8.GetBytes("Brokers.Portal.Frontend:bp4321");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = await client.SendAsync(request);
                PackageViewModel.Package PackageResponse = null;
                if (response.IsSuccessStatusCode)
                {
                    var Product = await response.Content.ReadAsStringAsync();
                    PackageResponse = JsonConvert.DeserializeObject<PackageViewModel.Package>(Product);
                    ViewBag.Packages = PackageResponse.data;
                }
                else
                {
                    Notify("Could not get packages", notificationType: NotificationType.error);
                }


                return View();
            }
            catch
            {
                Notify("Something went wrong", notificationType: NotificationType.error);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult>  MotorForm(Motor motor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7244/api/Products/getpackages?productId={motor.packageId}");

                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var byteArray = System.Text.Encoding.UTF8.GetBytes("Brokers.Portal.Frontend:bp4321");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var response = await client.SendAsync(request);
                    PackageViewModel.Package PackageResponse = null;
                    if (response.IsSuccessStatusCode)
                    {
                        var Product = await response.Content.ReadAsStringAsync();
                        PackageResponse = JsonConvert.DeserializeObject<PackageViewModel.Package>(Product);
                        ViewBag.Packages = PackageResponse.data;
                    }
                    else
                    {
                        Notify("Could not get packages", notificationType: NotificationType.error);
                        return RedirectToAction("Products");
                    }
                     
                    var request2 = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7244/api/Underwriting/submitrequestformotor");
                    var getUserID = _SessionHandler.getSession<ProfileResponse>(SessionVariable.LOGGEDUSER);
                    var jsonContent = JsonConvert.SerializeObject(new Motor() {
                        brokerId = getUserID.data.userData.userId, 
                        productName = motor.productName,
                        typeOfCover= motor.typeOfCover,
                        insuredName= motor.insuredName,
                        occupation= motor.occupation,
                        emailAddress= motor.emailAddress,
                        vehicleMake= motor.vehicleMake,
                        yearOfMake= motor.yearOfMake,
                        insuranceStartDate= motor.insuranceStartDate,
                        vehicleValue= motor.vehicleValue,
                        startDate= motor.startDate,
                        insuredValue= motor.insuredValue,
                        modeOfPayment= motor.modeOfPayment,
                        policyHolder = motor.policyHolder,  
                        mobile=motor.mobile,
                        address= motor.address,
                        typeOfUsage= motor.typeOfUsage,
                        registrationNumber= motor.registrationNumber,
                        premiumRate= motor.premiumRate,
                        coverPeriod= motor.coverPeriod,
                        transactionDate= motor.transactionDate,
                        premium= motor.premium,
                        idUploadUrl= motor.idUploadUrl,
                        utilityBillUploadUrl= motor.utilityBillUploadUrl,
                        vehicleLicenseUploadUrl= motor.vehicleLicenseUploadUrl,
                        

                    });
                    request2.Content = new StringContent(jsonContent);
                    request2.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                    var client2 = _httpClientFactory.CreateClient();
                    client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var byteArray2 = Encoding.UTF8.GetBytes("Brokers.Portal.Frontend:bp4321");
                    client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray2));

                    var response2 = await client.SendAsync(request2);

                    if (response2.IsSuccessStatusCode)
                    {
                        var submitRequest = await response2.Content.ReadAsStringAsync();
                        var userde = JsonConvert.DeserializeObject<MotorResponse.Root>(submitRequest);
                        Notify("Request submitted successfully");
                        ModelState.Clear();
                        return View();
                    }
                    else{
                        Notify("Something went wrong", notificationType: NotificationType.error);
                        return View(motor);
                    } 
                }
                catch
                {
                    Notify("Something went wrong", notificationType: NotificationType.error);
                    return View(motor);
                }
            }
            else
            {
                Notify("Some fields are required.", notificationType: NotificationType.error);
                return View(motor);
            } 
        }
        [HttpGet]
        public IActionResult FleetMotorForm()
        {

            return View();
        }
        [HttpPost]
        public IActionResult FleetMotorForm(int id)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
        [HttpGet]
        public IActionResult HouseHolder()
        {

            return View();
        }
        [HttpPost]
        public IActionResult HouseHolder(int id)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
        [HttpGet]
        public IActionResult TravelAgent()
        {

            return View();
        }
        [HttpPost]
        public IActionResult TravelAgent(int id)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
        [HttpGet]
        public IActionResult ViewQuotes()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ViewQuotes(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult ConvertQuote()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ConvertQuote(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Test(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7244/api/Products/getallproducts");

                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var byteArray = System.Text.Encoding.UTF8.GetBytes("Brokers.Portal.Frontend:bp4321");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = await client.SendAsync(request);
                ProductViewModel.Product ProductResponse = null;
                if (response.IsSuccessStatusCode)
                {
                    var Product = await response.Content.ReadAsStringAsync();
                    ProductResponse = JsonConvert.DeserializeObject<ProductViewModel.Product>(Product);
 
                }
                return View(ProductResponse);
            }
            catch
            {
                Notify("Something went wrong", notificationType: NotificationType.error);
                return View();
            }
             
        }
        [HttpPost]
        public IActionResult Products(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Packages()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Packages(int id)
        {
            return View();
        }
    }
}
