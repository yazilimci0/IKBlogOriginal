using BusinessLayer.Managment;
using DataAccess.Context;
using DataAccessLayer.EntittyFramework;
using DataAccessLayer.Repostory;
using EFLayer.Class;
using IKBlok.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace IKBlok.Controllers
{
    public class HomeController : Controller
    {

        KategoryManagment kt = new KategoryManagment(new EfKategoryRepo());
        IKBlokContex _context = new IKBlokContex();
        GonderiManagement gm = new GonderiManagement(new EfGonderiRepo());

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View(gm.getAllListWithKategori());
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