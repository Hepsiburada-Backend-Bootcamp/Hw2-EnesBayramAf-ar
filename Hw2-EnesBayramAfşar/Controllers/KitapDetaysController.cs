using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hw2_EnesBayramAfşar.Models;
using Hw2_EnesBayramAfşar.VT;

namespace Hw2_EnesBayramAfşar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapDetaysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KitapDetaysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/KitapDetays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KitapDetay>>> GetKitapDetay()
        {
            return await _context.KitapDetay.ToListAsync();
        }

        // GET: api/KitapDetays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KitapDetay>> GetKitapDetay(int id)
        {
            var kitapDetay = await _context.KitapDetay.FindAsync(id);

            if (kitapDetay == null)
            {
                return NotFound();
            }

            return kitapDetay;
        }

        // PUT: api/KitapDetays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKitapDetay(int id, KitapDetay kitapDetay)
        {
            if (id != kitapDetay.KitapDetayId)
            {
                return BadRequest();
            }

            _context.Entry(kitapDetay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitapDetayExists(id))
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

        // POST: api/KitapDetays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KitapDetay>> PostKitapDetay(KitapDetay kitapDetay)
        {
            _context.KitapDetay.Add(kitapDetay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKitapDetay", new { id = kitapDetay.KitapDetayId }, kitapDetay);
        }

        // DELETE: api/KitapDetays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKitapDetay(int id)
        {
            var kitapDetay = await _context.KitapDetay.FindAsync(id);
            if (kitapDetay == null)
            {
                return NotFound();
            }

            _context.KitapDetay.Remove(kitapDetay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KitapDetayExists(int id)
        {
            return _context.KitapDetay.Any(e => e.KitapDetayId == id);
        }
    }
}
