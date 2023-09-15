using BusinessLayer.ValidationRoles;
using DataAccess.Context;
using EFLayer.Class;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;



namespace IKBlok.Controllers
{
    public class LoginController : Controller
    {
        IKBlokContex iKBlokContex = new IKBlokContex();

        public async Task<IActionResult> Index()
        {
            return View();
        }


        // POST: Login1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            UsersValidationRoles uv = new UsersValidationRoles();
            ValidationResult result = uv.Validate(user);

            if (result.IsValid)
            {
                var varmi = iKBlokContex
                    .User
                    .Where(x => x.UserAdi == user.UserAdi & x.Password == user.Password)
                    .FirstOrDefault();
                if (varmi != null)
                {
                    HttpContext.Session.SetInt32("roleid",varmi.RoleId);
                    return RedirectToAction("Index", "Admin");
                }
                ViewBag.EslesmeHatasi = true;
                return View();



            }
            else
            {
                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }

            }
            return View(user);
        }
    }
}
//using DataAccess.Context;
//using EFLayer.Class;
//using Microsoft.AspNetCore.Mvc;



//namespace IKBlok.Controllers
//{
//    public class LoginController : Controller
//    {
//        IKBlokContex iKBlokContex = new IKBlokContex();
//        public IActionResult Index()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Index(string KullaniciAdi, string KullaniciSifre)
//        {

//            var UserCheck = iKBlokContex.User.Where(x => x.UserAdi == KullaniciAdi & x.Password == KullaniciSifre).FirstOrDefault();
//            if (UserCheck != null)
//            {

//                return RedirectToAction("Index", "Login");

//            }
//            else
//            {
//                return View();
//            }


//        }

//    }
//}
