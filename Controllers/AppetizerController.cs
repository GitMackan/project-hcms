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
    public class AppetizerController : Controller
    {
        private readonly MenuContext _context;

        public AppetizerController(MenuContext context)
        {
            _context = context;
        }

        // GET: Appetizer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Appetizers.ToListAsync());
        }

        // GET: Appetizer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appetizer = await _context.Appetizers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appetizer == null)
            {
                return NotFound();
            }

            return View(appetizer);
        }

        // GET: Appetizer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appetizer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Ingredients,Price")] Appetizer appetizer)
        {
            if (ModelState.IsValid)
            {
                appetizer.Username = User.Identity.Name;
                _context.Add(appetizer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appetizer);
        }

        // GET: Appetizer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appetizer = await _context.Appetizers.FindAsync(id);
            if (appetizer == null)
            {
                return NotFound();
            }
            return View(appetizer);
        }

        // POST: Appetizer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Ingredients,Price")] Appetizer appetizer)
        {
            if (id != appetizer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appetizer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppetizerExists(appetizer.Id))
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
            return View(appetizer);
        }

        // GET: Appetizer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appetizer = await _context.Appetizers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appetizer == null)
            {
                return NotFound();
            }

            return View(appetizer);
        }

        // POST: Appetizer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appetizer = await _context.Appetizers.FindAsync(id);
            _context.Appetizers.Remove(appetizer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppetizerExists(int id)
        {
            return _context.Appetizers.Any(e => e.Id == id);
        }
    }
}
