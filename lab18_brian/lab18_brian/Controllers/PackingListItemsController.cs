using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab18_brian.Models;

namespace lab18_brian.Controllers
{
    public class PackingListItemsController : Controller
    {
        private readonly lab18_brianContext _context;

        public PackingListItemsController(lab18_brianContext context)
        {
            _context = context;    
        }

        // GET: PackingListItems
        public async Task<IActionResult> Index()
        {
            var lab18_brianContext = _context.PackingListItems.Include(p => p.Item).Include(p => p.PackingList);
            return View(await lab18_brianContext.ToListAsync());
        }

        // GET: PackingListItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packingListItems = await _context.PackingListItems
                .Include(p => p.Item)
                .Include(p => p.PackingList)
                .SingleOrDefaultAsync(m => m.packinglistID == id);
            if (packingListItems == null)
            {
                return NotFound();
            }

            return View(packingListItems);
        }

        // GET: PackingListItems/Create
        public IActionResult Create()
        {
            ViewData["itemID"] = new SelectList(_context.Item, "ID", "ID");
            ViewData["packinglistID"] = new SelectList(_context.PackingList, "ID", "ID");
            return View();
        }

        // POST: PackingListItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("packinglistID,itemID")] PackingListItems packingListItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packingListItems);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["itemID"] = new SelectList(_context.Item, "ID", "ID", packingListItems.itemID);
            ViewData["packinglistID"] = new SelectList(_context.PackingList, "ID", "ID", packingListItems.packinglistID);
            return View(packingListItems);
        }

        // GET: PackingListItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packingListItems = await _context.PackingListItems.SingleOrDefaultAsync(m => m.packinglistID == id);
            if (packingListItems == null)
            {
                return NotFound();
            }
            ViewData["itemID"] = new SelectList(_context.Item, "ID", "ID", packingListItems.itemID);
            ViewData["packinglistID"] = new SelectList(_context.PackingList, "ID", "ID", packingListItems.packinglistID);
            return View(packingListItems);
        }

        // POST: PackingListItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("packinglistID,itemID")] PackingListItems packingListItems)
        {
            if (id != packingListItems.packinglistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packingListItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackingListItemsExists(packingListItems.packinglistID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["itemID"] = new SelectList(_context.Item, "ID", "ID", packingListItems.itemID);
            ViewData["packinglistID"] = new SelectList(_context.PackingList, "ID", "ID", packingListItems.packinglistID);
            return View(packingListItems);
        }

        // GET: PackingListItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packingListItems = await _context.PackingListItems
                .Include(p => p.Item)
                .Include(p => p.PackingList)
                .SingleOrDefaultAsync(m => m.packinglistID == id);
            if (packingListItems == null)
            {
                return NotFound();
            }

            return View(packingListItems);
        }

        // POST: PackingListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packingListItems = await _context.PackingListItems.SingleOrDefaultAsync(m => m.packinglistID == id);
            _context.PackingListItems.Remove(packingListItems);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PackingListItemsExists(int id)
        {
            return _context.PackingListItems.Any(e => e.packinglistID == id);
        }
    }
}
