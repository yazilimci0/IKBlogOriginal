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
    public class AdminKategorilerController : Controller
    {
		
		KategoryManagment kt = new KategoryManagment(new EfKategoryRepo());


		// GET: AdminKategoriler
		public async Task<IActionResult> Index()
        {
              return View(kt.getAllList());
        }

    

        // GET: AdminKategoriler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminKategoriler/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Kategories kategories)
        {
            if (ModelState.IsValid)
            {
                kt.add(kategories);
                return RedirectToAction(nameof(Index));
            }
            return View(kategories);
        }

		//GET: AdminKategoriler/Edit/5
		//public async Task<IActionResult> Edit(int id)
		//{

		//    return View(kt.getCategoryById(id));
		//}
		public async Task<IActionResult> Edit(int id)
		{

			return View(kt.getCategoryById(id));
		}

		// POST: AdminKategoriler/Edit/5

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("kategoriId,kategoryName")] Kategories kategories)
        {

			if (ModelState.IsValid)
			{
				kt.update(kategories);
				return RedirectToAction(nameof(Index));
			}
			return View(kategories);
			//if (id != kategories.kategoriId)
			//{
			//    return NotFound();
			//}

			//if (ModelState.IsValid)
			//{
			//    try
			//    {
			//        _context.Update(kategories);
			//        await _context.SaveChangesAsync();
			//    }
			//    catch (DbUpdateConcurrencyException)
			//    {
			//        if (!KategoriesExists(kategories.kategoriId))
			//        {
			//            return NotFound();
			//        }
			//        else
			//        {
			//            throw;
			//        }
			//    }
			//    return RedirectToAction(nameof(Index));
			//}
			//return View(kategories);
			

        }

        // GET: AdminKategoriler/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
			return View(kt.getCategoryById(id));
			//if (id == null || _context.Kategories == null)
			//{
			//    return NotFound();
			//}

			//var kategories = await _context.Kategories
			//    .FirstOrDefaultAsync(m => m.kategoriId == id);
			//if (kategories == null)
			//{
			//    return NotFound();
			//}

			//return View(kategories);
		
		}

        // POST: AdminKategoriler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Kategories kategories)
        {
			
				kt.remove(kategories);
				return RedirectToAction(nameof(Index));
			

			//if (_context.Kategories == null)
			//{
			//    return Problem("Entity set 'IKBlokContex.Kategories'  is null.");
			//}
			//var kategories = await _context.Kategories.FindAsync(id);
			//if (kategories != null)
			//{
			//    _context.Kategories.Remove(kategories);
			//}

			//await _context.SaveChangesAsync();
			//return RedirectToAction(nameof(Index));
			
		}

    }
}
