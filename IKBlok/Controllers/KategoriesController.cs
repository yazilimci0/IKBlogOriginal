using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using EFLayer.Class;
using DataAccessLayer.EntittyFramework;
using BusinessLayer.Managment;
using BusinessLayer.ValidationRoles;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace IKBlok.Controllers
{
    public class KategoriesController : Controller
    {
        IKBlokContex _context=new IKBlokContex();
        KategoryManagment kt=new KategoryManagment(new EfKategoryRepo());

        // GET: Kategories
        public async Task<IActionResult> Index()
        {
              return _context.Kategories != null ? 
                          View(await _context.Kategories.ToListAsync()) :
                          Problem("Entity set 'IKBlokContex.Kategories'  is null.");
        }

        // GET: Kategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kategories == null)
            {
                return NotFound();
            }

            var kategories = await _context.Kategories
                .FirstOrDefaultAsync(m => m.kategoriId == id);
            if (kategories == null)
            {
                return NotFound();
            }

            return View(kategories);
        }

        // GET: Kategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("kategoriId,kategoryName")] Kategories kategories)
        {
            KategorisValidationRoles validationRules 
                = new KategorisValidationRoles();
            ValidationResult result = validationRules.Validate(kategories);

     

            if (result.IsValid)
            {
                kt.add(kategories);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    
                }

            }
            return View(kategories);




        }

        // GET: Kategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kategories == null)
            {
                return NotFound();
            }

            var kategories = await _context.Kategories.FindAsync(id);
            if (kategories == null)
            {
                return NotFound();
            }
            return View(kategories);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("kategoriId,kategoryName")] Kategories kategories)
        {
            if (id != kategories.kategoriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriesExists(kategories.kategoriId))
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
            return View(kategories);
        }

        // GET: Kategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kategories == null)
            {
                return NotFound();
            }

            var kategories = await _context.Kategories
                .FirstOrDefaultAsync(m => m.kategoriId == id);
            if (kategories == null)
            {
                return NotFound();
            }

            return View(kategories);
        }

        // POST: Kategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kategories == null)
            {
                return Problem("Entity set 'IKBlokContex.Kategories'  is null.");
            }
            var kategories = await _context.Kategories.FindAsync(id);
            if (kategories != null)
            {
                _context.Kategories.Remove(kategories);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriesExists(int id)
        {
          return (_context.Kategories?.Any(e => e.kategoriId == id)).GetValueOrDefault();
        }
    }
}
