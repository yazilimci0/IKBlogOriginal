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
    public class HakkimdasController : Controller
    {
        IKBlokContex _context = new IKBlokContex();
        HakkimdaManagment hk = new HakkimdaManagment(new EfHakkimdaRepo());

        // GET: Hakkimdas
        public async Task<IActionResult> Index()
        {
              return _context.Hakkimdas != null ? 
                          View(await _context.Hakkimdas.ToListAsync()) :
                          Problem("Entity set 'IKBlokContex.Hakkimdas'  is null.");
        }

        // GET: Hakkimdas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hakkimdas == null)
            {
                return NotFound();
            }

            var hakkimda = await _context.Hakkimdas
                .FirstOrDefaultAsync(m => m.hakkimdaId == id);
            if (hakkimda == null)
            {
                return NotFound();
            }

            return View(hakkimda);
        }

        // GET: Hakkimdas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hakkimdas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hakkimdaId,baslik,icerik,resimLinki")] Hakkimda hakkimda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hakkimda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hakkimda);
        }

        // GET: Hakkimdas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hakkimdas == null)
            {
                return NotFound();
            }

            var hakkimda = await _context.Hakkimdas.FindAsync(id);
            if (hakkimda == null)
            {
                return NotFound();
            }
            return View(hakkimda);
        }

        // POST: Hakkimdas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("hakkimdaId,baslik,icerik,resimLinki")] Hakkimda hakkimda)
        {
            if (id != hakkimda.hakkimdaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hakkimda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HakkimdaExists(hakkimda.hakkimdaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hakkimda);
        }

        // GET: Hakkimdas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hakkimdas == null)
            {
                return NotFound();
            }

            var hakkimda = await _context.Hakkimdas
                .FirstOrDefaultAsync(m => m.hakkimdaId == id);
            if (hakkimda == null)
            {
                return NotFound();
            }

            return View(hakkimda);
        }

        // POST: Hakkimdas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hakkimdas == null)
            {
                return Problem("Entity set 'IKBlokContex.Hakkimdas'  is null.");
            }
            var hakkimda = await _context.Hakkimdas.FindAsync(id);
            if (hakkimda != null)
            {
                _context.Hakkimdas.Remove(hakkimda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HakkimdaExists(int id)
        {
          return (_context.Hakkimdas?.Any(e => e.hakkimdaId == id)).GetValueOrDefault();
        }
    }
}
