using Microsoft.AspNetCore.Mvc;


namespace UnitTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestHomeIndex()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            ViewResult result = (ViewResult)controller.Index();
            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
