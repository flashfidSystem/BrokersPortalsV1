using BrokersPortalsV1.Security.Filter;
using Microsoft.AspNetCore.Mvc;

namespace BrokersPortalsV1.Controllers
{
    //[ServiceFilter(typeof(CustomAuthenticationFilter))]
    public class UnderwritingController : Controller
    {
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


        //forms
        [HttpGet]
        public IActionResult GenerateQoute()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GenerateQoute(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult ViewQoutes()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ViewQoutes(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult ConvertQoutes()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ConvertQoutes(int id)
        {
            return View();
        }
    }
}
