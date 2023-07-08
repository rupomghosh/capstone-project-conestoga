using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DefectTracking.Models;
using DefectTracking.Data;


namespace DefectTracking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly DefectTrackingContext context;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        public UserController(UserManager<User> userMngr, RoleManager<IdentityRole> roleMngr, DefectTrackingContext _context)
        {
            userManager = userMngr;
            roleManager = roleMngr;
            context = _context;
        }

        ///<summary>
        /// Displays all users registered in the database
        ///</summary>
        public async Task<IActionResult> Index()
        {
            List<User> users = new List<User>();
            foreach (User user in userManager.Users)
            {
                users.Add(user);
            }

            UserViewModel model = new UserViewModel
            {
                Users = users,
            };
            return View(model);
        }
        /// <summary>
        /// Goes to register admin page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }
        /// <summary>
        /// Adds user to the database and gives them the role admin
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username };
                var checkForDuplicate = await userManager.FindByNameAsync(model.Username);
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded && checkForDuplicate == null)
                {
                    var roleName = "Admin";
                    await userManager.AddToRoleAsync(user, roleName);
                    return RedirectToAction("RegisterAdmin");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        /// <summary>
        /// Goes to register employee page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RegisterEmployee()
        {
            return View();
        }
        /// <summary>
        /// Adds user to the database and gives them the role employee
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> RegisterEmployee(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username };
                var checkForDuplicate = await userManager.FindByNameAsync(model.Username);
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded && checkForDuplicate == null)
                {
                    var roleName = "Employee";
                    await userManager.AddToRoleAsync(user, roleName);
                    return RedirectToAction("RegisterEmployee");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// Goes to register supplier page
        /// </summary>
        [HttpGet]
        public IActionResult RegisterSupplier()
        {
            return View();
        }

        /// <summary>
        /// Adds user to the database and gives them the role supplier
        /// </summary>
        
        [HttpPost]
        public async Task<IActionResult> RegisterSupplier(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username };
                var checkForDuplicate = await userManager.FindByNameAsync(model.Username);
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded && checkForDuplicate == null)
                {
                    var roleName = "Supplier";
                    await userManager.AddToRoleAsync(user, roleName);
                    return RedirectToAction("RegisterSupplier");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// Deletes User from Database
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (!result.Succeeded)
                { // if failed
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }
                    TempData["message"] = errorMessage;
                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult AccessDenied()
        {
            return View();
        }

        
    }
}
