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
    public class CoffeeApiController : ControllerBase
    {
        private readonly MenuContext _context;

        public CoffeeApiController(MenuContext context)
        {
            _context = context;
        }

        // GET: api/CoffeeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coffee>>> GetCoffees()
        {
            return await _context.Coffees.ToListAsync();
        }

        // GET: api/CoffeeApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coffee>> GetCoffee(int id)
        {
            var coffee = await _context.Coffees.FindAsync(id);

            if (coffee == null)
            {
                return NotFound();
            }

            return coffee;
        }

        // PUT: api/CoffeeApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoffee(int id, Coffee coffee)
        {
            if (id != coffee.Id)
            {
                return BadRequest();
            }

            _context.Entry(coffee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeExists(id))
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

        // POST: api/CoffeeApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coffee>> PostCoffee(Coffee coffee)
        {
            _context.Coffees.Add(coffee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoffee", new { id = coffee.Id }, coffee);
        }

        // DELETE: api/CoffeeApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffee(int id)
        {
            var coffee = await _context.Coffees.FindAsync(id);
            if (coffee == null)
            {
                return NotFound();
            }

            _context.Coffees.Remove(coffee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoffeeExists(int id)
        {
            return _context.Coffees.Any(e => e.Id == id);
        }
    }
}
