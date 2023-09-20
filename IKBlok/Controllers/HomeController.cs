using BusinessLayer.Managment;
using DataAccessLayer.EntittyFramework;
using DataAccessLayer.Repostory;
using EFLayer.Class;
using IKBlok.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IKBlok.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        KategoryManagment kt = new KategoryManagment(new EfKategoryRepo());

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["kategoriler"]=kt.getAllList();
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