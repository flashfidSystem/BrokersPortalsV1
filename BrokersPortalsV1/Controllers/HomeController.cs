using BrokersPortalsV1.Enum;
using BrokersPortalsV1.Models;
using BrokersPortalsV1.Security.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BrokersPortalsV1.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Unauthorised()
        { 
            return View();
        } 

    }
}