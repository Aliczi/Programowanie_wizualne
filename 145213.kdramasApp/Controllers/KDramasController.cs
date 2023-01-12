using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _145213.kdramasApp.Models;
using Microsoft.AspNetCore.Components.Web;
using System.Numerics;

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
        public async Task<IActionResult> Index(string? SearchActors = null, string? sortTitle = null, string? sortStatus = null, string? sortDateTime = null, string? KDramaTitle = null, StatusType? DramaType = null)
        {
            //ViewData["NetworkIdViewData"] = new SelectList(_context.Networks, "Id", "OffcialName");
            //DbSet<KDrama> dataContext; //= _context.KDramas; //.Where(p => p.Title.Contains(KDramaTitle)); //.Where(p => p.Title != null);

            //var sl = new SelectList(_context.Actors, "Id", "Pseudonym");
            //ViewData["CastViewData"] = sl;
            //var oo = sl.Items;
            //foreach (var item in oo)
            //{
            //    Actor a = (Actor)item;
            //    if (a.KDramaId != null && SearchActors != null && a.KDramaId == Int32.Parse(SearchActors))
            //        nowaLista.Add(a.FirstName);

            ////}
            /////List<string> names = new List<string>() { "John", "Anna", "Monica" };
            /////var aktorzy = _context.Actors.Include(g => g.FirstName).Where(p => p.Pseudonym != null);

            var dramas = from s in _context.KDramas
                         select s;


            //filters
            if (DramaType != null)
            {
                dramas = dramas.Where(s => s.Status.Equals(DramaType));
            }

            if (!String.IsNullOrEmpty(KDramaTitle))
            {
                dramas = dramas.Where(s => s.Title.Contains(KDramaTitle));
            }
            //sorts
            if (!String.IsNullOrEmpty(sortTitle) && sortTitle.Equals("True"))
            {
                dramas = dramas.OrderBy(s => s.Title);
            }
            else
            {
                dramas = dramas.OrderByDescending(s => s.Title);
            }
            if (!String.IsNullOrEmpty(sortStatus) && sortStatus.Equals("True"))
            {
                dramas = dramas.OrderBy(s => s.Status);
            }
            if (!String.IsNullOrEmpty(sortDateTime) && sortDateTime.Equals("True"))
            {
                dramas = dramas.OrderBy(s => s.Data);
            }

            List<string> cast = new List<string> { };
            var sl = new SelectList(_context.Actors, "Id", "Pseudonym");
            foreach (var item in sl.Items)
            {
                Actor a = (Actor)item;
                if (a.KDramaId != null && SearchActors != null && a.KDramaId == Int32.Parse(SearchActors))
                    cast.Add(a.Pseudonym);

            }
            var result = String.Join(", ", cast.ToArray());
            ViewData["CastViewData"] = result;


            KDrama kd = dramas.Where(s => s.Title.Contains(KDramaTitle)).FirstOrDefault();
            if (kd != null)
            {
                List<Actor> actors = kd.Actors;
                if (actors != null)
                    ViewBag.CzyPusta =  actors.Count(); ;
            }
            else
            {
                ViewBag.CzyPusta = "Pusta";
            }

            return View(await dramas.ToListAsync());

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
            ViewData["NetworkIdViewData"] = new SelectList(_context.Networks, "Id", "OfficialName");
            return View();
        }

        // POST: KDramas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Data,Status,NetworkId")] KDrama kDrama)
        {
            if (ModelState.IsValid)
            {
                //var networks = from s in _context.Networks
                //             select s;
                //Network n = networks.Where(n => n.OfficialName.Contains("tv")).FirstOrDefault();
                //if (n != null)
                //{
                //    n.KDramas.Add(kDrama);
                //}
                

                _context.Add(kDrama);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NetworkIdViewData"] = new SelectList(_context.Networks, "Id", "Id", kDrama.NetworkId );
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
            //ViewData["NetworkIdViewData"] = new SelectList(_context.Networks, "Id", "OffcialName");
            return View(kDrama);
        }

        // POST: KDramas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Status")] KDrama kDrama)
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
            //ViewData["NetworkIdViewData"] = new SelectList(_context.Networks, "Id", "OffcialName");
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
