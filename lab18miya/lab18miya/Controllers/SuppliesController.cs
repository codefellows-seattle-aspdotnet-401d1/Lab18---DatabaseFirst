using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab18miya.Models;

namespace lab18miya.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly lab18miyaContext _context;

        public SuppliesController(lab18miyaContext context)
        {
            _context = context;
        }

        // GET: Supplies
        public async Task<IActionResult> Index()
        {
            var lab18miyaContext = _context.Supplies.Include(s => s.Weather);
            return View(await lab18miyaContext.ToListAsync());
        }

        // GET: Supplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplies = await _context.Supplies
                .Include(s => s.Weather)
                .SingleOrDefaultAsync(m => m.SupplyID == id);
            if (supplies == null)
            {
                return NotFound();
            }

            return View(supplies);
        }

        // GET: Supplies/Create
        public IActionResult Create()
        {
            ViewData["WeatherID"] = new SelectList(_context.Set<Weather>(), "WeatherID", "WeatherID");
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplyID,Name,Quantity,WeatherID")] Supplies supplies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WeatherID"] = new SelectList(_context.Set<Weather>(), "WeatherID", "WeatherID", supplies.WeatherID);
            return View(supplies);
        }

        // GET: Supplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplies = await _context.Supplies.SingleOrDefaultAsync(m => m.SupplyID == id);
            if (supplies == null)
            {
                return NotFound();
            }
            ViewData["WeatherID"] = new SelectList(_context.Set<Weather>(), "WeatherID", "WeatherID", supplies.WeatherID);
            return View(supplies);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplyID,Name,Quantity,WeatherID")] Supplies supplies)
        {
            if (id != supplies.SupplyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuppliesExists(supplies.SupplyID))
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
            ViewData["WeatherID"] = new SelectList(_context.Set<Weather>(), "WeatherID", "WeatherID", supplies.WeatherID);
            return View(supplies);
        }

        // GET: Supplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplies = await _context.Supplies
                .Include(s => s.Weather)
                .SingleOrDefaultAsync(m => m.SupplyID == id);
            if (supplies == null)
            {
                return NotFound();
            }

            return View(supplies);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplies = await _context.Supplies.SingleOrDefaultAsync(m => m.SupplyID == id);
            _context.Supplies.Remove(supplies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuppliesExists(int id)
        {
            return _context.Supplies.Any(e => e.SupplyID == id);
        }
    }
}
