using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
	public class ReportControllerTest
	{
		[Fact]
		public void WarrantyReportSummaryTest()
		{
			//Arrange
			DefectTrackingContext context = new DefectTrackingContext();
			ReportController controller = new ReportController(context);
			//Act
			ViewResult result = (ViewResult)controller.WarrantyReportSummary();
			//Assert
			Assert.Equal("WarrantyReportSummary", result.ViewName);
		}
		[Fact]
		public void ManufacturingReportSummaryTest()
		{
			//Arrange
			DefectTrackingContext context = new DefectTrackingContext();
			ReportController controller = new ReportController(context);
			//Act
			ViewResult result = (ViewResult)controller.ManufacturingReportSummary();
			//Assert
			Assert.Equal("ManufacturingReportSummary", result.ViewName);
		}
		[Fact]
		public void DeliveryReportSummaryTest()
		{
			//Arrange
			DefectTrackingContext context = new DefectTrackingContext();
			ReportController controller = new ReportController(context);
			//Act
			ViewResult result = (ViewResult)controller.DeliveryReportSummary();
			//Assert
			Assert.Equal("DeliveryReportSummary", result.ViewName);
		}
	}
}
