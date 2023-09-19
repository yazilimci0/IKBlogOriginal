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
    public class AdminGonderilerController : Controller
    {

        GonderiManagement gn = new GonderiManagement(new EfGonderiRepo());
        KategoryManagment kt = new KategoryManagment(new EfKategoryRepo());

        // GET: AdminGonderiler

        public async Task<IActionResult> Index()
        {
            return View(gn.getAllList());
        }


		public async Task<IActionResult> Edit(int id)
		{
            ViewData["kategoriId"] = new SelectList(kt.getAllList(), "kategoriId", "kategoryName");
            return View(gn.getCategoryById(id));


        }

        //public async Task<IActionResult> Edit(int? id)
        //      {
        //          return View();
        //      }

        // GET: AdminGonderiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            

            return View();
        }

        // GET: AdminGonderiler/Create
        //private SelectList Kategoriler
        //{
        //    get
        //    {
        //        return new SelectList(kt.getAllList(), "kategoriId", "kategoryName");

        //    }
        //}

        public IActionResult Create()
        {


            ViewData["kategoriId"] = new SelectList(kt.getAllList(), "kategoriId", "kategoryName");

            return View();
        }

        // POST: AdminGonderiler/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gonderiler gonderiler)
        {
            if (ModelState.IsValid)
            {
                gn.add(gonderiler);

                return RedirectToAction(nameof(Index));

            }
            return View(gonderiler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("GonderiId,GonderiName,GonderiBaslik,GonderiIcerik,GonderiResim,kategoriId")] Gonderiler gonderiler)
        {
            if (ModelState.IsValid)
            {
                gn.update(gonderiler);
                return RedirectToAction(nameof(Index));
            }
            return View(gonderiler);

            //ViewData["GonderiId"] = new SelectList(_context.Kategories, "kategoriId", "kategoryName", gonderiler.GonderiId);
            //return View(gonderiler);

        }

        // GET: AdminGonderiler/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(gn.getCategoryById(id));
       
        

        }

        // POST: AdminGonderiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> DeleteConfirmed(Gonderiler gonderiler)
        {

            gn.remove(gonderiler);
            return RedirectToAction(nameof(Index));
        }


    }
}
