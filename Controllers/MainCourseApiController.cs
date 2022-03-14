#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_hcms.Data;
using project_hcms.Models;

namespace project_hcms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCourseApiController : ControllerBase
    {
        private readonly MenuContext _context;

        public MainCourseApiController(MenuContext context)
        {
            _context = context;
        }

        // GET: api/MainCourseApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainCourse>>> GetMainCourses()
        {
            return await _context.MainCourses.ToListAsync();
        }

        // GET: api/MainCourseApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainCourse>> GetMainCourse(int id)
        {
            var mainCourse = await _context.MainCourses.FindAsync(id);

            if (mainCourse == null)
            {
                return NotFound();
            }

            return mainCourse;
        }

        // PUT: api/MainCourseApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainCourse(int id, MainCourse mainCourse)
        {
            if (id != mainCourse.Id)
            {
                return BadRequest();
            }

            _context.Entry(mainCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainCourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MainCourseApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MainCourse>> PostMainCourse(MainCourse mainCourse)
        {
            _context.MainCourses.Add(mainCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMainCourse", new { id = mainCourse.Id }, mainCourse);
        }

        // DELETE: api/MainCourseApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMainCourse(int id)
        {
            var mainCourse = await _context.MainCourses.FindAsync(id);
            if (mainCourse == null)
            {
                return NotFound();
            }

            _context.MainCourses.Remove(mainCourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MainCourseExists(int id)
        {
            return _context.MainCourses.Any(e => e.Id == id);
        }
    }
}
