using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ImportCVS.Models;
using System.IO;
using System.Globalization;
using ImportCVS.Services;

namespace ImportCVS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IcsvService _csvService;

        public HomeController(IcsvService csvService)
        {
            this._csvService = csvService;
        }

        public IActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PathModel path)
        {
            try
            {                                   
                    string[] filePaths = Directory.GetFiles(@"C:\CSV\", "*.csv");
                    if (filePaths.Length > 0)
                    {
                        @TempData["Message"] = _csvService.AddCSV(filePaths);
                        return View();
                    }
                    else {
                        @TempData["Message"] = "There is not csv file in the Path";
                        return View();
                    }              
            }
            catch
            {
                var error = "An error occurred while processing your request. !!";
                TempData["Message"] = error;
                return View();
            }
        }


    }
}
