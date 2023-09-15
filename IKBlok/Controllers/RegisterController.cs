using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using EFLayer.Class;
using FluentValidation.Results;
using BusinessLayer.Managment;
using BusinessLayer.ValidationRoles;
using DataAccessLayer.EntittyFramework;
using Microsoft.CodeAnalysis.Scripting;
using DataAccessLayer.Repostory;

namespace IKBlok.Controllers
{
    public class RegisterController : Controller
    {
        DataUserRepostory db = new DataUserRepostory();

        UserManagment um = new UserManagment(new EfUserRepo());

        // GET: Register

        public async Task<IActionResult> Index(User user)
        {
            return View();
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            RegisterValidationRoles us = new RegisterValidationRoles();
            ValidationResult result = us.Validate(user);
            if (result.IsValid)
            {
                db.add(user);

                ViewBag.KayitBasarili = true;

                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
                return View(user);
            }
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using DataAccess.Context;
//using EFLayer.Class;

//namespace IKBlok.Controllers
//{
//    public class RegisterController : Controller
//    {
//        private readonly IKBlokContex _context;

//        public RegisterController(IKBlokContex context)
//        {
//            _context = context;
//        }

//        // GET: Register
//        public async Task<IActionResult> Index()
//        {
//              return _context.User != null ? 
//                          View(await _context.User.ToListAsync()) :
//                          Problem("Entity set 'IKBlokContex.User'  is null.");
//        }

//        // GET: Register/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.User == null)
//            {
//                return NotFound();
//            }

//            var user = await _context.User
//                .FirstOrDefaultAsync(m => m.UserId == id);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            return View(user);
//        }

//        // GET: Register/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Register/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("UserId,SurName,Name,UserAdi,Password")] User user)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(user);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(user);
//        }

//        // GET: Register/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.User == null)
//            {
//                return NotFound();
//            }

//            var user = await _context.User.FindAsync(id);
//            if (user == null)
//            {
//                return NotFound();
//            }
//            return View(user);
//        }

//        // POST: Register/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("UserId,SurName,Name,UserAdi,Password")] User user)
//        {
//            if (id != user.UserId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(user);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!UserExists(user.UserId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(user);
//        }

//        // GET: Register/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.User == null)
//            {
//                return NotFound();
//            }

//            var user = await _context.User
//                .FirstOrDefaultAsync(m => m.UserId == id);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            return View(user);
//        }

//        // POST: Register/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.User == null)
//            {
//                return Problem("Entity set 'IKBlokContex.User'  is null.");
//            }
//            var user = await _context.User.FindAsync(id);
//            if (user != null)
//            {
//                _context.User.Remove(user);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool UserExists(int id)
//        {
//          return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
//        }
//    }
//}
