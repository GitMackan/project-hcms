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
    public class MainCourseController : Controller
    {
        private readonly MenuContext _context;

        public MainCourseController(MenuContext context)
        {
            _context = context;
        }

        // GET: MainCourse
        public async Task<IActionResult> Index()
        {
            return View(await _context.MainCourses.ToListAsync());
        }

        // GET: MainCourse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCourse = await _context.MainCourses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainCourse == null)
            {
                return NotFound();
            }

            return View(mainCourse);
        }

        // GET: MainCourse/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MainCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Ingredients,Price,Username")] MainCourse mainCourse)
        {
            if (ModelState.IsValid)
            {
                mainCourse.Username = User.Identity.Name;
                _context.Add(mainCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainCourse);
        }

        // GET: MainCourse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCourse = await _context.MainCourses.FindAsync(id);
            if (mainCourse == null)
            {
                return NotFound();
            }
            return View(mainCourse);
        }

        // POST: MainCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Ingredients,Price")] MainCourse mainCourse)
        {
            if (id != mainCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainCourseExists(mainCourse.Id))
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
            return View(mainCourse);
        }

        // GET: MainCourse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCourse = await _context.MainCourses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainCourse == null)
            {
                return NotFound();
            }

            return View(mainCourse);
        }

        // POST: MainCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainCourse = await _context.MainCourses.FindAsync(id);
            _context.MainCourses.Remove(mainCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainCourseExists(int id)
        {
            return _context.MainCourses.Any(e => e.Id == id);
        }
    }
}
