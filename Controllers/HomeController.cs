using Microsoft.AspNetCore.Mvc;
using System;

namespace Angular2WithCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("/ts-scripts/{name}.css")]
        public IActionResult GetCss(String name)
        {

            byte[] fileBytes = System.IO.File.ReadAllBytes("AppScripts/" + name + ".css");
            return File(fileBytes, "text/css");
        }

        [HttpGet("/ts-scripts/{name}.cshtml")]
        public IActionResult GetObject(String name)
        {
            return View("~/AppScripts/" + name + ".cshtml");
        }

    }
}
