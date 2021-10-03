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
    public class YayınEviController : ControllerBase
    {
        private readonly AppDbContext _context;

        public YayınEviController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/YayınEvi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YayınEvi>>> GetYayınEvleri()
        {
            return await _context.YayınEvleri.ToListAsync();
        }

        // GET: api/YayınEvi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YayınEvi>> GetYayınEvi(int id)
        {
            var yayınEvi = await _context.YayınEvleri.FindAsync(id);

            if (yayınEvi == null)
            {
                return NotFound();
            }

            return yayınEvi;
        }

        // PUT: api/YayınEvi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYayınEvi(int id, YayınEvi yayınEvi)
        {
            if (id != yayınEvi.YayinEvi_Id)
            {
                return BadRequest();
            }

            _context.Entry(yayınEvi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YayınEviExists(id))
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

        // POST: api/YayınEvi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<YayınEvi>> PostYayınEvi(YayınEvi yayınEvi)
        {
            _context.YayınEvleri.Add(yayınEvi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYayınEvi", new { id = yayınEvi.YayinEvi_Id }, yayınEvi);
        }

        // DELETE: api/YayınEvi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYayınEvi(int id)
        {
            var yayınEvi = await _context.YayınEvleri.FindAsync(id);
            if (yayınEvi == null)
            {
                return NotFound();
            }

            _context.YayınEvleri.Remove(yayınEvi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YayınEviExists(int id)
        {
            return _context.YayınEvleri.Any(e => e.YayinEvi_Id == id);
        }
    }
}
