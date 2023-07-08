namespace UnitTestProject
{
    public class HomeControllerTest
    {
        [Fact]
        public void TestIndex()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            ViewResult result = (ViewResult)controller.Index();
            //Assert
            Assert.Equal("Index", result.ViewName);

        }

        [Fact]
        public void TestAccessDenied() 
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            ViewResult result = (ViewResult)controller.AccessDenied();
            //Assert
            Assert.Equal("AccessDenied", result.ViewName);
        }
    }
}