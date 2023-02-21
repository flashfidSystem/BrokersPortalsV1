using BrokersPortalsV1.Security.Filter;
using Microsoft.AspNetCore.Mvc;

namespace BrokersPortalsV1.Controllers
{
    //[ServiceFilter(typeof(CustomAuthenticationFilter))]
    public class ClaimController : Controller
    {
        [HttpGet]
        public IActionResult ManageClaims()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ManageClaims(int Id)
        {

            return View();
        }
        [HttpGet]
        public IActionResult ManagePayment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ManagePayment(int Id)
        {

            return View();
        }
        [HttpGet]
        public IActionResult ClaimsReport()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ClaimsReport(int Id)
        {

            return View();
        }
    }
}
