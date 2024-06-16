using Microsoft.AspNetCore.Mvc;
using MVC_Test.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_Test.Controllers
{
    public class ERP : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            LoginViewModel model = new LoginViewModel()
            {
                AccountID = Request.Form["inputAccount"],
                Password  = Request.Form["inputPassword"],
                EMail     = Request.Form["inputEmail"],
                Country   = Request.Form["inputCountry"],
                Address   = Request.Form["inputAddress"]
            };

            return View(model);
        }
    }
}