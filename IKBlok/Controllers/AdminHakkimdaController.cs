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
    public class AdminHakkimdaController : Controller
    {
        
        HakkimdaManagment hk = new HakkimdaManagment(new EfHakkimdaRepo());
        // GET: AdminHakkimda
        
        public async Task<IActionResult> Index()
        {
			return View(hk.getAllList());
		}

        // GET: AdminHakkimda/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Hakkimdas == null)
        //    {
        //        return NotFound();
        //    }

        //    var hakkimda = await _context.Hakkimdas
        //        .FirstOrDefaultAsync(m => m.hakkimdaId == id);
        //    if (hakkimda == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hakkimda);
        //}

        // GET: AdminHakkimda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminHakkimda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hakkimdaId,baslik,icerik,resimLinki")] Hakkimda hakkimda)
        {
            if (ModelState.IsValid)
            {
                hk.add(hakkimda);
				return RedirectToAction(nameof(Index));
			}
            return View(hakkimda);
        }

        // GET: AdminHakkimda/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
			return View(hk.getCategoryById(id));


			//if (id == null || _context.Hakkimdas == null)
			//{
			//    return NotFound();
			//}

			//var hakkimda = await _context.Hakkimdas.FindAsync(id);
			//if (hakkimda == null)
			//{
			//    return NotFound();
			//}
			//return View(hakkimda);
		}

        // POST: AdminHakkimda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("hakkimdaId,baslik,icerik,resimLinki")] Hakkimda hakkimda)
        {
			if (ModelState.IsValid)
			{
				hk.update(hakkimda);
				return RedirectToAction(nameof(Index));
			}
			return View(hakkimda);




			//if (id != hakkimda.hakkimdaId)
			//{
			//    return NotFound();
			//}

			//if (ModelState.IsValid)
			//{
			//    try
			//    {
			//        _context.Update(hakkimda);
			//        await _context.SaveChangesAsync();
			//    }
			//    catch (DbUpdateConcurrencyException)
			//    {
			//        if (!HakkimdaExists(hakkimda.hakkimdaId))
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
			//return View(hakkimda);
		}

        //// GET: AdminHakkimda/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Hakkimdas == null)
        //    {
        //        return NotFound();
        //    }

        //    var hakkimda = await _context.Hakkimdas
        //        .FirstOrDefaultAsync(m => m.hakkimdaId == id);
        //    if (hakkimda == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hakkimda);
        //}

        // POST: AdminHakkimda/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Hakkimdas == null)
        //    {
        //        return Problem("Entity set 'IKBlokContex.Hakkimdas'  is null.");
        //    }
        //    var hakkimda = await _context.Hakkimdas.FindAsync(id);
        //    if (hakkimda != null)
        //    {
        //        _context.Hakkimdas.Remove(hakkimda);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

      
    }
}
