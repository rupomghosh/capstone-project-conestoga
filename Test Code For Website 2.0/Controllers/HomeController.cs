using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Test_Code_For_Website_2._0.Data;
using Test_Code_For_Website_2._0.Models;

namespace Test_Code_For_Website_2._0.Controllers
{
    public class HomeController : Controller
    {

        private readonly DBContext context;

        private DBContext trackingContext { get; }

        public HomeController(DBContext _context)
        {
            context = _context;
            trackingContext = _context;
        }
        
        [HttpGet]
        public IActionResult Index() 
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Index(LoopClassViewModel model)
        {
            
            if (String.IsNullOrEmpty(Convert.ToString(model.firstSerialNumber)))
            {
                ModelState.AddModelError("firstSerialNumber", "First Serial Number Cant Be Empty");
            }
            else if (model.firstSerialNumber == 0)
            {
				ModelState.AddModelError("firstSerialNumber", "First Serial Number Cant Be 0");
			}
            else if (model.firstSerialNumber >= 100000)
            {
				ModelState.AddModelError("firstSerialNumber", "First Serial Number Cant Be Greater Than 99999");
			}
            if (String.IsNullOrEmpty(Convert.ToString(model.lastSerialNumber)))
            {
                ModelState.AddModelError("lastSerialNumber", "Last Serial Number Cant Be Empty");
            }
            else if (model.lastSerialNumber == 0)
            {
				ModelState.AddModelError("lastSerialNumber", "Last Serial Number Cant Be 0");
			}
            else if (model.lastSerialNumber >= 100000)
            {
				ModelState.AddModelError("lastSerialNumber", "Last Serial Number Cant Be Greater Than 99999");
			}
            if (model.firstSerialNumber >= model.lastSerialNumber)
            {
                ModelState.AddModelError("firstSerialNumber", "First Serial Number Must Be Less Than Last Serial Number");
            }
            if (String.IsNullOrEmpty(model.techName) || String.IsNullOrWhiteSpace(model.techName))
            {
                ModelState.AddModelError("techName", "Tech Name Must Be Filled Out");
            }

            if (ModelState.IsValid)
            {
                for (Convert.ToInt32(model.firstSerialNumber); model.firstSerialNumber - 1 < model.lastSerialNumber; model.firstSerialNumber++) 
                {
                    var loopClass = trackingContext.LoopClass.Where(x => x.SerialNumber == model.firstSerialNumber).FirstOrDefault();
                    if (loopClass == null)
                    {
                        var newRecord = new LoopClass();
                        newRecord.SerialNumber = Convert.ToInt32(model.firstSerialNumber);
                        newRecord.TechName = model.techName;
                        newRecord.SaveData();
                        ModelState.Clear();
                    }
                }
                return View();
            }
            
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var loopClassIndex = await context.LoopClass.ToListAsync();
            var model = loopClassIndex.Select(loop => new LoopClass()
            {
                Id = loop.Id,
                SerialNumber = loop.SerialNumber,
                TechName = loop.TechName
            }).OrderBy(x => x.SerialNumber);
            return View(model);
        }
    }
}