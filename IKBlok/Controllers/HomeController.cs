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
        DataKategoriRepostory dkr=new DataKategoriRepostory();

        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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