using AJAX_HW_MSIT141_07.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJAX_HW_MSIT141_07.Controllers
{
    public class ApiController : Controller
    {

        private readonly DemoContext _context;

        public ApiController(DemoContext conetxt)
        {
            _context = conetxt;
        }

        public IActionResult Index(CUser user)
        {
            //System.Threading.Thread.Sleep(5000); //停止5秒鐘

            //return Content("Ajax, 你好!!","text/plain", System.Text.Encoding.UTF8);
            if (String.IsNullOrEmpty(user.name))
            {
                user.name = "Ajax";
            }
            return Content($"{user.name}您好,您的年紀是{user.age}，您的信箱是{user.email}!!", "text/plain", System.Text.Encoding.UTF8);
        }
        public IActionResult NameCheck(CUser user)
        {
            string result = _context.Members.Any(x => x.Name == user.name) ? "true" : "false";

            return Content(result, "text/plain", System.Text.Encoding.UTF8);
        }
    }
}
