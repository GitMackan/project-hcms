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
    public class StarterApiController : ControllerBase
    {
        private readonly MenuContext _context;

        public StarterApiController(MenuContext context)
        {
            _context = context;
        }

        // GET: api/StarterApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Starter>>> GetStarters()
        {
            return await _context.Starters.ToListAsync();
        }

        // GET: api/StarterApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Starter>> GetStarter(int id)
        {
            var starter = await _context.Starters.FindAsync(id);

            if (starter == null)
            {
                return NotFound();
            }

            return starter;
        }

        // PUT: api/StarterApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStarter(int id, Starter starter)
        {
            if (id != starter.Id)
            {
                return BadRequest();
            }

            _context.Entry(starter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarterExists(id))
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

        // POST: api/StarterApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Starter>> PostStarter(Starter starter)
        {
            _context.Starters.Add(starter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStarter", new { id = starter.Id }, starter);
        }

        // DELETE: api/StarterApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStarter(int id)
        {
            var starter = await _context.Starters.FindAsync(id);
            if (starter == null)
            {
                return NotFound();
            }

            _context.Starters.Remove(starter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StarterExists(int id)
        {
            return _context.Starters.Any(e => e.Id == id);
        }
    }
}
