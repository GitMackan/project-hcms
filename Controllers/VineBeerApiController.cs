#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_hcms.Data;
using project_hcms.Models;

namespace project_hcms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VineBeerApiController : ControllerBase
    {
        private readonly MenuContext _context;

        public VineBeerApiController(MenuContext context)
        {
            _context = context;
        }

        // GET: api/VineBeerApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VineBeer>>> GetVineBeers()
        {
            return await _context.VineBeers.ToListAsync();
        }

        // GET: api/VineBeerApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VineBeer>> GetVineBeer(int id)
        {
            var vineBeer = await _context.VineBeers.FindAsync(id);

            if (vineBeer == null)
            {
                return NotFound();
            }

            return vineBeer;
        }

        // PUT: api/VineBeerApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVineBeer(int id, VineBeer vineBeer)
        {
            if (id != vineBeer.Id)
            {
                return BadRequest();
            }

            _context.Entry(vineBeer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VineBeerExists(id))
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

        // POST: api/VineBeerApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VineBeer>> PostVineBeer(VineBeer vineBeer)
        {
            _context.VineBeers.Add(vineBeer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVineBeer", new { id = vineBeer.Id }, vineBeer);
        }

        // DELETE: api/VineBeerApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVineBeer(int id)
        {
            var vineBeer = await _context.VineBeers.FindAsync(id);
            if (vineBeer == null)
            {
                return NotFound();
            }

            _context.VineBeers.Remove(vineBeer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VineBeerExists(int id)
        {
            return _context.VineBeers.Any(e => e.Id == id);
        }
    }
}
