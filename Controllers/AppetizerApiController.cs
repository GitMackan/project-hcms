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
    public class AppetizerApiController : ControllerBase
    {
        private readonly MenuContext _context;

        public AppetizerApiController(MenuContext context)
        {
            _context = context;
        }

        // GET: api/AppetizerApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appetizer>>> GetAppetizers()
        {
            return await _context.Appetizers.ToListAsync();
        }

        // GET: api/AppetizerApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appetizer>> GetAppetizer(int id)
        {
            var appetizer = await _context.Appetizers.FindAsync(id);

            if (appetizer == null)
            {
                return NotFound();
            }

            return appetizer;
        }

        // PUT: api/AppetizerApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppetizer(int id, Appetizer appetizer)
        {
            if (id != appetizer.Id)
            {
                return BadRequest();
            }

            _context.Entry(appetizer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppetizerExists(id))
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

        // POST: api/AppetizerApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appetizer>> PostAppetizer(Appetizer appetizer)
        {
            _context.Appetizers.Add(appetizer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppetizer", new { id = appetizer.Id }, appetizer);
        }

        // DELETE: api/AppetizerApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppetizer(int id)
        {
            var appetizer = await _context.Appetizers.FindAsync(id);
            if (appetizer == null)
            {
                return NotFound();
            }

            _context.Appetizers.Remove(appetizer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppetizerExists(int id)
        {
            return _context.Appetizers.Any(e => e.Id == id);
        }
    }
}
