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
    public class YazarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public YazarsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Yazars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Yazar>>> GetYazarlar()
        {
            return await _context.Yazarlar.ToListAsync();
        }

        // GET: api/Yazars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Yazar>> GetYazar(int id)
        {
            var yazar = await _context.Yazarlar.FindAsync(id);

            if (yazar == null)
            {
                return NotFound();
            }

            return yazar;
        }

        // PUT: api/Yazars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYazar(int id, Yazar yazar)
        {
            if (id != yazar.Yazar_Id)
            {
                return BadRequest();
            }

            _context.Entry(yazar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YazarExists(id))
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

        // POST: api/Yazars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Yazar>> PostYazar(Yazar yazar)
        {
            _context.Yazarlar.Add(yazar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYazar", new { id = yazar.Yazar_Id }, yazar);
        }

        // DELETE: api/Yazars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYazar(int id)
        {
            var yazar = await _context.Yazarlar.FindAsync(id);
            if (yazar == null)
            {
                return NotFound();
            }

            _context.Yazarlar.Remove(yazar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YazarExists(int id)
        {
            return _context.Yazarlar.Any(e => e.Yazar_Id == id);
        }
    }
}
