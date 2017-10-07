using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab18DatabaseRelation.Data;
using Lab18DatabaseRelation.Models;

namespace Lab18DatabaseRelation.Controllers
{
    public class TravelItemsController : Controller
    {
        private readonly Lab18DatabaseRelationContext _context;

        public TravelItemsController(Lab18DatabaseRelationContext context)
        {
            _context = context;
        }

        // GET: TravelItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.TravelItems.ToListAsync());
        }

        // GET: TravelItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelItem = await _context.TravelItems
                .SingleOrDefaultAsync(m => m.ID == id);
            if (travelItem == null)
            {
                return NotFound();
            }

            return View(travelItem);
        }

        // GET: TravelItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TravelItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ItemName")] TravelItem travelItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelItem);
        }

        // GET: TravelItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelItem = await _context.TravelItems.SingleOrDefaultAsync(m => m.ID == id);
            if (travelItem == null)
            {
                return NotFound();
            }
            return View(travelItem);
        }

        // POST: TravelItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ItemName")] TravelItem travelItem)
        {
            if (id != travelItem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelItemExists(travelItem.ID))
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
            return View(travelItem);
        }

        // GET: TravelItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelItem = await _context.TravelItems
                .SingleOrDefaultAsync(m => m.ID == id);
            if (travelItem == null)
            {
                return NotFound();
            }

            return View(travelItem);
        }

        // POST: TravelItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelItem = await _context.TravelItems.SingleOrDefaultAsync(m => m.ID == id);
            _context.TravelItems.Remove(travelItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelItemExists(int id)
        {
            return _context.TravelItems.Any(e => e.ID == id);
        }
    }
}
