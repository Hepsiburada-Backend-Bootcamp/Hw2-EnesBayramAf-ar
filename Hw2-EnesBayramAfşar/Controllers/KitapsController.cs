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
    [Route("api/kitaplar")]
    [ApiController]
    public class KitapsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KitapsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Kitaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kitap>>> GetKitaplar()
        {
            return await _context.Kitaplar.ToListAsync();
        }

        // GET: api/Kitaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kitap>> GetKitap(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);

            if (kitap == null)
            {
                return NotFound();
            }

            return kitap;
        }

        // PUT: api/Kitaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKitap(int id, Kitap kitap)
        {
            if (id != kitap.KitapId)
            {
                return BadRequest();
            }

            _context.Entry(kitap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitapExists(id))
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

        // POST: api/Kitaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kitap>> PostKitap(Kitap kitap)
        {
            _context.Kitaplar.Add(kitap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKitap", new { id = kitap.KitapId }, kitap);
        }

        // DELETE: api/Kitaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKitap(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }

            _context.Kitaplar.Remove(kitap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KitapExists(int id)
        {
            return _context.Kitaplar.Any(e => e.KitapId == id);
        }
    }
}
