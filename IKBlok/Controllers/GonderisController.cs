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
    public class GonderisController : Controller
    {
        IKBlokContex _context = new IKBlokContex();
        GonderiManagement py = new GonderiManagement(new EfGonderiRepo());
        // GET: UIGonderiler
        public async Task<IActionResult> Index()
        {
            return View(py.getAllListWithKategori());
        }
        public async Task<IActionResult> mainPageKategories(int id)
        {
            return View(py.getAllListWithKategori().Where(x => x.kategoriId == id).ToList());
        }
        //public async Task<IActionResult> SonGonderi()
        //{
        //    ViewData["songonderi"] = py.getWithLastPost();
        //    return View();
        //}
        // GET: UIGonderiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View(py.getAllListWithKategori().Where(x=> x.GonderiId == id).ToList());
        }

        // GET: UIGonderiler/Create
        public IActionResult Create()
        {
            ViewData["GonderiId"] = new SelectList(_context.Kategories, "kategoriId", "kategoryName");
            return View();
        }

        // POST: UIGonderiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GonderiId,GonderiName,GonderiBaslik,GonderiIcerik,GonderiResim,kategoryId")] Gonderiler gonderiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gonderiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GonderiId"] = new SelectList(_context.Kategories, "kategoriId", "kategoryName", gonderiler.GonderiId);
            return View(gonderiler);
        }

        // GET: UIGonderiler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gonderis == null)
            {
                return NotFound();
            }

            var gonderiler = await _context.Gonderis.FindAsync(id);
            if (gonderiler == null)
            {
                return NotFound();
            }
            ViewData["GonderiId"] = new SelectList(_context.Kategories, "kategoriId", "kategoryName", gonderiler.GonderiId);
            return View(gonderiler);
        }

        // POST: UIGonderiler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GonderiId,GonderiName,GonderiBaslik,GonderiIcerik,GonderiResim,kategoryId")] Gonderiler gonderiler)
        {
            if (id != gonderiler.GonderiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gonderiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GonderilerExists(gonderiler.GonderiId))
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
            ViewData["GonderiId"] = new SelectList(_context.Kategories, "kategoriId", "kategoryName", gonderiler.GonderiId);
            return View(gonderiler);
        }

        // GET: UIGonderiler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gonderis == null)
            {
                return NotFound();
            }

            var gonderiler = await _context.Gonderis
                .Include(g => g.Kategories)
                .FirstOrDefaultAsync(m => m.GonderiId == id);
            if (gonderiler == null)
            {
                return NotFound();
            }

            return View(gonderiler);
        }

        // POST: UIGonderiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gonderis == null)
            {
                return Problem("Entity set 'IKBlokContex.Gonderis'  is null.");
            }
            var gonderiler = await _context.Gonderis.FindAsync(id);
            if (gonderiler != null)
            {
                _context.Gonderis.Remove(gonderiler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GonderilerExists(int id)
        {
            return (_context.Gonderis?.Any(e => e.GonderiId == id)).GetValueOrDefault();
        }
    }
}
