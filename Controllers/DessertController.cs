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
    public class DessertController : Controller
    {
        private readonly MenuContext _context;

        public DessertController(MenuContext context)
        {
            _context = context;
        }

        // GET: Dessert
        public async Task<IActionResult> Index()
        {
            return View(await _context.Desserts.ToListAsync());
        }

        // GET: Dessert/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessert = await _context.Desserts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dessert == null)
            {
                return NotFound();
            }

            return View(dessert);
        }

        // GET: Dessert/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dessert/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Ingredients,Price")] Dessert dessert)
        {
            if (ModelState.IsValid)
            {
                dessert.Username = User.Identity.Name;
                _context.Add(dessert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dessert);
        }

        // GET: Dessert/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessert = await _context.Desserts.FindAsync(id);
            if (dessert == null)
            {
                return NotFound();
            }
            return View(dessert);
        }

        // POST: Dessert/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Ingredients,Price")] Dessert dessert)
        {
            if (id != dessert.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dessert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DessertExists(dessert.Id))
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
            return View(dessert);
        }

        // GET: Dessert/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessert = await _context.Desserts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dessert == null)
            {
                return NotFound();
            }

            return View(dessert);
        }

        // POST: Dessert/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dessert = await _context.Desserts.FindAsync(id);
            _context.Desserts.Remove(dessert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DessertExists(int id)
        {
            return _context.Desserts.Any(e => e.Id == id);
        }
    }
}
