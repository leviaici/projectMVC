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
    public class VeganController : Controller
    {
        private readonly MvcVeganContext _context;

        public VeganController(MvcVeganContext context)
        {
            _context = context;
        }

        // GET: Vegan
        public async Task<IActionResult> Index(string dishType, string searchString)
        {
            if (_context.Vegan == null)
            {
                return Problem("Entity set 'MvcMovieContext.Vegan'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> typeQuery = from m in _context.Vegan
                                           orderby m.Type
                                           select m.Type;
            var vegan = from m in _context.Vegan
                           select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                vegan = vegan.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(dishType))
            {
                vegan = vegan.Where(x => x.Type == dishType);
            }

            var dishTypeVM = new VeganTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Vegans = await vegan.ToListAsync()
            };

            return View(dishTypeVM);
        }

        // GET: Vegan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vegan == null)
            {
                return NotFound();
            }

            var vegan = await _context.Vegan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vegan == null)
            {
                return NotFound();
            }

            return View(vegan);
        }

        // GET: Vegan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vegan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price,Rating")] Vegan vegan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vegan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vegan);
        }

        // GET: Vegan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vegan == null)
            {
                return NotFound();
            }

            var vegan = await _context.Vegan.FindAsync(id);
            if (vegan == null)
            {
                return NotFound();
            }
            return View(vegan);
        }

        // POST: Vegan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price,Rating")] Vegan vegan)
        {
            if (id != vegan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vegan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeganExists(vegan.Id))
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
            return View(vegan);
        }

        // GET: Vegan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vegan == null)
            {
                return NotFound();
            }

            var vegan = await _context.Vegan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vegan == null)
            {
                return NotFound();
            }

            return View(vegan);
        }

        // POST: Vegan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vegan == null)
            {
                return Problem("Entity set 'MvcVeganContext.Vegan'  is null.");
            }
            var vegan = await _context.Vegan.FindAsync(id);
            if (vegan != null)
            {
                _context.Vegan.Remove(vegan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeganExists(int id)
        {
          return (_context.Vegan?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
