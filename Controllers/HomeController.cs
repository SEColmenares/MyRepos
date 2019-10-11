using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC_Core.Factory;
using MVC_Core.Models;
using MVC_Core.Utility;

namespace MVC_Core.Controllers {
    public class HomeController : Controller {
        private readonly IOptions<MySettingsModel> appSettings;
        public HomeController (IOptions<MySettingsModel> app) {
            appSettings = app;
            ApplicationSettings.WebApiURL = appSettings.Value.webApiUrl;
        }                
        public IActionResult Index () {            
            return View ();
        }
        public IActionResult About () {
            ViewData["Message"] = "Your application description page.";
            return View ();
        }

        public IActionResult Contact () {
            var data =  ApiClientFactory.Instance.GetUsers();
            ViewData["Message"] = "Your contact page.";
            return View ();
        }

        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}