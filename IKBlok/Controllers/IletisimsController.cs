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
    public class IletisimsController : Controller
    {
        IKBlokContex _context = new IKBlokContex();
        IletisimManagment il = new IletisimManagment(new EfIletisimRepo());

        // GET: Iletisims
        public async Task<IActionResult> Index()
        {
              return _context.Iletisims != null ? 
                          View(await _context.Iletisims.ToListAsync()) :
                          Problem("Entity set 'IKBlokContex.Iletisims'  is null.");
        }

        // GET: Iletisims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Iletisims == null)
            {
                return NotFound();
            }

            var iletisim = await _context.Iletisims
                .FirstOrDefaultAsync(m => m.IletisimId == id);
            if (iletisim == null)
            {
                return NotFound();
            }

            return View(iletisim);
        }

        // GET: Iletisims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Iletisims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IletisimId,AdSoyad,Mail,Telefon")] Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iletisim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iletisim);
        }

        // GET: Iletisims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Iletisims == null)
            {
                return NotFound();
            }

            var iletisim = await _context.Iletisims.FindAsync(id);
            if (iletisim == null)
            {
                return NotFound();
            }
            return View(iletisim);
        }

        // POST: Iletisims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IletisimId,AdSoyad,Mail,Telefon")] Iletisim iletisim)
        {
            if (id != iletisim.IletisimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iletisim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IletisimExists(iletisim.IletisimId))
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
            return View(iletisim);
        }

        // GET: Iletisims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Iletisims == null)
            {
                return NotFound();
            }

            var iletisim = await _context.Iletisims
                .FirstOrDefaultAsync(m => m.IletisimId == id);
            if (iletisim == null)
            {
                return NotFound();
            }

            return View(iletisim);
        }

        // POST: Iletisims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Iletisims == null)
            {
                return Problem("Entity set 'IKBlokContex.Iletisims'  is null.");
            }
            var iletisim = await _context.Iletisims.FindAsync(id);
            if (iletisim != null)
            {
                _context.Iletisims.Remove(iletisim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IletisimExists(int id)
        {
          return (_context.Iletisims?.Any(e => e.IletisimId == id)).GetValueOrDefault();
        }
    }
}
