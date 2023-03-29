using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using incercareProiect.Models;
using MvcMovie.Models;

namespace incercareProiect.Controllers
{
    public class OmnivoreController : Controller
    {
        private readonly MvcOmnivoreContext _context;

        public OmnivoreController(MvcOmnivoreContext context)
        {
            _context = context;
        }

        // GET: Omnivore
        public async Task<IActionResult> Index(string dishType, string searchString)
        {
            if (_context.Omnivore == null)
            {
                return Problem("Entity set 'MvcMovieContext.Omnivore'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> typeQuery = from m in _context.Omnivore
                                            orderby m.Type
                                            select m.Type;
            var omnivore = from m in _context.Omnivore
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                omnivore = omnivore.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(dishType))
            {
                omnivore = omnivore.Where(x => x.Type == dishType);
            }

            var dishTypeVM = new OmnivoreTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Omnivores = await omnivore.ToListAsync()
            };

            return View(dishTypeVM);
        }

        // GET: Omnivore/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Omnivore == null)
            {
                return NotFound();
            }

            var omnivore = await _context.Omnivore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (omnivore == null)
            {
                return NotFound();
            }

            return View(omnivore);
        }

        // GET: Omnivore/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Omnivore/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price,Rating")] Omnivore omnivore, String PasswordString)
        {
            if (PasswordString != "admin")
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Add(omnivore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(omnivore);
        }

        // GET: Omnivore/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Omnivore == null)
            {
                return NotFound();
            }

            var omnivore = await _context.Omnivore.FindAsync(id);
            if (omnivore == null)
            {
                return NotFound();
            }
            return View(omnivore);
        }

        // POST: Omnivore/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price,Rating")] Omnivore omnivore, String PasswordString)
        {
            if (PasswordString != "admin")
            {
                return NotFound();
            }

            if (id != omnivore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(omnivore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OmnivoreExists(omnivore.Id))
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
            return View(omnivore);
        }

        // GET: Omnivore/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Omnivore == null)
            {
                return NotFound();
            }

            var omnivore = await _context.Omnivore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (omnivore == null)
            {
                return NotFound();
            }

            return View(omnivore);
        }

        // POST: Omnivore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Omnivore == null)
            {
                return Problem("Entity set 'MvcOmnivoreContext.Omnivore'  is null.");
            }
            var omnivore = await _context.Omnivore.FindAsync(id);
            if (omnivore != null)
            {
                _context.Omnivore.Remove(omnivore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OmnivoreExists(int id)
        {
          return (_context.Omnivore?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
