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
    public class ClsController : ControllerBase
    {
        private readonly tableContext _context;

        public ClsController(tableContext context)
        {
            _context = context;
        }

        // GET: api/Cls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cls>>> GetCls()
        {
            return await _context.Cls.ToListAsync();
        }

        // GET: api/Cls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cls>> GetCls(int id)
        {
            var cls = await _context.Cls.FindAsync(id);

            if (cls == null)
            {
                return NotFound();
            }

            return cls;
        }

        // PUT: api/Cls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCls(int id, Cls cls)
        {
            if (id != cls.idArticle)
            {
                return BadRequest();
            }

            _context.Entry(cls).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClsExists(id))
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

        // POST: api/Cls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cls>> PostCls(Cls cls)
        {
            _context.Cls.Add(cls);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCls", new { id = cls.idArticle }, cls);
        }

        // DELETE: api/Cls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCls(int id)
        {
            var cls = await _context.Cls.FindAsync(id);
            if (cls == null)
            {
                return NotFound();
            }

            _context.Cls.Remove(cls);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClsExists(int id)
        {
            return _context.Cls.Any(e => e.idArticle == id);
        }
    }
}
