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
    //[Yetki]
    public class AdminGonderilerController : Controller
    {

        GonderiManagement gn = new GonderiManagement(new EfGonderiRepo());
        KategoryManagment kt = new KategoryManagment(new EfKategoryRepo());

        // GET: AdminGonderiler
        
        public async Task<IActionResult> Index()
        {
            return View(gn.getAllList());
        }



        // GET: AdminGonderiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.Gonderis == null)
            //{
            //    return NotFound();
            //}

            //var gonderiler = await _context.Gonderis
            //    .Include(g => g.Kategories)
            //    .FirstOrDefaultAsync(m => m.GonderiId == id);
            //if (gonderiler == null)
            //{
            //    return NotFound();
            //}

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


        //public IActionResult Create()
        //{
        //	return View();

        //}


        // POST: AdminGonderiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        // GET: AdminGonderiler/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{

        //	//if (id == null || _context.Gonderis == null)
        //	//{
        //	//    return NotFound();
        //	//}

        //	//var gonderiler = await _context.Gonderis.FindAsync(id);
        //	//if (gonderiler == null)
        //	//{
        //	//    return NotFound();
        //	//}
        //	//ViewData["GonderiId"] = new SelectList(_context.Kategories, "kategoriId", "kategoryName", gonderiler.GonderiId);

        //}

        // POST: AdminGonderiler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GonderiId,GonderiName,GonderiBaslik,GonderiIcerik,GonderiResim,kategoriId")] Gonderiler gonderiler)
        {
            if (ModelState.IsValid)
            {
                gn.update(gonderiler);
                return RedirectToAction(nameof(Index));
            }
            return View(gonderiler);



            //if (id != gonderiler.GonderiId)
            //{
            //	return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //	try
            //	{
            //		_context.Update(gonderiler);
            //		await _context.SaveChangesAsync();
            //	}
            //	catch (DbUpdateConcurrencyException)
            //	{
            //		if (!GonderilerExists(gonderiler.GonderiId))
            //		{
            //			return NotFound();
            //		}
            //		else
            //		{
            //			throw;
            //		}
            //	}
            //	return RedirectToAction(nameof(Index));
            //}
            //ViewData["GonderiId"] = new SelectList(_context.Kategories, "kategoriId", "kategoryName", gonderiler.GonderiId);
            //return View(gonderiler);

        }

        // GET: AdminGonderiler/Delete/5
        public async Task<IActionResult> Delete(int id,Gonderiler gonderiler)
        {

			if (ModelState.IsValid)
			{
				gn.remove(gonderiler);
				return RedirectToAction(nameof(Index));
			}
			return View(gonderiler);
			//if (id == null || _context.Gonderis == null)
			//{
			//	return NotFound();
			//}

			//var gonderiler = await _context.Gonderis
			//	.Include(g => g.Kategories)
			//	.FirstOrDefaultAsync(m => m.GonderiId == id);
			//if (gonderiler == null)
			//{
			//	return NotFound();
			//}

			return View();
        }

        // POST: AdminGonderiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,Gonderiler gonderiler)
        {


			if (ModelState.IsValid)
			{
				gn.remove(gonderiler);
				return RedirectToAction(nameof(Index));
			}
			return View(gonderiler);

			//if (_context.Gonderis == null)
			//{
			//    return Problem("Entity set 'IKBlokContex.Gonderis'  is null.");
			//}
			//var gonderiler = await _context.Gonderis.FindAsync(id);
			//if (gonderiler != null)
			//{
			//    _context.Gonderis.Remove(gonderiler);
			//}

			//await _context.SaveChangesAsync();
			//return RedirectToAction(nameof(Index));

		}

    }
}
