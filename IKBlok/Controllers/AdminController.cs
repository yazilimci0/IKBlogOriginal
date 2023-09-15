using DataAccessLayer.Repostory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IKBlok.Controllers
{
    public class AdminController : Controller
    {
		[Yetki]
        public IActionResult Index()
		{
			
			return View();
        }
		public IActionResult Create()
		{
			
			return View();
		}

	}
}
