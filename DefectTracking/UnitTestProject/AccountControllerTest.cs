using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class AccountControllerTest
    {
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        LoginViewModel _loginViewModel;
        [Fact]
        public void GetLoginTest()
        {
            //Arrange
            AccountController controller = new AccountController(_userManager, _signInManager);
            //Act
            ViewResult result = (ViewResult)controller.LogIn();
            //Assert
            Assert.Null(result.ViewName);
        }

        [Fact]
        public async Task PostLoginTest()
        {
            //Act
            AccountController controller = new AccountController(_userManager, _signInManager);
            _loginViewModel = new LoginViewModel
            {
                Username = "admin",
                Password = "Sesame123#",
                RememberMe = false
            };
            //Act
            ViewResult checkLogin = (ViewResult) await controller.LogIn(_loginViewModel);
            //Assert
            Assert.Null(checkLogin.ViewName);

        }

    }
}
