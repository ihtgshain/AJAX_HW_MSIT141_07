using AJAX_HW_MSIT141_07.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AJAX_HW_MSIT141_07.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _context;

        public HomeController(ILogger<HomeController> logger, DemoContext conetxt)
        {

            _logger = logger;
            _context = conetxt;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult FirstAjax()
        {
            return View();
        }

        public IActionResult AjaxPost()
        {
            return View();
        }
        public IActionResult AjaxPostFormData()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }

        public IActionResult promise()
        {
            return View();
        }

        public IActionResult Fetch()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult jQuery()
        {
            return View();
        }

        public IActionResult ShipperCors()
        {
            return View();
        }

        public IActionResult ShipperCorsEmpty()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
