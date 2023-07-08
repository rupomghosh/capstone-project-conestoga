using DefectTracking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DefectTracking.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(UserManager<User> userMngr, SignInManager<User> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
        }

        /// <summary>
        /// Logs the user out of their account and takes them back to the login page
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn", "Account");
        }

        //This is the main Login Page
        [HttpGet]
        public ActionResult LogIn()
        {
            
            return View();
        }

        /// <summary>
        /// Sends a request to the database to check if the username and password are correct
        /// Then sends them to the homepage
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(model.Username, model.Password,
                                isPersistent: model.RememberMe = false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid Login Attempt.");
                return View(model);
            }catch(Exception ex)
            {
                ViewBag.Exception = ex;
            }
            return View();
        }

        public ViewResult AccessDenied()
        {
            return View();
        }

        private UserManager<User> userManager;
        private SignInManager<User> signInManager;


    }
}
