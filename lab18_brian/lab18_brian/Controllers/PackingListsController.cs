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
    public class PackingListsController : Controller
    {
        private readonly lab18_brianContext _context;

        public PackingListsController(lab18_brianContext context)
        {
            _context = context;    
        }

        // GET: PackingLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.PackingList.ToListAsync());
        }

        // GET: PackingLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packingList = await _context.PackingList
                .SingleOrDefaultAsync(m => m.ID == id);
            if (packingList == null)
            {
                return NotFound();
            }

            return View(packingList);
        }

        // GET: PackingLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PackingLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] PackingList packingList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packingList);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(packingList);
        }

        // GET: PackingLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packingList = await _context.PackingList.SingleOrDefaultAsync(m => m.ID == id);
            if (packingList == null)
            {
                return NotFound();
            }
            return View(packingList);
        }

        // POST: PackingLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] PackingList packingList)
        {
            if (id != packingList.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packingList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackingListExists(packingList.ID))
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
            return View(packingList);
        }

        // GET: PackingLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packingList = await _context.PackingList
                .SingleOrDefaultAsync(m => m.ID == id);
            if (packingList == null)
            {
                return NotFound();
            }

            return View(packingList);
        }

        // POST: PackingLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packingList = await _context.PackingList.SingleOrDefaultAsync(m => m.ID == id);
            _context.PackingList.Remove(packingList);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PackingListExists(int id)
        {
            return _context.PackingList.Any(e => e.ID == id);
        }
    }
}
