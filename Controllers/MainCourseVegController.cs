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
    public class MainCourseVegController : Controller
    {
        private readonly MenuContext _context;

        public MainCourseVegController(MenuContext context)
        {
            _context = context;
        }

        // GET: MainCourseVeg
        public async Task<IActionResult> Index()
        {
            return View(await _context.MainCoursesVeg.ToListAsync());
        }

        // GET: MainCourseVeg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCourseVeg = await _context.MainCoursesVeg
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainCourseVeg == null)
            {
                return NotFound();
            }

            return View(mainCourseVeg);
        }

        // GET: MainCourseVeg/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MainCourseVeg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Ingredients,Price")] MainCourseVeg mainCourseVeg)
        {
            if (ModelState.IsValid)
            {
                mainCourseVeg.Username = User.Identity.Name;
                _context.Add(mainCourseVeg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainCourseVeg);
        }

        // GET: MainCourseVeg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCourseVeg = await _context.MainCoursesVeg.FindAsync(id);
            if (mainCourseVeg == null)
            {
                return NotFound();
            }
            return View(mainCourseVeg);
        }

        // POST: MainCourseVeg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Ingredients,Price")] MainCourseVeg mainCourseVeg)
        {
            if (id != mainCourseVeg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainCourseVeg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainCourseVegExists(mainCourseVeg.Id))
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
            return View(mainCourseVeg);
        }

        // GET: MainCourseVeg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCourseVeg = await _context.MainCoursesVeg
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainCourseVeg == null)
            {
                return NotFound();
            }

            return View(mainCourseVeg);
        }

        // POST: MainCourseVeg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainCourseVeg = await _context.MainCoursesVeg.FindAsync(id);
            _context.MainCoursesVeg.Remove(mainCourseVeg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainCourseVegExists(int id)
        {
            return _context.MainCoursesVeg.Any(e => e.Id == id);
        }
    }
}
