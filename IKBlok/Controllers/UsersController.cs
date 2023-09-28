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
using Microsoft.AspNetCore.Authorization;

namespace IKBlok.Controllers
{

	[Yetki]

	public class UsersController : Controller
    {
		UserManagment us = new UserManagment(new EfUserRepo());
		public async Task<IActionResult> Index()
        {
			return View(us.getAllList());
		}

       
       
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

        public async Task<IActionResult> Delete(int id)
        {
			return View(us.getCategoryById(id));
		}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(User user)
        {
			us.remove(user);
			return RedirectToAction(nameof(Index));
		}

        
    }
}
