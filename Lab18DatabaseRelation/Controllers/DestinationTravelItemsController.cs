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
    public class DestinationTravelItemsController : Controller
    {
        private readonly Lab18DatabaseRelationContext _context;

        public DestinationTravelItemsController(Lab18DatabaseRelationContext context)
        {
            _context = context;
        }

        // GET: DestinationTravelItems
        public async Task<IActionResult> Index()
        {
            var lab18DatabaseRelationContext = _context.DestinationTravelItem.Include(d => d.Destination).Include(d => d.TravelItem);
            return View(await lab18DatabaseRelationContext.ToListAsync());
        }

        // GET: DestinationTravelItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationTravelItem = await _context.DestinationTravelItem
                .Include(d => d.Destination)
                .Include(d => d.TravelItem)
                .SingleOrDefaultAsync(m => m.DestinationID == id);
            if (destinationTravelItem == null)
            {
                return NotFound();
            }

            return View(destinationTravelItem);
        }

        // GET: DestinationTravelItems/Create
        public IActionResult Create()
        {
            ViewData["DestinationID"] = new SelectList(_context.Destinations, "ID", "LocationName");
            ViewData["TravelItemID"] = new SelectList(_context.TravelItems, "ID", "ItemName");
            return View();
        }

        // POST: DestinationTravelItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DestinationID,TravelItemID")] DestinationTravelItem destinationTravelItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinationTravelItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinationID"] = new SelectList(_context.Destinations, "ID", "LocationName", destinationTravelItem.DestinationID);
            ViewData["TravelItemID"] = new SelectList(_context.TravelItems, "ID", "ItemName", destinationTravelItem.TravelItemID);
            return View(destinationTravelItem);
        }

        // GET: DestinationTravelItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationTravelItem = await _context.DestinationTravelItem.SingleOrDefaultAsync(m => m.DestinationID == id);
            if (destinationTravelItem == null)
            {
                return NotFound();
            }
            ViewData["DestinationID"] = new SelectList(_context.Destinations, "ID", "LocationName", destinationTravelItem.DestinationID);
            ViewData["TravelItemID"] = new SelectList(_context.TravelItems, "ID", "ItemName", destinationTravelItem.TravelItemID);
            return View(destinationTravelItem);
        }

        // POST: DestinationTravelItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DestinationID,TravelItemID")] DestinationTravelItem destinationTravelItem)
        {
            if (id != destinationTravelItem.DestinationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinationTravelItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationTravelItemExists(destinationTravelItem.DestinationID))
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
            ViewData["DestinationID"] = new SelectList(_context.Destinations, "ID", "LocationName", destinationTravelItem.DestinationID);
            ViewData["TravelItemID"] = new SelectList(_context.TravelItems, "ID", "ItemName", destinationTravelItem.TravelItemID);
            return View(destinationTravelItem);
        }

        // GET: DestinationTravelItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationTravelItem = await _context.DestinationTravelItem
                .Include(d => d.Destination)
                .Include(d => d.TravelItem)
                .SingleOrDefaultAsync(m => m.DestinationID == id);
            if (destinationTravelItem == null)
            {
                return NotFound();
            }

            return View(destinationTravelItem);
        }

        // POST: DestinationTravelItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinationTravelItem = await _context.DestinationTravelItem.SingleOrDefaultAsync(m => m.DestinationID == id);
            _context.DestinationTravelItem.Remove(destinationTravelItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationTravelItemExists(int id)
        {
            return _context.DestinationTravelItem.Any(e => e.DestinationID == id);
        }
    }
}
