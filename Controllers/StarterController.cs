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
    public class StarterController : Controller
    {
        private readonly MenuContext _context;

        public StarterController(MenuContext context)
        {
            _context = context;
        }

        // GET: Starter
        public async Task<IActionResult> Index()
        {
            return View(await _context.Starters.ToListAsync());
        }

        // GET: Starter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starter = await _context.Starters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starter == null)
            {
                return NotFound();
            }

            return View(starter);
        }

        // GET: Starter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Starter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Ingredients,Price")] Starter starter)
        {
            if (ModelState.IsValid)
            {
                starter.Username = User.Identity.Name;
                _context.Add(starter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(starter);
        }

        // GET: Starter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starter = await _context.Starters.FindAsync(id);
            if (starter == null)
            {
                return NotFound();
            }
            return View(starter);
        }

        // POST: Starter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Ingredients,Price")] Starter starter)
        {
            if (id != starter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarterExists(starter.Id))
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
            return View(starter);
        }

        // GET: Starter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starter = await _context.Starters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starter == null)
            {
                return NotFound();
            }

            return View(starter);
        }

        // POST: Starter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starter = await _context.Starters.FindAsync(id);
            _context.Starters.Remove(starter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarterExists(int id)
        {
            return _context.Starters.Any(e => e.Id == id);
        }
    }
}
