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
    public class MessesController : ControllerBase
    {
        private readonly tableContext _context;

        public MessesController(tableContext context)
        {
            _context = context;
        }

        // GET: api/Messes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mess>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        // GET: api/Messes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mess>> GetMess(int id)
        {
            var mess = await _context.Messages.FindAsync(id);

            if (mess == null)
            {
                return NotFound();
            }

            return mess;
        }

        // PUT: api/Messes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMess(int id, Mess mess)
        {
            if (id != mess.idMess)
            {
                return BadRequest();
            }

            _context.Entry(mess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessExists(id))
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

        // POST: api/Messes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mess>> PostMess(Mess mess)
        {
            _context.Messages.Add(mess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMess", new { id = mess.idMess }, mess);
        }

        // DELETE: api/Messes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMess(int id)
        {
            var mess = await _context.Messages.FindAsync(id);
            if (mess == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(mess);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessExists(int id)
        {
            return _context.Messages.Any(e => e.idMess == id);
        }
    }
}
