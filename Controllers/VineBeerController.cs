#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_hcms.Data;
using project_hcms.Models;

namespace project_hcms.Controllers
{
    public class VineBeerController : Controller
    {
        private readonly MenuContext _context;

        public VineBeerController(MenuContext context)
        {
            _context = context;
        }

        // GET: VineBeer
        public async Task<IActionResult> Index()
        {
            return View(await _context.VineBeers.ToListAsync());
        }

        // GET: VineBeer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vineBeer = await _context.VineBeers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vineBeer == null)
            {
                return NotFound();
            }

            return View(vineBeer);
        }

        // GET: VineBeer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VineBeer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Ingredients,Price")] VineBeer vineBeer)
        {
            if (ModelState.IsValid)
            {
                vineBeer.Username = User.Identity.Name;
                _context.Add(vineBeer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vineBeer);
        }

        // GET: VineBeer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vineBeer = await _context.VineBeers.FindAsync(id);
            if (vineBeer == null)
            {
                return NotFound();
            }
            return View(vineBeer);
        }

        // POST: VineBeer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Ingredients,Price")] VineBeer vineBeer)
        {
            if (id != vineBeer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vineBeer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VineBeerExists(vineBeer.Id))
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
            return View(vineBeer);
        }

        // GET: VineBeer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vineBeer = await _context.VineBeers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vineBeer == null)
            {
                return NotFound();
            }

            return View(vineBeer);
        }

        // POST: VineBeer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vineBeer = await _context.VineBeers.FindAsync(id);
            _context.VineBeers.Remove(vineBeer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VineBeerExists(int id)
        {
            return _context.VineBeers.Any(e => e.Id == id);
        }
    }
}
