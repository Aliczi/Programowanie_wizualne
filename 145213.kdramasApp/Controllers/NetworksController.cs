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
    public class NetworksController : Controller
    {
        private readonly DataContext _context;

        public NetworksController(DataContext context)
        {
            _context = context;
        }

        // GET: Networks
        public async Task<IActionResult> Index()
        {


            var networks = from s in _context.Networks
                         select s;
            return View(await networks.ToListAsync());
        }

        // GET: Networks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Networks == null)
            {
                return NotFound();
            }

            var network = await _context.Networks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (network == null)
            {
                return NotFound();
            }

            return View(network);
        }

        // GET: Networks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Networks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OfficialName,Residence,Owner,Broadcast,Language")] Network network)
        {
            if (ModelState.IsValid)
            {
                _context.Add(network);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(network);
        }

        // GET: Networks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Networks == null)
            {
                return NotFound();
            }

            var network = await _context.Networks.FindAsync(id);
            if (network == null)
            {
                return NotFound();
            }
            return View(network);
        }

        // POST: Networks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OfficialName,Residence,Owner,Broadcast,Language")] Network network)
        {
            if (id != network.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(network);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NetworkExists(network.Id))
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
            return View(network);
        }

        // GET: Networks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Networks == null)
            {
                return NotFound();
            }

            var network = await _context.Networks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (network == null)
            {
                return NotFound();
            }

            return View(network);
        }

        // POST: Networks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Networks == null)
            {
                return Problem("Entity set 'DataContext.Networks'  is null.");
            }
            var network = await _context.Networks.FindAsync(id);
            if (network != null)
            {
                _context.Networks.Remove(network);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NetworkExists(int id)
        {
          return _context.Networks.Any(e => e.Id == id);
        }
    }
}
