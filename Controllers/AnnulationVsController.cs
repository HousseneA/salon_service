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
    public class AnnulationVsController : ControllerBase
    {
        private readonly tableContext _context;

        public AnnulationVsController(tableContext context)
        {
            _context = context;
        }

        // GET: api/AnnulationVs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnulationV>>> GetAnnulationsV()
        {
            return await _context.AnnulationsV.ToListAsync();
        }

        // GET: api/AnnulationVs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnnulationV>> GetAnnulationV(int id)
        {
            var annulationV = await _context.AnnulationsV.FindAsync(id);

            if (annulationV == null)
            {
                return NotFound();
            }

            return annulationV;
        }

        // PUT: api/AnnulationVs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnnulationV(int id, AnnulationV annulationV)
        {
            if (id != annulationV.idAnnulationV)
            {
                return BadRequest();
            }

            _context.Entry(annulationV).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnulationVExists(id))
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

        // POST: api/AnnulationVs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnnulationV>> PostAnnulationV(AnnulationV annulationV)
        {
            _context.AnnulationsV.Add(annulationV);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnnulationV", new { id = annulationV.idAnnulationV }, annulationV);
        }

        // DELETE: api/AnnulationVs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnulationV(int id)
        {
            var annulationV = await _context.AnnulationsV.FindAsync(id);
            if (annulationV == null)
            {
                return NotFound();
            }

            _context.AnnulationsV.Remove(annulationV);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnnulationVExists(int id)
        {
            return _context.AnnulationsV.Any(e => e.idAnnulationV == id);
        }
    }
}
