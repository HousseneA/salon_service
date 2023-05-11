using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Salon_service.Model;

namespace Salon_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationCsController : ControllerBase
    {
        private readonly tableContext _context;

        public InformationCsController(tableContext context)
        {
            _context = context;
        }

        // GET: api/InformationCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InformationC>>> GetInformationCategories()
        {
            return await _context.InformationCategories.ToListAsync();
        }

        // GET: api/InformationCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InformationC>> GetInformationC(int id)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from InformationCategories,Categories where (InformationCategories.idCategorie = Categories.idCategorie) and InformationCategories.idCategorie =  " + id, SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<InformationC> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    InformationC info = new();
                    info.idInformation = Convert.ToInt32(data.Rows[i]["idInformation"]);
                    info.informationCategorie = Convert.ToString(data.Rows[i]["informationCategorie"]);
                    
                    list.Add(info);

                }

            }

            return new JsonResult(list);
           
        }

        // PUT: api/InformationCs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformationC(int id, InformationC informationC)
        {
            if (id != informationC.idInformation)
            {
                return BadRequest();
            }

            _context.Entry(informationC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformationCExists(id))
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

        // POST: api/InformationCs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InformationC>> PostInformationC( [FromBody] InformationC informationC)
        {
            _context.InformationCategories.Add(informationC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInformationC", new { id = informationC.idInformation }, informationC);
        }

        // DELETE: api/InformationCs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInformationC(int id)
        {
            var informationC = await _context.InformationCategories.FindAsync(id);
            if (informationC == null)
            {
                return NotFound();
            }

            _context.InformationCategories.Remove(informationC);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InformationCExists(int id)
        {
            return _context.InformationCategories.Any(e => e.idInformation == id);
        }
    }
}
