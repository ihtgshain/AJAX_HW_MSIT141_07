using AJAX_HW_MSIT141_07.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AJAX_HW_MSIT141_07.Controllers
{
    public class ApiController : Controller
    {

        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public ApiController(DemoContext conetxt,IWebHostEnvironment host)
        {
            _context = conetxt;
            _host = host;
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
        public IActionResult Register(Member member, IFormFile file)
        {
            string path = Path.Combine(_host.WebRootPath, "uploads",file.FileName);
            using(var fileStream = new FileStream(path, FileMode.Create))//沒有using的話，FileStream不會關掉，1.jpg會被鎖住
            {
                file.CopyTo(fileStream);
            }

            byte[] imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            member.FileName = file.FileName;
            member.FileData = imgByte;

            _context.Members.Add(member);
            _context.SaveChanges();

            string info = $"{file.FileName} - {file.ContentType} - {file.Length}";
            return Content($"檔案名稱{file.FileName}", "text/plain", System.Text.Encoding.UTF8);
        }

        public IActionResult City()
        {
            var result = _context.Addresses.Select(x => x.City).Distinct();
            return Json(result);
        }
        public IActionResult District(string city)
        {
            var result = _context.Addresses.Where(x=>x.City==city).Select(a => a.SiteId).Distinct();
            return Json(result);
        }
        public IActionResult Road(string district)
        {
            var result = _context.Addresses.Where(x => x.SiteId==district).Select(a=>a.Road);
            return Json(result);
        }

        public IActionResult GetImageBytes(int id=1)
        {
            byte[] img = _context.Members.Find(id).FileData;
            return File(img, "image/jpeg");
        }

        public IActionResult GetKeyWords(string kw)
        {
            var result = _context.Members.Select(x => x.Name).Where(y => y.Contains(kw));
            return Json(result);
        }
    }
}
