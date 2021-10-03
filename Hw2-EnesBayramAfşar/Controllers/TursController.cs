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
    public class TursController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TursController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Turs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tur>>> GetTurler()
        {
            return await _context.Turler.ToListAsync();
        }

        // GET: api/Turs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tur>> GetTur(int id)
        {
            var tur = await _context.Turler.FindAsync(id);

            if (tur == null)
            {
                return NotFound();
            }

            return tur;
        }

        // PUT: api/Turs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTur(int id, Tur tur)
        {
            if (id != tur.TurId)
            {
                return BadRequest();
            }

            _context.Entry(tur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurExists(id))
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

        // POST: api/Turs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tur>> PostTur(Tur tur)
        {
            _context.Turler.Add(tur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTur", new { id = tur.TurId }, tur);
        }

        // DELETE: api/Turs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTur(int id)
        {
            var tur = await _context.Turler.FindAsync(id);
            if (tur == null)
            {
                return NotFound();
            }

            _context.Turler.Remove(tur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TurExists(int id)
        {
            return _context.Turler.Any(e => e.TurId == id);
        }
    }
}
