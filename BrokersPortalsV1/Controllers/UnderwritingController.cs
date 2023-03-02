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
        public IActionResult MotorForm()
        {

            return View();
        }
        [HttpPost]
        public IActionResult MotorForm(int id)
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
        public IActionResult Products()
        {
            return View();
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
