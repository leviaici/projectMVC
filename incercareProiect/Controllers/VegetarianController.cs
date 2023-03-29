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
    public class VegetarianController : Controller
    {
        private readonly MvcVegetarianContext _context;

        public VegetarianController(MvcVegetarianContext context)
        {
            _context = context;
        }

        // GET: Vegetarian
        public async Task<IActionResult> Index(string dishType, string searchString)
        {
            if (_context.Vegetarian == null)
            {
                return Problem("Entity set 'MvcMovieContext.Omnivore'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> typeQuery = from m in _context.Vegetarian
                                           orderby m.Type
                                           select m.Type;
            var vegetarian = from m in _context.Vegetarian
                           select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                vegetarian = vegetarian.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(dishType))
            {
                vegetarian = vegetarian.Where(x => x.Type == dishType);
            }

            var dishTypeVM = new VegetarianTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Vegetarians = await vegetarian.ToListAsync()
            };

            return View(dishTypeVM);
        }

        // GET: Vegetarian/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vegetarian == null)
            {
                return NotFound();
            }

            var vegetarian = await _context.Vegetarian
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vegetarian == null)
            {
                return NotFound();
            }

            return View(vegetarian);
        }

        // GET: Vegetarian/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vegetarian/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price,Rating")] Vegetarian vegetarian, String PasswordString)
        {
            if (PasswordString != "admin")
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Add(vegetarian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vegetarian);
        }

        // GET: Vegetarian/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vegetarian == null)
            {
                return NotFound();
            }

            var vegetarian = await _context.Vegetarian.FindAsync(id);
            if (vegetarian == null)
            {
                return NotFound();
            }
            return View(vegetarian);
        }

        // POST: Vegetarian/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price,Rating")] Vegetarian vegetarian, String PasswordString)
        {
            if (PasswordString != "admin")
            {
                return NotFound();
            }

            if (id != vegetarian.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vegetarian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VegetarianExists(vegetarian.Id))
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
            return View(vegetarian);
        }

        // GET: Vegetarian/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vegetarian == null)
            {
                return NotFound();
            }

            var vegetarian = await _context.Vegetarian
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vegetarian == null)
            {
                return NotFound();
            }

            return View(vegetarian);
        }

        // POST: Vegetarian/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vegetarian == null)
            {
                return Problem("Entity set 'MvcVegetarianContext.Vegetarian'  is null.");
            }
            var vegetarian = await _context.Vegetarian.FindAsync(id);
            if (vegetarian != null)
            {
                _context.Vegetarian.Remove(vegetarian);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VegetarianExists(int id)
        {
          return (_context.Vegetarian?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
