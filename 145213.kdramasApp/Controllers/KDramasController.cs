using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _145213.kdramasApp.Models;

namespace _145213.kdramasApp.Controllers
{
    public class KDramasController : Controller
    {
        private readonly DataContext _context;

        public KDramasController(DataContext context)
        {
            _context = context;
        }

        // GET: KDramas
        public async Task<IActionResult> Index()
        {
            return View(await _context.KDramas.ToListAsync());
        }

        // GET: KDramas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KDramas == null)
            {
                return NotFound();
            }

            var kDrama = await _context.KDramas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kDrama == null)
            {
                return NotFound();
            }

            return View(kDrama);
        }

        // GET: KDramas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KDramas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] KDrama kDrama)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kDrama);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kDrama);
        }

        // GET: KDramas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KDramas == null)
            {
                return NotFound();
            }

            var kDrama = await _context.KDramas.FindAsync(id);
            if (kDrama == null)
            {
                return NotFound();
            }
            return View(kDrama);
        }

        // POST: KDramas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] KDrama kDrama)
        {
            if (id != kDrama.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kDrama);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KDramaExists(kDrama.Id))
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
            return View(kDrama);
        }

        // GET: KDramas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KDramas == null)
            {
                return NotFound();
            }

            var kDrama = await _context.KDramas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kDrama == null)
            {
                return NotFound();
            }

            return View(kDrama);
        }

        // POST: KDramas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KDramas == null)
            {
                return Problem("Entity set 'DataContext.KDramas'  is null.");
            }
            var kDrama = await _context.KDramas.FindAsync(id);
            if (kDrama != null)
            {
                _context.KDramas.Remove(kDrama);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KDramaExists(int id)
        {
            return _context.KDramas.Any(e => e.Id == id);
        }
    }
}
