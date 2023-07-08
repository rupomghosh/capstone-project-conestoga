using DefectTracking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTestProject
{
    public class FormControllerTest
    {

        DefectTrackingContext _context;
        DeliveryDefectsViewModel delivery;
        ManufacturingDefectsViewModel manufacturing;
        WarrantyDefectsViewModel warranty;

		[Fact]
        public void TestGetManufacturingForm()
        {
            //Arrange
			DefectTrackingContext _trackingContext = new DefectTrackingContext();
            FormsController controller = new FormsController(_trackingContext);

			//Act
			ViewResult result = (ViewResult)controller.ManufacturingForm();
            //Assert
            Assert.Equal("ManufacturingForm", result.ViewName);
        }

        [Fact]
        public void TestGetDeliveryForm()
        {
			//Arrange
			DefectTrackingContext _trackingContext = new DefectTrackingContext();
			FormsController controller = new FormsController(_trackingContext);

			//Act
			ViewResult result = (ViewResult)controller.DeliveryForm();
            //Assert
            Assert.Equal("DeliveryForm", result.ViewName);
        }


        [Fact]
        public void TestGetWarrantyForm()
        {
			//Arrange
			DefectTrackingContext _trackingContext = new DefectTrackingContext();
			FormsController controller = new FormsController(_trackingContext);
			//Act
			ViewResult result = (ViewResult)controller.WarrantyForm();
            //Assert
            Assert.Equal("WarrantyForm", result.ViewName);
        }
		[Fact]
		public void TestPostManufacturingForm_WhenModelStateIsInValid()
		{
			//Arrange
			var mockDatabase = new Mock<DefectTrackingContext>();
			var controller = new FormsController(mockDatabase.Object);
			controller.ModelState.AddModelError("Serial Number", "Serial Number Already Exists");
			var newRecord = new ManufacturingDefectsViewModel();
			//Act
			var result = controller.ManufacturingForm(newRecord);
			//Assert
			var badRecordResult = Assert.IsType<ViewResult>(result);
			Assert.Null(badRecordResult.ViewName);
		}

		[Fact]
		public void TestPostDeliveryForm_WhenModelStateIsInValid()
		{
			//Arrange
			var mockDatabase = new Mock<DefectTrackingContext>();
			var controller = new FormsController(mockDatabase.Object);
			controller.ModelState.AddModelError("Serial Number", "Serial Number Already Exists");
			var newRecord = new DeliveryDefectsViewModel();
			//Act
			var result = controller.DeliveryForm(newRecord);
			//Assert
			var badRecordResult = Assert.IsType<ViewResult>(result);
			Assert.Null(badRecordResult.ViewName);
		}

		[Fact]
		public void TestPostWarrantyForm_WhenModelStateIsInValid()
		{
			//Arrange
			var mockDatabase = new Mock<DefectTrackingContext>();
			var controller = new FormsController(mockDatabase.Object);
			controller.ModelState.AddModelError("Serial Number", "Serial Number Already Exists");
			var newRecord = new WarrantyDefectsViewModel();
			//Act
			var result = controller.WarrantyForm(newRecord);
			//Assert
			var badRecordResult = Assert.IsType<ViewResult>(result);
			Assert.Null(badRecordResult.ViewName);
		}

		[Fact]
        public void TestPostManufacturingForm_WhenModelStateIsValid()
        {
			//Arrange
			var mockDatabase = new Mock<DefectTrackingContext>();
            var controller = new FormsController(mockDatabase.Object);
            var newRecord = new ManufacturingDefectsViewModel()
            {
				serialNumber = 1001,
				unitType = "Pro II",
				display = false,
				calibrationMissingCalibration = false,
				mechanicalAssemblyError = true,
				deadorDyingBatteries = true,
				pCBBoardDefect = true,
				other = false,
				otherDesc = "",
				problemDesc = "Testing Post Manufacturing"
			};
            //Act
            var result = controller.ManufacturingForm(newRecord);
            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("ManufacturingForm", redirectToActionResult.ActionName);
            mockDatabase.Verify();
        }

        [Fact]
        public void TestPostDeliveryForm_WhenModelStateIsValid()
        {
			//Arrange
			var mockDatabase = new Mock<DefectTrackingContext>();
			var controller = new FormsController(mockDatabase.Object);
			var newRecord = new DeliveryDefectsViewModel()
			{
				serialNumber = 1010,
				unitType = "Pro II",
				display = false,
				calibrationMissingCalibration = false,
				mechanicalAssemblyError = true,
				deadorDyingBatteries = true,
				pCBBoardDefect = true,
				other = false,
				otherDesc = "",
				problemDesc = "Testing Post Delivery"
			};
			//Act
			var result = controller.DeliveryForm(newRecord);
			//Assert
			var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
			Assert.Null(redirectToActionResult.ControllerName);
			Assert.Equal("DeliveryForm", redirectToActionResult.ActionName);
			mockDatabase.Verify();

		}

        [Fact]
        public void TestPostWarrantyForm_WhenModelStateIsValid()
        {
			//Arrange
			var mockDatabase = new Mock<DefectTrackingContext>();
			var controller = new FormsController(mockDatabase.Object);
			var newRecord = new WarrantyDefectsViewModel()
			{
				serialNumber = 13105,
				unitType = "Pro II",
				display = false,
				calibrationMissingCalibration = false,
				mechanicalAssemblyError = true,
				deadorDyingBatteries = true,
				pCBBoardDefect = true,
				other = false,
				otherDesc = "",
				problemDesc = "Testing Post Warranty"
			};
			//Act
			var result = controller.WarrantyForm(newRecord);
			//Assert
			var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
			Assert.Null(redirectToActionResult.ControllerName);
			Assert.Equal("WarrantyForm", redirectToActionResult.ActionName);
			mockDatabase.Verify();
		}
	}

}
