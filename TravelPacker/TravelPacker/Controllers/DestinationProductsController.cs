using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelPacker.Models;

namespace TravelPacker.Controllers
{
    public class DestinationProductsController : Controller
    {
        private readonly TravelPackerContext _context;

        public DestinationProductsController(TravelPackerContext context)
        {
            _context = context;
        }

        // GET: DestinationProducts
        public async Task<IActionResult> Index()
        {
            var travelPackerContext = _context.DestinationProducts.Include(d => d.Destination).Include(d => d.Product);
            return View(await travelPackerContext.ToListAsync());
        }

        // GET: DestinationProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationProducts = await _context.DestinationProducts
                .Include(d => d.Destination)
                .Include(d => d.Product)
                .SingleOrDefaultAsync(m => m.DestinationProductsID == id);
            if (destinationProducts == null)
            {
                return NotFound();
            }

            return View(destinationProducts);
        }

        // GET: DestinationProducts/Create
        public IActionResult Create()
        {
            ViewData["DestinationID"] = new SelectList(_context.Destination, "DestinationID", "DestinationID");
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID");
            return View();
        }

        // POST: DestinationProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DestinationProductsID,DestinationID,ProductID")] DestinationProducts destinationProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinationProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinationID"] = new SelectList(_context.Destination, "DestinationID", "DestinationID", destinationProducts.DestinationID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", destinationProducts.ProductID);
            return View(destinationProducts);
        }

        // GET: DestinationProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationProducts = await _context.DestinationProducts.SingleOrDefaultAsync(m => m.DestinationProductsID == id);
            if (destinationProducts == null)
            {
                return NotFound();
            }
            ViewData["DestinationID"] = new SelectList(_context.Destination, "DestinationID", "DestinationID", destinationProducts.DestinationID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", destinationProducts.ProductID);
            return View(destinationProducts);
        }

        // POST: DestinationProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DestinationProductsID,DestinationID,ProductID")] DestinationProducts destinationProducts)
        {
            if (id != destinationProducts.DestinationProductsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinationProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationProductsExists(destinationProducts.DestinationProductsID))
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
            ViewData["DestinationID"] = new SelectList(_context.Destination, "DestinationID", "DestinationID", destinationProducts.DestinationID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", destinationProducts.ProductID);
            return View(destinationProducts);
        }

        // GET: DestinationProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationProducts = await _context.DestinationProducts
                .Include(d => d.Destination)
                .Include(d => d.Product)
                .SingleOrDefaultAsync(m => m.DestinationProductsID == id);
            if (destinationProducts == null)
            {
                return NotFound();
            }

            return View(destinationProducts);
        }

        // POST: DestinationProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinationProducts = await _context.DestinationProducts.SingleOrDefaultAsync(m => m.DestinationProductsID == id);
            _context.DestinationProducts.Remove(destinationProducts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationProductsExists(int id)
        {
            return _context.DestinationProducts.Any(e => e.DestinationProductsID == id);
        }
    }
}
