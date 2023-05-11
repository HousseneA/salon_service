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
    public class AnnulationCsController : ControllerBase
    {
        private readonly tableContext _context;

        public AnnulationCsController(tableContext context)
        {
            _context = context;
        }

        // GET: api/AnnulationCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnulationC>>> GetAnnulations()
        {
            return await _context.Annulations.ToListAsync();
        }

        // GET: api/AnnulationCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnnulationC>> GetAnnulationC(int id)
        {
            var annulationC = await _context.Annulations.FindAsync(id);

            if (annulationC == null)
            {
                return NotFound();
            }

            return annulationC;
        }

        // PUT: api/AnnulationCs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnnulationC(int id, AnnulationC annulationC)
        {
            if (id != annulationC.idAnnulation)
            {
                return BadRequest();
            }

            _context.Entry(annulationC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnulationCExists(id))
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

        // POST: api/AnnulationCs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnnulationC>> PostAnnulationC(AnnulationC annulationC)
        {
            _context.Annulations.Add(annulationC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnnulationC", new { id = annulationC.idAnnulation }, annulationC);
        }

        // DELETE: api/AnnulationCs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnulationC(int id)
        {
            var annulationC = await _context.Annulations.FindAsync(id);
            if (annulationC == null)
            {
                return NotFound();
            }

            _context.Annulations.Remove(annulationC);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnnulationCExists(int id)
        {
            return _context.Annulations.Any(e => e.idAnnulation == id);
        }
    }
}
