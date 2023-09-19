using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using EFLayer.Class;
using BusinessLayer.Managment;
using DataAccessLayer.EntittyFramework;

namespace IKBlok.Controllers
{
    public class UsersController : Controller
    {
		UserManagment us = new UserManagment(new EfUserRepo());
		// GET: Users
		public async Task<IActionResult> Index()
        {
			return View(us.getAllList());
		}

       
       
        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,SurName,Name,UserAdi,Password,RoleId")] User user)
        {
			if (ModelState.IsValid)
			{
				us.add(user);
				return RedirectToAction(nameof(Index));
			}
			return View(user);
		}

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
			return View(us.getCategoryById(id));
		}

    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,SurName,Name,UserAdi,Password,RoleId")] User user)
        {
			if (ModelState.IsValid)
			{
				us.update(user);
				return RedirectToAction(nameof(Index));
			}
			return View(user);
		}

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
			return View(us.getCategoryById(id));
		}

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(User user)
        {
			us.remove(user);
			return RedirectToAction(nameof(Index));
		}

        
    }
}
