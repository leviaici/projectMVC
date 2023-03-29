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
    public class PescatarianController : Controller
    {
        private readonly MvcPescatarianContext _context;

        public PescatarianController(MvcPescatarianContext context)
        {
            _context = context;
        }

        // GET: Pescatarian
        public async Task<IActionResult> Index(string dishType, string searchString)
        {
            if (_context.Pescatarian == null)
            {
                return Problem("Entity set 'MvcMovieContext.Pescatarian'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> typeQuery = from m in _context.Pescatarian
                                           orderby m.Type
                                           select m.Type;
            var pescatarian = from m in _context.Pescatarian
                           select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                pescatarian = pescatarian.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(dishType))
            {
                pescatarian = pescatarian.Where(x => x.Type == dishType);
            }

            var dishTypeVM = new PescatarianTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Pescatarians = await pescatarian.ToListAsync()
            };

            return View(dishTypeVM);
        }

        // GET: Pescatarian/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pescatarian == null)
            {
                return NotFound();
            }

            var pescatarian = await _context.Pescatarian
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pescatarian == null)
            {
                return NotFound();
            }

            return View(pescatarian);
        }

        // GET: Pescatarian/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pescatarian/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price,Rating")] Pescatarian pescatarian, String PasswordString)
        {
            if (PasswordString != "admin")
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Add(pescatarian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pescatarian);
        }

        // GET: Pescatarian/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pescatarian == null)
            {
                return NotFound();
            }

            var pescatarian = await _context.Pescatarian.FindAsync(id);
            if (pescatarian == null)
            {
                return NotFound();
            }
            return View(pescatarian);
        }

        // POST: Pescatarian/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price,Rating")] Pescatarian pescatarian, String PasswordString)
        {
            if (PasswordString != "admin")
            {
                return NotFound();
            }

            if (id != pescatarian.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pescatarian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PescatarianExists(pescatarian.Id))
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
            return View(pescatarian);
        }

        // GET: Pescatarian/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pescatarian == null)
            {
                return NotFound();
            }

            var pescatarian = await _context.Pescatarian
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pescatarian == null)
            {
                return NotFound();
            }

            return View(pescatarian);
        }

        // POST: Pescatarian/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pescatarian == null)
            {
                return Problem("Entity set 'MvcPescatarianContext.Pescatarian'  is null.");
            }
            var pescatarian = await _context.Pescatarian.FindAsync(id);
            if (pescatarian != null)
            {
                _context.Pescatarian.Remove(pescatarian);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PescatarianExists(int id)
        {
          return (_context.Pescatarian?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
