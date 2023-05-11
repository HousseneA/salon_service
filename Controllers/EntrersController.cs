using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Salon_service.Model;

namespace Salon_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrersController : ControllerBase
    {
        private readonly tableContext _context;

        public EntrersController(tableContext context)
        {
            _context = context;
        }

        // GET: api/Entrers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrer>>> GetEntrer()
        {
            return await _context.Entrer.ToListAsync();
        }

        // GET: api/Entrers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entrer>> GetEntrer(int id)
        {
            var entrer = await _context.Entrer.FindAsync(id);

            if (entrer == null)
            {
                return NotFound();
            }

            return entrer;
        }

        // PUT: api/Entrers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrer(int id, Entrer entrer)
        {
            if (id != entrer.idFournisseur)
            {
                return BadRequest();
            }

            _context.Entry(entrer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrerExists(id))
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

        // POST: api/Entrers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Entrer>> PostEntrer( Entrer entrer)
        {
            _context.Entrer.Add(entrer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntrer", new { id = entrer.idFournisseur }, entrer);
        }

        // DELETE: api/Entrers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntrer(int id)
        {
            var entrer = await _context.Entrer.FindAsync(id);
            if (entrer == null)
            {
                return NotFound();
            }

            _context.Entrer.Remove(entrer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntrerExists(int id)
        {
            return _context.Entrer.Any(e => e.idFournisseur == id);
        }
    }
}
