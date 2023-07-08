using DefectTracking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DefectTracking.Controllers
{
    
    [Authorize(Roles = "Admin, Employee, Supplier")]
    public class HomeController : Controller
    {
        /// <summary>
        /// This is the homepage
        /// </summary>
        public IActionResult Index()
        {
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ViewResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}