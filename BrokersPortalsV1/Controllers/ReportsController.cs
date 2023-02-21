using BrokersPortalsV1.Security.Filter;
using Microsoft.AspNetCore.Mvc;

namespace BrokersPortalsV1.Controllers
{
    //[ServiceFilter(typeof(CustomAuthenticationFilter))]
    public class ReportsController : Controller
    {
        [HttpGet]
        public IActionResult ClaimsReports()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ClaimsReports(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult SubmittedProductReports()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmittedProductReports(int id)
        {
            return View();
        }
    }
}
