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
    public class MainCourseVegApiController : ControllerBase
    {
        private readonly MenuContext _context;

        public MainCourseVegApiController(MenuContext context)
        {
            _context = context;
        }

        // GET: api/MainCourseVegApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainCourseVeg>>> GetMainCoursesVeg()
        {
            return await _context.MainCoursesVeg.ToListAsync();
        }

        // GET: api/MainCourseVegApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainCourseVeg>> GetMainCourseVeg(int id)
        {
            var mainCourseVeg = await _context.MainCoursesVeg.FindAsync(id);

            if (mainCourseVeg == null)
            {
                return NotFound();
            }

            return mainCourseVeg;
        }

        // PUT: api/MainCourseVegApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainCourseVeg(int id, MainCourseVeg mainCourseVeg)
        {
            if (id != mainCourseVeg.Id)
            {
                return BadRequest();
            }

            _context.Entry(mainCourseVeg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainCourseVegExists(id))
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

        // POST: api/MainCourseVegApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MainCourseVeg>> PostMainCourseVeg(MainCourseVeg mainCourseVeg)
        {
            _context.MainCoursesVeg.Add(mainCourseVeg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMainCourseVeg", new { id = mainCourseVeg.Id }, mainCourseVeg);
        }

        // DELETE: api/MainCourseVegApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMainCourseVeg(int id)
        {
            var mainCourseVeg = await _context.MainCoursesVeg.FindAsync(id);
            if (mainCourseVeg == null)
            {
                return NotFound();
            }

            _context.MainCoursesVeg.Remove(mainCourseVeg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MainCourseVegExists(int id)
        {
            return _context.MainCoursesVeg.Any(e => e.Id == id);
        }
    }
}
