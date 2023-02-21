using BrokersPortalsV1.Security.Filter;
using Microsoft.AspNetCore.Mvc;

namespace BrokersPortalsV1.Controllers
{
    //[ServiceFilter(typeof(CustomAuthenticationFilter))]
    public class DashboardController : Controller
    {
        [HttpGet]
        //[CustomAuthorisationFilter(FormsSubModule.CompanyDashboard,UserActionType.canView)]
        public IActionResult CompanyDashboard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CompanyDashboard(int id)
        {
            return View();
        }
        [HttpGet]
        //[CustomAuthorisationFilter(FormsSubModule.CompanyDashboard,UserActionType.canView)]
        public IActionResult SetupFleet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetupFleet(int id)
        {
            return View();
        }
        [HttpGet]
        //[CustomAuthorisationFilter(FormsSubModule.CompanyDashboard,UserActionType.canView)]
        public IActionResult SetupBranch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetupBranch(int id)
        {
            return View();
        }

    }
}
