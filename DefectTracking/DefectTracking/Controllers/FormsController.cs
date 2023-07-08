using DefectTracking.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using DefectTracking.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace DefectTracking.Controllers
{
	public class FormsController : Controller
    {
        //Used to access the database context, which is used in searching for a serial
        //number with the same value as what is in the form textbox
        private readonly DefectTrackingContext context;

        

        private readonly IToastNotification toastNotification;
        private DefectTrackingContext trackingContext { get; }
        public FormsController(DefectTrackingContext _context, IToastNotification _toastNotification)
        {
            context = _context;
            trackingContext = _context;
            toastNotification = _toastNotification;
        }

        /// <summary>
        /// Displays all records in the Database
        /// </summary>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeliveryIndex()
		{
            var deliveryIndex = await context.DeliveryDefects.ToListAsync();

            var model = deliveryIndex.Select(delivery => new DeliveryDefects()
            {
                SerialNumber = delivery.SerialNumber,
                UnitType = delivery.UnitType,
                Display = delivery.Display,
                CalibrationMissingCalibration = delivery.CalibrationMissingCalibration,
                MechanicalAssemblyError = delivery.MechanicalAssemblyError,
                DeadorDyingBatteries = delivery.DeadorDyingBatteries,
                PCBBoardDefect = delivery.PCBBoardDefect,
                SpeakerQuiet = delivery.SpeakerQuiet,
                NoSound = delivery.NoSound,
                SwitchNotWorking = delivery.SwitchNotWorking,
                ButtonNotWorking = delivery.ButtonNotWorking,
                EnclosureDefect = delivery.EnclosureDefect,
                Other = delivery.Other,
                OtherDesc = delivery.OtherDesc,
                ProblemDesc = delivery.ProblemDesc,
                Date = delivery.Date
            }).OrderBy(x => x.SerialNumber);
            return View(model);
		}
        /// <summary>
        /// Searchs Database for where the first or second or both serial numbers are and displays the corresponding records
        /// </summary>
		[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult SearchDeliveryIndex(int? firstSerialNumber, int? secondSerialNumber)
        {
			try
            {
                if (context.DeliveryDefects == null)
                {
                    return Problem("No records found in Delivery Defects Table");
                }
				var deliveryDefects = from d in context.DeliveryDefects select d;
				var deliveryCount = 1;
				//Check if First Serial Number isnt null and Second Serial Number is null then displays record where serial number equals First Serial Number
				if (!String.IsNullOrEmpty(firstSerialNumber.ToString()) && String.IsNullOrEmpty(secondSerialNumber.ToString()))
				{
					deliveryDefects = deliveryDefects.Where(x => x.SerialNumber == firstSerialNumber);
					deliveryCount = deliveryDefects.Where(x => x.SerialNumber == firstSerialNumber).Count();
				}
				//Check if First Serial Number is null and Second Serial Number isnt null then displays record where serial number equals Second Serial Number
				else if (String.IsNullOrEmpty(firstSerialNumber.ToString()) && !String.IsNullOrEmpty(secondSerialNumber.ToString()))
				{
					deliveryDefects = deliveryDefects.Where(x => x.SerialNumber == secondSerialNumber);
					deliveryCount = deliveryDefects.Where(x => x.SerialNumber == secondSerialNumber).Count();
				}
				//Check if both First and Second Serial Numbers arent null 
				else if (!String.IsNullOrEmpty(firstSerialNumber.ToString()) && !String.IsNullOrEmpty(secondSerialNumber.ToString()))
				{
					//Checks if First Serial Number is greater than Second Serial Number then displays records between the two values
					if (firstSerialNumber >= secondSerialNumber)
					{
						deliveryDefects = deliveryDefects.Where(x => x.SerialNumber <= firstSerialNumber && x.SerialNumber >= secondSerialNumber);
						deliveryCount = deliveryDefects.Where(x => x.SerialNumber <= firstSerialNumber && x.SerialNumber >= secondSerialNumber).Count();
					}
					//Checks if First Serial Number is less than Second Serial Number then displays records between the two values
					else if (firstSerialNumber <= secondSerialNumber)
					{
						deliveryDefects = deliveryDefects.Where(x => x.SerialNumber >= firstSerialNumber && x.SerialNumber <= secondSerialNumber);
						deliveryCount = deliveryDefects.Where(x => x.SerialNumber >= firstSerialNumber && x.SerialNumber <= secondSerialNumber).Count();
					}
				}
				//If no records are found display an error message
				if (deliveryCount == 0)
				{
					ViewBag.CountD = "No records found";
				}
				else
				{
					ViewBag.CountD = "";
				}
				return View(deliveryDefects.OrderBy(x => x.SerialNumber).ToList());
			}
			catch (Exception ex)
			{
				ViewBag.Exception = ex;
			}
            return View("SearchDeliveryIndex");
        }
        /// <summary>
        /// Takes user to the Delivery Defects Form Page
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult DeliveryForm()
        {
            return View("DeliveryForm");
        }
        /// <summary>
        /// Checks the form for any errors, then saves the form data to the database when all errors are resolved
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeliveryForm(DeliveryDefectsViewModel model)
        {
			var newRecord = new DeliveryDefects();
            newRecord.UnitType = model.unitType;
            //Changes the value saved into the databse based on whether the checkbox has been checked or not, if checked, value is 1 in the database, else value is 0
            if (model.display == true)
            {
                newRecord.Display = 1;
            }
            else
            {
                newRecord.Display = 0;
            }
            if (model.calibrationMissingCalibration == true)
            {
                newRecord.CalibrationMissingCalibration = 1;
            }
            else
            {
                newRecord.CalibrationMissingCalibration = 0;
            }
            if (model.mechanicalAssemblyError == true)
            {
                newRecord.MechanicalAssemblyError = 1;
            }
            else
            {
                newRecord.MechanicalAssemblyError = 0;
            }
            if (model.deadorDyingBatteries == true)
            {
                newRecord.DeadorDyingBatteries = 1;
            }
            else
            {
                newRecord.DeadorDyingBatteries = 0;
            }
            if (model.pCBBoardDefect == true)
            {
                newRecord.PCBBoardDefect = 1;
            }
            else
            {
                newRecord.PCBBoardDefect = 0;
            }
            if (model.speakerQuiet == true)
            {
                newRecord.SpeakerQuiet = 1;
            }
            else
            {
                newRecord.SpeakerQuiet = 0;
            }
            if (model.noSound == true)
            {
                newRecord.NoSound = 1;
            }
            else
            {
                newRecord.NoSound = 0;
            }
            if (model.switchNotWorking == true)
            {
                newRecord.SwitchNotWorking = 1;
            }
            else
            {
                newRecord.SwitchNotWorking = 0;
            }
            if (model.buttonNotWorking == true)
            {
                newRecord.ButtonNotWorking = 1;
            }
            else
            {
                newRecord.ButtonNotWorking = 0;
            }
            if (model.enclosureDefect == true)
            {
                newRecord.EnclosureDefect = 1;
            }
            else
            {
                newRecord.EnclosureDefect = 0;
            }
            if (model.other == true)
            {
                newRecord.Other = 1;
            }
            else
            {
                newRecord.Other = 0;
            }
            newRecord.OtherDesc = model.otherDesc;
            //Checks the textbox to make sure that the value is not null or empty
            if (String.IsNullOrEmpty(model.serialNumber.ToString()))
            {
                ModelState.AddModelError("serialNumber", "Serial Number is required");
            }
            //Then if the textbox is not empty it checks that the value is between 0 and 100000
            else if (model.serialNumber <= 0 || model.serialNumber > 100000)
            {
                ModelState.AddModelError("serialNumber", "Serial Number must be greater than 0 and less than 100000");
            }
            //Finally it checks if the database has a serial number that already exists
            else
            {
                model.serialNumber.ToString().Trim();
                //Code below is used to check for the very first value that has the same serial number in the database then if true sends an error
                try
                {
                    var deliveryDefects = trackingContext.DeliveryDefects.Where(x => x.SerialNumber == model.serialNumber).FirstOrDefault();
                    if (deliveryDefects != null)
                    {
                        ModelState.AddModelError("serialNumber", "Serial Number already exists");
                    }
                    else if(deliveryDefects == null) 
                    {
                        newRecord.SerialNumber = model.serialNumber;
                    }
                }
                catch (NullReferenceException)
                {
                    newRecord.SerialNumber = model.serialNumber;
                }
            }
            //Checks if all the check boxes are unchecked then throws an error  
            if (model.display == false && model.calibrationMissingCalibration == false && model.mechanicalAssemblyError == false
                && model.deadorDyingBatteries == false && model.pCBBoardDefect == false && model.speakerQuiet == false && model.noSound == false
                && model.switchNotWorking == false && model.buttonNotWorking == false && model.enclosureDefect == false && model.other == false)
            {
                ModelState.AddModelError("display", "Please select at least one defect type");
                ModelState.AddModelError("calibrationMissingCalibration", "Please select at least one defect type");
                ModelState.AddModelError("mechanicalAssemblyError", "Please select at least one defect type");
                ModelState.AddModelError("deadorDyingBatteries", "Please select at least one defect type");
                ModelState.AddModelError("pCBBoardDefect", "Please select at least one defect type");
                ModelState.AddModelError("speakerQuiet", "Please select at least one defect type");
                ModelState.AddModelError("noSound", "Please select at least one defect type");
                ModelState.AddModelError("switchNotWorking", "Please select at least one defect type");
                ModelState.AddModelError("buttonNotWorking", "Please select at least one defect type");
                ModelState.AddModelError("enclosureDefect", "Please select at least one defect type");
                ModelState.AddModelError("other", "Please select at least one defect type");
            }

            if (model.other == false && !String.IsNullOrEmpty(model.otherDesc))
            {
                ModelState.AddModelError("otherDesc", "Please select other check box before submitting");
            }
            //Checks if the "Other" check box has been checked and if true, makes the user have to add the other defect desc
            //or else an error gets thrown
            if (model.other == true)
            {
                if (!String.IsNullOrEmpty(model.otherDesc))
                {
                    newRecord.OtherDesc = model.otherDesc;
                }
                else
                {
                    ModelState.AddModelError("otherDesc", "Must write what other defect is");
                }
                //If Other checkbox is unchecked then sets the value of the textbox to empty regardless of if someone writes in the box
                //and saves the textbox value as empty when saved into the database
            }
            else if (model.other == false)
            {
                newRecord.OtherDesc = "";
            }
            //Checks if the users has written what the Desc. of the unit is and if not, sends an error
            if (!String.IsNullOrEmpty(model.problemDesc))
            {
                newRecord.ProblemDesc = model.problemDesc;
            }
            else
            {
                ModelState.AddModelError("problemDesc", "Please write what the problem of the device is before submitting");
            }

            //Checks that all errors have been fixed before saving all the data to the database
            if (ModelState.IsValid)
            {
                newRecord.Date = DateTime.Now.Date;
                newRecord.SaveDetails();
                ModelState.Clear();
                return RedirectToAction("DeliveryForm");
            }
            return View(model);

        }

        /// <summary>
        /// Displays all records in the Database
        /// </summary>
        [Authorize(Roles = "Admin")]
        public ActionResult ManufacturingIndex()
        {
			var manufacturingIndex = context.ManufacturingDefects.ToList();

			var model = manufacturingIndex.Select(manufacturing => new ManufacturingDefects()
			{
				SerialNumber = manufacturing.SerialNumber,
				UnitType = manufacturing.UnitType,
				Display = manufacturing.Display,
				CalibrationMissingCalibration = manufacturing.CalibrationMissingCalibration,
				MechanicalAssemblyError = manufacturing.MechanicalAssemblyError,
				DeadorDyingBatteries = manufacturing.DeadorDyingBatteries,
				PCBBoardDefect = manufacturing.PCBBoardDefect,
                SpeakerQuiet = manufacturing.SpeakerQuiet,
                NoSound = manufacturing.NoSound,
                SwitchNotWorking = manufacturing.SwitchNotWorking,
                ButtonNotWorking = manufacturing.ButtonNotWorking,
                EnclosureDefect = manufacturing.EnclosureDefect,
				Other = manufacturing.Other,
				OtherDesc = manufacturing.OtherDesc,
				ProblemDesc = manufacturing.ProblemDesc,
                Date = manufacturing.Date
			}).OrderBy(x => x.SerialNumber);
			return View(model);
		}
        /// <summary>
        /// Searchs Database for where the first or second or both serial numbers are and displays the corresponding records
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
		public ActionResult SearchManufacturingIndex(int? firstSerialNumber, int? secondSerialNumber)
		{
			try
            {
                if (context.ManufacturingDefects == null)
                {
                    return Problem("No records found in Manufacturing Defects Table");
                }
				var manufacturingDefects = from d in context.ManufacturingDefects select d;
				var manufacturingCount = 1;
				//Checks if First Serial Number isnt null and Second Serial Number is null and displays record where Serial Number equals First Serial Number
				if (!String.IsNullOrEmpty(firstSerialNumber.ToString()) && String.IsNullOrEmpty(secondSerialNumber.ToString()))
				{
					manufacturingDefects = manufacturingDefects.Where(x => x.SerialNumber == firstSerialNumber);
					manufacturingCount = manufacturingDefects.Where(x => x.SerialNumber == firstSerialNumber).Count();
				}
				//Checks if First Serial Number is null and Second Serial Number isnt null and displays record where Serial Number equals Second Serial Number
				else if (String.IsNullOrEmpty(firstSerialNumber.ToString()) && !String.IsNullOrEmpty(secondSerialNumber.ToString()))
				{
					manufacturingDefects = manufacturingDefects.Where(x => x.SerialNumber == secondSerialNumber);
					manufacturingCount = manufacturingDefects.Where(x => x.SerialNumber == secondSerialNumber).Count();
				}
				//Checks if both First and Second Serial Numbers arent null
				else if (!String.IsNullOrEmpty(firstSerialNumber.ToString()) && !String.IsNullOrEmpty(secondSerialNumber.ToString()))
				{
					//Checks if First Serial Number is greater than Second Serial Number then displays all records in between the two values 
					if (firstSerialNumber >= secondSerialNumber)
					{
						manufacturingDefects = manufacturingDefects.Where(x => x.SerialNumber <= firstSerialNumber && x.SerialNumber >= secondSerialNumber);
						manufacturingCount = manufacturingDefects.Where(x => x.SerialNumber <= firstSerialNumber && x.SerialNumber >= secondSerialNumber).Count();
					}
					//Checks if First Serial Number is less than Second Serial Number then displays all records in between the two values
					else if (firstSerialNumber <= secondSerialNumber)
					{
						manufacturingDefects = manufacturingDefects.Where(x => x.SerialNumber >= firstSerialNumber && x.SerialNumber <= secondSerialNumber);
						manufacturingCount = manufacturingDefects.Where(x => x.SerialNumber >= firstSerialNumber && x.SerialNumber <= secondSerialNumber).Count();
					}
				}
				//If no records are found display an error message
				if (manufacturingCount == 0)
				{
					ViewBag.CountM = "No records found";
				}
				else
				{
					ViewBag.CountM = "";
				}
				return View(manufacturingDefects.OrderBy(x => x.SerialNumber).ToList());
			}catch(Exception ex)
            {
                ViewBag.Exception = ex;
			}
            return View("SearchManufacturingIndex");
			
		}

        /// <summary>
        /// Takes the user to the manufacturing form
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ManufacturingForm()
        {
			return View("ManufacturingForm");
        }

        /// <summary>
        /// Checks the form for any errors, then saves the form data to the database when all errors are resolved 
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult ManufacturingForm(ManufacturingDefectsViewModel model) 
        {
			var newRecord = new ManufacturingDefects();
            newRecord.UnitType = model.unitType;
            //Changes the value saved into the databse based on whether the checkbox has been checked or not, if checked, value is 1 in the database, else value is 0
            if (model.display == true)
            {
                newRecord.Display = 1;
            }else
            {
                newRecord.Display = 0;
            }
            if (model.calibrationMissingCalibration == true)
            {
                newRecord.CalibrationMissingCalibration = 1;
            }else
            {
                newRecord.CalibrationMissingCalibration = 0;
            }
            if (model.mechanicalAssemblyError== true)
            {
                newRecord.MechanicalAssemblyError = 1;
            }else
            {
                newRecord.MechanicalAssemblyError = 0;
            }
            if (model.deadorDyingBatteries== true)
            {
                newRecord.DeadorDyingBatteries = 1;
            }else
            {
                newRecord.DeadorDyingBatteries = 0;
            }
            if (model.pCBBoardDefect == true)
            {
                newRecord.PCBBoardDefect = 1;
            }else
            {
                newRecord.PCBBoardDefect = 0;
            }
            if (model.speakerQuiet == true)
            {
                newRecord.SpeakerQuiet = 1;
            }
            else
            {
                newRecord.SpeakerQuiet = 0;
            }
            if (model.noSound == true)
            {
                newRecord.NoSound = 1;
            }
            else
            {
                newRecord.NoSound = 0;
            }
            if (model.switchNotWorking == true)
            {
                newRecord.SwitchNotWorking = 1;
            }
            else
            {
                newRecord.SwitchNotWorking = 0;
            }
            if (model.buttonNotWorking == true)
            {
                newRecord.ButtonNotWorking = 1;
            }
            else
            {
                newRecord.ButtonNotWorking = 0;
            }
            if (model.enclosureDefect == true)
            {
                newRecord.EnclosureDefect = 1;
            }
            else
            {
                newRecord.EnclosureDefect = 0;
            }
            if (model.other == true)
            {
                newRecord.Other = 1;
            }else
            {
                newRecord.Other = 0;
            }
            newRecord.OtherDesc = model.otherDesc;
            
            //Checks the textbox to make sure that the value is not null or empty
            if (String.IsNullOrEmpty(model.serialNumber.ToString()))
            {
                ModelState.AddModelError("serialNumber", "Serial Number is required");
            }
            //Then if the textbox is not empty it checks that the value is between 0 and 100000
            else if (model.serialNumber <= 0 || model.serialNumber > 100000)
            {
                ModelState.AddModelError("serialNumber", "Serial Number must be greater than 0 and less than 100000");
            }
            //Finally it checks if the database has a serial number that already exists
            else
            {
                model.serialNumber.ToString().Trim();
                //Code below is used to check for the very first value that has the same serial number in the database then if true sends an error
                try
                {
                    var manufacturingDefects = trackingContext.ManufacturingDefects.Where(x => x.SerialNumber == model.serialNumber).FirstOrDefault();
                    if (manufacturingDefects != null)
                    {
                        ModelState.AddModelError("serialNumber", "Serial Number already exists");
                    }
                    else if(manufacturingDefects == null)
                    {
                        newRecord.SerialNumber = model.serialNumber;
                    }
                }
                catch(NullReferenceException)
                {
                    newRecord.SerialNumber = model.serialNumber;
                }
                
            }

            //Checks if all the check boxes are unchecked then throws an error  
            if (model.display == false && model.calibrationMissingCalibration == false && model.mechanicalAssemblyError == false
                && model.deadorDyingBatteries == false && model.pCBBoardDefect == false && model.speakerQuiet == false && model.noSound == false
                && model.switchNotWorking == false && model.buttonNotWorking == false && model.enclosureDefect == false && model.other == false)
            {
                ModelState.AddModelError("display", "Please select at least one defect type");
                ModelState.AddModelError("calibrationMissingCalibration", "Please select at least one defect type");
                ModelState.AddModelError("mechanicalAssemblyError", "Please select at least one defect type");
                ModelState.AddModelError("deadorDyingBatteries", "Please select at least one defect type");
                ModelState.AddModelError("pCBBoardDefect", "Please select at least one defect type");
                ModelState.AddModelError("speakerQuiet", "Please select at least one defect type");
                ModelState.AddModelError("noSound", "Please select at least one defect type");
                ModelState.AddModelError("switchNotWorking", "Please select at least one defect type");
                ModelState.AddModelError("buttonNotWorking", "Please select at least one defect type");
                ModelState.AddModelError("enclosureDefect", "Please select at least one defect type");
                ModelState.AddModelError("other", "Please select at least one defect type");
            }

            if (model.other == false && !String.IsNullOrEmpty(model.otherDesc))
            {
                ModelState.AddModelError("otherDesc", "Please select other check box before submitting");
            }
            //Checks if the "Other" check box has been checked and if true, makes the user have to add the other defect desc
            //or else an error gets thrown
            if (model.other == true)
            {
                if (!String.IsNullOrEmpty(model.otherDesc))
                {
                    newRecord.OtherDesc = model.otherDesc;
                }
                else
                {
                    ModelState.AddModelError("otherDesc", "Must write what other defect is");
                }
                //If Other checkbox is unchecked then sets the value of the textbox to empty regardless of if someone writes in the box
                //and saves the textbox value as empty when saved into the database
            }else if (model.other == false)
            {
                newRecord.OtherDesc = "";
            }
            //Checks if the users has written what the Desc. of the unit is and if not, sends an error
            if (!String.IsNullOrEmpty(model.problemDesc))
            {
                newRecord.ProblemDesc = model.problemDesc;
            }else
            {
                ModelState.AddModelError("problemDesc", "Please write what the problem of the device is before submitting");
            }

            //Checks that all errors have been fixed before saving all the data to the database
            if (ModelState.IsValid)
            {
                newRecord.Date = DateTime.Now.Date;
                newRecord.SaveDetails();
                ModelState.Clear();
                return RedirectToAction("ManufacturingForm");
            }
            return View(model);
            
        }
        /// <summary>
        /// Displays all records in the Database
        /// </summary>
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult WarrantyIndex()
        {
			var warrantyIndex = context.WarrantyDefects.ToList();

			var model = warrantyIndex.Select(warranty => new WarrantyDefects()
			{
                Id = warranty.Id,
				SerialNumber = warranty.SerialNumber,
				UnitType = warranty.UnitType,
				Display = warranty.Display,
				CalibrationMissingCalibration = warranty.CalibrationMissingCalibration,
				MechanicalAssemblyError = warranty.MechanicalAssemblyError,
				DeadorDyingBatteries = warranty.DeadorDyingBatteries,
				PCBBoardDefect = warranty.PCBBoardDefect,
                SpeakerQuiet = warranty.SpeakerQuiet,
                NoSound = warranty.NoSound,
                SwitchNotWorking = warranty.SwitchNotWorking,
                ButtonNotWorking = warranty.ButtonNotWorking,
                EnclosureDefect = warranty.EnclosureDefect,
				Other = warranty.Other,
				OtherDesc = warranty.OtherDesc,
				ProblemDesc = warranty.ProblemDesc,
                Date = warranty.Date,
                WorkPerformed = warranty.WorkPerformed,
                OldSerialNumber = warranty.OldSerialNumber,
                UnitStatus = warranty.UnitStatus
			}).OrderBy(x => x.SerialNumber);
			return View(model);
		}

        /// <summary>
        /// Searchs Database for where the first or second or both serial numbers are and displays the corresponding records
        /// </summary>
        [Authorize(Roles = "Admin, Employee")]
        [HttpGet]
		public ActionResult SearchWarrantyIndex(int? firstSerialNumber, int? secondSerialNumber)
		{
			try
            {
                if (context.WarrantyDefects == null)
                {
                    return Problem("No records found in Warranty Defects Table");
                }
				var warrantyDefects = from d in context.WarrantyDefects select d;
				var oldWarrantyDefects = from o in context.WarrantyDefects select o;
				var oldWarrantyCount = 1;
				var warrantyCount = 1;
                if (warrantyCount == 1 && oldWarrantyCount == 1)
                {
                    //Checks if First Serial Number isnt null and Second Serial Number is null then displays record where Serial Number equals First Serial Number
                    if (!String.IsNullOrEmpty(firstSerialNumber.ToString()) && String.IsNullOrEmpty(secondSerialNumber.ToString()))
                    {
                        warrantyDefects = warrantyDefects.Where(x => x.SerialNumber == firstSerialNumber);
                        warrantyCount = warrantyDefects.Where(x => x.SerialNumber == firstSerialNumber).Count();
                    }
                    //Checks if First Serial Number is null and Second Serial Number isnt null then displays record where Serial Number equals Second Serial Number
                    else if (String.IsNullOrEmpty(firstSerialNumber.ToString()) && !String.IsNullOrEmpty(secondSerialNumber.ToString()))
                    {
                        warrantyDefects = warrantyDefects.Where(x => x.SerialNumber == secondSerialNumber);
                        warrantyCount = warrantyDefects.Where(x => x.SerialNumber == firstSerialNumber).Count();
                    }
                    //Checks that both First and Second Serial Numbers arent null
                    else if (!String.IsNullOrEmpty(firstSerialNumber.ToString()) && !String.IsNullOrEmpty(secondSerialNumber.ToString()))
                    {
                        //Checks if First Serial Number is greater than Second Serial Number then displays all records between the two values
                        if (firstSerialNumber >= secondSerialNumber)
                        {
                            warrantyDefects = warrantyDefects.Where(x => x.SerialNumber <= firstSerialNumber && x.SerialNumber >= secondSerialNumber);
                            warrantyCount = warrantyDefects.Where(x => x.SerialNumber <= firstSerialNumber && x.SerialNumber >= secondSerialNumber).Count();
                        }
                        //Checks if First Serial Number is less than Second Serial Number then displays all records between the two values
                        else if (firstSerialNumber <= secondSerialNumber)
                        {
                            warrantyDefects = warrantyDefects.Where(x => x.SerialNumber >= firstSerialNumber && x.SerialNumber <= secondSerialNumber);
                            warrantyCount = warrantyDefects.Where(x => x.SerialNumber >= firstSerialNumber && x.SerialNumber <= secondSerialNumber).Count();
                        }
                    }
                }
                if (warrantyCount == 0)
                {
					//Checks if First Serial Number isnt null and Second Serial Number is null then displays record where Old Serial Number equals First Serial Number
					if (!String.IsNullOrEmpty(firstSerialNumber.ToString()) && String.IsNullOrEmpty(secondSerialNumber.ToString()))
					{
						oldWarrantyDefects = oldWarrantyDefects.Where(x => x.OldSerialNumber == firstSerialNumber);
						oldWarrantyCount = oldWarrantyDefects.Where(x => x.OldSerialNumber == firstSerialNumber).Count();
					}
					//Checks if First Serial Number is null and Second Serial Number isnt null then displays record where Old Serial Number equals Second Serial Number
					else if (String.IsNullOrEmpty(firstSerialNumber.ToString()) && !String.IsNullOrEmpty(secondSerialNumber.ToString()))
					{
						oldWarrantyDefects = oldWarrantyDefects.Where(x => x.OldSerialNumber == secondSerialNumber);
						oldWarrantyCount = oldWarrantyDefects.Where(x => x.OldSerialNumber == firstSerialNumber).Count();
					}
					
				}
                
                //Check if there are no records then displays an error message
                if (warrantyCount == 0 && oldWarrantyCount == 0)
				{
					ViewBag.CountW = "No records found";
				}
				else
				{
					ViewBag.CountW = "";
				}
                if (warrantyCount != 0 && oldWarrantyCount == 0)
                {
                    ViewBag.CountW = "";
                    return View(warrantyDefects);
                }
                else if (oldWarrantyCount != 0 && warrantyCount == 0)
                {
                    ViewBag.CountW = "";
                    return View(oldWarrantyDefects);
				}
                else 
                {
                    return View(warrantyDefects);
                }
			}
			catch(Exception ex)
            {
                ViewBag.Exception = ex;
			}
            return View("SearchWarrantyIndex");


			
		}

        /// <summary>
        /// Takes you to the Warranty Form Page
        /// </summary>
		[Authorize(Roles = "Admin, Employee")]
        [HttpGet]
        public ActionResult WarrantyForm()
        {
            return View("WarrantyForm");
        }

        /// <summary>
        /// Validates the form data and if there are no errors, save the data to the Warranty Defect Table in the database
        /// </summary>
        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        public ActionResult WarrantyForm(WarrantyDefectsViewModel model)
        {
            
			var newRecord = new WarrantyDefects();
            newRecord.UnitType = model.unitType;
            newRecord.OldSerialNumber = 0;
            newRecord.UnitStatus = true;

            if (model.display == true)
            {
                newRecord.Display = 1;
            }
            else
            {
                newRecord.Display = 0;
            }
            if (model.calibrationMissingCalibration == true)
            {
                newRecord.CalibrationMissingCalibration = 1;
            }
            else
            {
                newRecord.CalibrationMissingCalibration = 0;
            }
            if (model.mechanicalAssemblyError == true)
            {
                newRecord.MechanicalAssemblyError = 1;
            }
            else
            {
                newRecord.MechanicalAssemblyError = 0;
            }
            if (model.deadorDyingBatteries == true)
            {
                newRecord.DeadorDyingBatteries = 1;
            }
            else
            {
                newRecord.DeadorDyingBatteries = 0;
            }
            if (model.pCBBoardDefect == true)
            {
                newRecord.PCBBoardDefect = 1;
            }
            else
            {
                newRecord.PCBBoardDefect = 0;
            }
            if (model.speakerQuiet == true)
            {
                newRecord.SpeakerQuiet = 1;
            }else
            {
                newRecord.SpeakerQuiet = 0;
            }
            if (model.noSound == true)
            {
                newRecord.NoSound = 1;
            }else
            {
                newRecord.NoSound = 0;
            }
            if (model.switchNotWorking == true)
            {
                newRecord.SwitchNotWorking = 1;
            }else
            {
                newRecord.SwitchNotWorking = 0;
            }
            if (model.buttonNotWorking == true)
            {
                newRecord.ButtonNotWorking = 1;
            }else
            {
                newRecord.ButtonNotWorking = 0;
            }
            if(model.enclosureDefect == true) 
            {
                newRecord.EnclosureDefect = 1;
            }else
            {
                newRecord.EnclosureDefect = 0;
            }
            if (model.other == true)
            {
                newRecord.Other = 1;
            }
            else
            {
                newRecord.Other = 0;
            }
            newRecord.OtherDesc = model.otherDesc;

            //Checks the textbox to make sure that the value is not null or empty
            if (String.IsNullOrEmpty(model.serialNumber.ToString()))
            {
                ModelState.AddModelError("serialNumber", "Serial Number is required");
            }
            //Then if the textbox is not empty it checks that the value is between 0 and 100000
            else if (model.serialNumber <= 0 || model.serialNumber > 100000)
            {
                ModelState.AddModelError("serialNumber", "Serial Number must be greater than 0 and less than 100000");
            }
            //Finally it checks if the database has a serial number that already exists
            else
            {
                model.serialNumber.ToString().Trim();
                //Code below is used to check for the very first value that has the same serial number in the database then if true sends an error
                try
                {
                    var warrantyDefects = trackingContext.WarrantyDefects.Where(x => x.SerialNumber == model.serialNumber).FirstOrDefault();
                    if (warrantyDefects != null)
                    {
                        ModelState.AddModelError("serialNumber", "Serial Number already exists");
                    }
                    else if (warrantyDefects == null)
                    {
                        newRecord.SerialNumber = model.serialNumber;
                    }
                }
                catch (NullReferenceException)
                {
                    newRecord.SerialNumber = model.serialNumber;
                }
            }


            //Checks if all the check boxes are unchecked then throws an error  
            if (model.display == false && model.calibrationMissingCalibration == false && model.mechanicalAssemblyError == false 
                && model.deadorDyingBatteries == false && model.pCBBoardDefect == false && model.speakerQuiet == false && model.noSound == false 
                && model.switchNotWorking == false && model.buttonNotWorking == false && model.enclosureDefect == false && model.other == false)
            {
                ModelState.AddModelError("display", "Please select at least one defect type");
                ModelState.AddModelError("calibrationMissingCalibration", "Please select at least one defect type");
                ModelState.AddModelError("mechanicalAssemblyError", "Please select at least one defect type");
                ModelState.AddModelError("deadorDyingBatteries", "Please select at least one defect type");
                ModelState.AddModelError("pCBBoardDefect", "Please select at least one defect type");
                ModelState.AddModelError("speakerQuiet", "Please select at least one defect type");
                ModelState.AddModelError("noSound", "Please select at least one defect type");
                ModelState.AddModelError("switchNotWorking", "Please select at least one defect type");
                ModelState.AddModelError("buttonNotWorking", "Please select at least one defect type");
                ModelState.AddModelError("enclosureDefect", "Please select at least one defect type");
                ModelState.AddModelError("other", "Please select at least one defect type");
            }

            if (model.other == false && !String.IsNullOrEmpty(model.otherDesc))
            {
                ModelState.AddModelError("otherDesc", "Please select other check box before submitting");
            }
            //Checks if the "Other" check box has been checked and if true, makes the user have to add the other defect desc
            //or else an error gets thrown
            if (model.other == true)
            {
                if (!String.IsNullOrEmpty(model.otherDesc))
                {
                    newRecord.OtherDesc = model.otherDesc;
                }
                else
                {
                    ModelState.AddModelError("otherDesc", "Must write what other defect is");
                }
                //If Other checkbox is unchecked then sets the value of the textbox to empty regardless of if someone writes in the box
                //and saves the textbox value as empty when saved into the database
            }
            else if (model.other == false)
            {
                newRecord.OtherDesc = "";
            }
            //Checks if the users has written what the Desc. of the unit is and if not, sends an error
            if (!String.IsNullOrEmpty(model.problemDesc))
            {
                newRecord.ProblemDesc = model.problemDesc;
            }
            else
            {
                ModelState.AddModelError("problemDesc", "Please write what the problem of the device is before submitting");
            }

            //Checks that all errors have been fixed before saving all the data to the database
            if (ModelState.IsValid)
            {
                newRecord.WorkPerformed = null;
                newRecord.Date = DateTime.Now;
                newRecord.SaveDetails();
                ModelState.Clear();
                toastNotification.AddSuccessToastMessage("Record Saved To Database");
                return RedirectToAction("WarrantyForm");
            }
            return View(model);
        }
        
        /// <summary>
        /// Takes you to the edit page for the selected record based on the id of the record
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> WarrantyEdit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var warranty = await context.WarrantyDefects.FindAsync(id);
            if (warranty == null)
            {
                return NotFound();
            }
            if (warranty.OldSerialNumber == 0)
            {
                warranty.OldSerialNumber = warranty.SerialNumber;
                warranty.SerialNumber = 0;
            }
            return View(warranty);
        }

        /// <summary>
        /// Updates the database with the workperformed textbox value then redirects you back to the index page
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult SaveWarrantyEdits(WarrantyDefects model)
        {
            var newRecord = new WarrantyDefects();

            newRecord.SerialNumber = model.SerialNumber;
            newRecord.Id = model.Id;
            newRecord.WorkPerformed = model.WorkPerformed;
            newRecord.OldSerialNumber = model.OldSerialNumber;
            newRecord.UnitStatus = model.UnitStatus;
            if (ModelState.IsValid)
            {
                newRecord.UpdateDetails();
                ModelState.Clear();
                return RedirectToAction("WarrantyIndex");
            }
            return View("WarrantyEdit");
        }


    }
}