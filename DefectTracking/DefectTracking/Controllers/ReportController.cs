using DefectTracking.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefectTracking.Controllers
{
	[Authorize(Roles = "Admin, Supplier")]
    public class ReportController : Controller
    {
        private readonly DefectTrackingContext _context;
        public ReportController(DefectTrackingContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult ManufacturingReportSummary()
        {
			try
			{
				var displayCountC = _context.ManufacturingDefects.Where(x => x.UnitType == "Classic II" && x.Display == 1).ToList().Count();
				var calCountC = _context.ManufacturingDefects.Where(x => x.UnitType == "Classic II" && x.CalibrationMissingCalibration == 1).ToList().Count();
				var mechCountC = _context.ManufacturingDefects.Where(x => x.UnitType == "Classic II" && x.MechanicalAssemblyError == 1).ToList().Count();
				var deadCountC = _context.ManufacturingDefects.Where(x => x.UnitType == "Classic II" && x.DeadorDyingBatteries == 1).ToList().Count();
				var pcbCountC = _context.ManufacturingDefects.Where(x => x.UnitType == "Classic II" && x.PCBBoardDefect == 1).ToList().Count();
				var otherCountC = _context.ManufacturingDefects.Where(x => x.UnitType == "Classic II" && x.Other == 1).ToList().Count();
				var displayCountM = _context.ManufacturingDefects.Where(x => x.UnitType == "Micro" && x.Display == 1).ToList().Count();
				var calCountM = _context.ManufacturingDefects.Where(x => x.UnitType == "Micro" && x.CalibrationMissingCalibration == 1).ToList().Count();
				var mechCountM = _context.ManufacturingDefects.Where(x => x.UnitType == "Micro" && x.MechanicalAssemblyError == 1).ToList().Count();
				var deadCountM = _context.ManufacturingDefects.Where(x => x.UnitType == "Micro" && x.DeadorDyingBatteries == 1).ToList().Count();
				var pcbCountM = _context.ManufacturingDefects.Where(x => x.UnitType == "Micro" && x.PCBBoardDefect == 1).ToList().Count();
				var otherCountM = _context.ManufacturingDefects.Where(x => x.UnitType == "Micro" && x.Other == 1).ToList().Count();
				var displayCountP = _context.ManufacturingDefects.Where(x => x.UnitType == "Pro II" && x.Display == 1).ToList().Count();
				var calCountP = _context.ManufacturingDefects.Where(x => x.UnitType == "Pro II" && x.CalibrationMissingCalibration == 1).ToList().Count();
				var mechCountP = _context.ManufacturingDefects.Where(x => x.UnitType == "Pro II" && x.MechanicalAssemblyError == 1).ToList().Count();
				var deadCountP = _context.ManufacturingDefects.Where(x => x.UnitType == "Pro II" && x.DeadorDyingBatteries == 1).ToList().Count();
				var pcbCountP = _context.ManufacturingDefects.Where(x => x.UnitType == "Pro II" && x.PCBBoardDefect == 1).ToList().Count();
				var otherCountP = _context.ManufacturingDefects.Where(x => x.UnitType == "Pro II" && x.Other == 1).ToList().Count();
				var totalCountM = _context.ManufacturingDefects.Where(x => x.UnitType == "Micro").ToList().Count();
				var totalCountC = _context.ManufacturingDefects.Where(x => x.UnitType == "Classic II").ToList().Count();
				var totalCountP = _context.ManufacturingDefects.Where(x => x.UnitType == "Pro II").ToList().Count();
				ViewBag.DisplayCountC = displayCountC;
				ViewBag.CalCountC = calCountC;
				ViewBag.MechCountC = mechCountC;
				ViewBag.DeadCountC = deadCountC;
				ViewBag.PCBCountC = pcbCountC;
				ViewBag.OtherCountC = otherCountC;
				ViewBag.DisplayCountM = displayCountM;
				ViewBag.CalCountM = calCountM;
				ViewBag.MechCountM = mechCountM;
				ViewBag.DeadCountM = deadCountM;
				ViewBag.PCBCountM = pcbCountM;
				ViewBag.OtherCountM = otherCountM;
				ViewBag.DisplayCountP = displayCountP;
				ViewBag.CalCountP = calCountP;
				ViewBag.MechCountP = mechCountP;
				ViewBag.DeadCountP = deadCountP;
				ViewBag.PCBCountP = pcbCountP;
				ViewBag.OtherCountP = otherCountP;
				ViewBag.TotalM = totalCountM;
				ViewBag.TotalC = totalCountC;
				ViewBag.TotalP = totalCountP;
			}
			catch(Exception ex)
			{
				ViewBag.Exception = ex;
			}
			
			return View("ManufacturingReportSummary");
        }

        [HttpGet]
        public ActionResult DeliveryReportSummary()
        {
			try
			{
				var displayCountC = _context.DeliveryDefects.Where(x => x.UnitType == "Classic II" && x.Display == 1).ToList().Count();
				var calCountC = _context.DeliveryDefects.Where(x => x.UnitType == "Classic II" && x.CalibrationMissingCalibration == 1).ToList().Count();
				var mechCountC = _context.DeliveryDefects.Where(x => x.UnitType == "Classic II" && x.MechanicalAssemblyError == 1).ToList().Count();
				var deadCountC = _context.DeliveryDefects.Where(x => x.UnitType == "Classic II" && x.DeadorDyingBatteries == 1).ToList().Count();
				var pcbCountC = _context.DeliveryDefects.Where(x => x.UnitType == "Classic II" && x.PCBBoardDefect == 1).ToList().Count();
				var otherCountC = _context.DeliveryDefects.Where(x => x.UnitType == "Classic II" && x.Other == 1).ToList().Count();
				var displayCountM = _context.DeliveryDefects.Where(x => x.UnitType == "Micro" && x.Display == 1).ToList().Count();
				var calCountM = _context.DeliveryDefects.Where(x => x.UnitType == "Micro" && x.CalibrationMissingCalibration == 1).ToList().Count();
				var mechCountM = _context.DeliveryDefects.Where(x => x.UnitType == "Micro" && x.MechanicalAssemblyError == 1).ToList().Count();
				var deadCountM = _context.DeliveryDefects.Where(x => x.UnitType == "Micro" && x.DeadorDyingBatteries == 1).ToList().Count();
				var pcbCountM = _context.DeliveryDefects.Where(x => x.UnitType == "Micro" && x.PCBBoardDefect == 1).ToList().Count();
				var otherCountM = _context.DeliveryDefects.Where(x => x.UnitType == "Micro" && x.Other == 1).ToList().Count();
				var displayCountP = _context.DeliveryDefects.Where(x => x.UnitType == "Pro II" && x.Display == 1).ToList().Count();
				var calCountP = _context.DeliveryDefects.Where(x => x.UnitType == "Pro II" && x.CalibrationMissingCalibration == 1).ToList().Count();
				var mechCountP = _context.DeliveryDefects.Where(x => x.UnitType == "Pro II" && x.MechanicalAssemblyError == 1).ToList().Count();
				var deadCountP = _context.DeliveryDefects.Where(x => x.UnitType == "Pro II" && x.DeadorDyingBatteries == 1).ToList().Count();
				var pcbCountP = _context.DeliveryDefects.Where(x => x.UnitType == "Pro II" && x.PCBBoardDefect == 1).ToList().Count();
				var otherCountP = _context.DeliveryDefects.Where(x => x.UnitType == "Pro II" && x.Other == 1).ToList().Count();
				var totalCountM = _context.DeliveryDefects.Where(x => x.UnitType == "Micro").ToList().Count();
				var totalCountC = _context.DeliveryDefects.Where(x => x.UnitType == "Classic II").ToList().Count();
				var totalCountP = _context.DeliveryDefects.Where(x => x.UnitType == "Pro II").ToList().Count();
				ViewBag.DisplayCountC1 = displayCountC;
				ViewBag.CalCountC1 = calCountC;
				ViewBag.MechCountC1 = mechCountC;
				ViewBag.DeadCountC1 = deadCountC;
				ViewBag.PCBCountC1 = pcbCountC;
				ViewBag.OtherCountC1 = otherCountC;
				ViewBag.DisplayCountM1 = displayCountM;
				ViewBag.CalCountM1 = calCountM;
				ViewBag.MechCountM1 = mechCountM;
				ViewBag.DeadCountM1 = deadCountM;
				ViewBag.PCBCountM1 = pcbCountM;
				ViewBag.OtherCountM1 = otherCountM;
				ViewBag.DisplayCountP1 = displayCountP;
				ViewBag.CalCountP1 = calCountP;
				ViewBag.MechCountP1 = mechCountP;
				ViewBag.DeadCountP1 = deadCountP;
				ViewBag.PCBCountP1 = pcbCountP;
				ViewBag.OtherCountP1 = otherCountP;
				ViewBag.TotalM1 = totalCountM;
				ViewBag.TotalP1 = totalCountP;
				ViewBag.TotalC1 = totalCountC;
			}
			catch(Exception ex)
			{
				ViewBag.Exception = ex;
			}
            return View("DeliveryReportSummary");
        }

		[HttpGet]
		public ActionResult WarrantyReportSummary()
		{
			try
			{
				var displayCountC = _context.WarrantyDefects.Where(x => x.UnitType == "Classic II" && x.Display == 1).ToList().Count();
				var calCountC = _context.WarrantyDefects.Where(x => x.UnitType == "Classic II" && x.CalibrationMissingCalibration == 1).ToList().Count();
				var mechCountC = _context.WarrantyDefects.Where(x => x.UnitType == "Classic II" && x.MechanicalAssemblyError == 1).ToList().Count();
				var deadCountC = _context.WarrantyDefects.Where(x => x.UnitType == "Classic II" && x.DeadorDyingBatteries == 1).ToList().Count();
				var pcbCountC = _context.WarrantyDefects.Where(x => x.UnitType == "Classic II" && x.PCBBoardDefect == 1).ToList().Count();
				var otherCountC = _context.WarrantyDefects.Where(x => x.UnitType == "Classic II" && x.Other == 1).ToList().Count();
				var displayCountM = _context.WarrantyDefects.Where(x => x.UnitType == "Micro" && x.Display == 1).ToList().Count();
				var calCountM = _context.WarrantyDefects.Where(x => x.UnitType == "Micro" && x.CalibrationMissingCalibration == 1).ToList().Count();
				var mechCountM = _context.WarrantyDefects.Where(x => x.UnitType == "Micro" && x.MechanicalAssemblyError == 1).ToList().Count();
				var deadCountM = _context.WarrantyDefects.Where(x => x.UnitType == "Micro" && x.DeadorDyingBatteries == 1).ToList().Count();
				var pcbCountM = _context.WarrantyDefects.Where(x => x.UnitType == "Micro" && x.PCBBoardDefect == 1).ToList().Count();
				var otherCountM = _context.WarrantyDefects.Where(x => x.UnitType == "Micro" && x.Other == 1).ToList().Count();
				var displayCountP = _context.WarrantyDefects.Where(x => x.UnitType == "Pro II" && x.Display == 1).ToList().Count();
				var calCountP = _context.WarrantyDefects.Where(x => x.UnitType == "Pro II" && x.CalibrationMissingCalibration == 1).ToList().Count();
				var mechCountP = _context.WarrantyDefects.Where(x => x.UnitType == "Pro II" && x.MechanicalAssemblyError == 1).ToList().Count();
				var deadCountP = _context.WarrantyDefects.Where(x => x.UnitType == "Pro II" && x.DeadorDyingBatteries == 1).ToList().Count();
				var pcbCountP = _context.WarrantyDefects.Where(x => x.UnitType == "Pro II" && x.PCBBoardDefect == 1).ToList().Count();
				var otherCountP = _context.WarrantyDefects.Where(x => x.UnitType == "Pro II" && x.Other == 1).ToList().Count();
				var totalCountM = _context.WarrantyDefects.Where(x => x.UnitType == "Micro").ToList().Count();
				var totalCountC = _context.WarrantyDefects.Where(x => x.UnitType == "Classic II").ToList().Count();
				var totalCountP = _context.WarrantyDefects.Where(x => x.UnitType == "Pro II").ToList().Count();
				ViewBag.DisplayCountC2 = displayCountC;
				ViewBag.CalCountC2 = calCountC;
				ViewBag.MechCountC2 = mechCountC;
				ViewBag.DeadCountC2 = deadCountC;
				ViewBag.PCBCountC2 = pcbCountC;
				ViewBag.OtherCountC2 = otherCountC;
				ViewBag.DisplayCountM2 = displayCountM;
				ViewBag.CalCountM2 = calCountM;
				ViewBag.MechCountM2 = mechCountM;
				ViewBag.DeadCountM2 = deadCountM;
				ViewBag.PCBCountM2 = pcbCountM;
				ViewBag.OtherCountM2 = otherCountM;
				ViewBag.DisplayCountP2 = displayCountP;
				ViewBag.CalCountP2 = calCountP;
				ViewBag.MechCountP2 = mechCountP;
				ViewBag.DeadCountP2 = deadCountP;
				ViewBag.PCBCountP2 = pcbCountP;
				ViewBag.OtherCountP2 = otherCountP;
				ViewBag.TotalM2 = totalCountM;
				ViewBag.TotalP2 = totalCountP;
				ViewBag.TotalC2 = totalCountC;
			}
			catch (Exception ex)
			{
				ViewBag.Exception = ex;
			}
			return View("WarrantyReportSummary");
		}
	}
}
