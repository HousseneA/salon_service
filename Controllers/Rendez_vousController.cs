using System;
using System.Collections.Generic;
using System.Data;
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
    public class Rendez_vousController : ControllerBase
    {
        private readonly tableContext _context;

        public Rendez_vousController(tableContext context)
        {
            _context = context;
        }

        // GET: api/Rendez_vous
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rendez_vous>>> GetRendez_vous()
        {
            return await _context.Rendez_vous.ToListAsync();
        }

        // GET: api/Rendez_vous/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rendez_vous>> GetRendez_vous(int id)
        {
            var rendez_vous = await _context.Rendez_vous.FindAsync(id);

            if (rendez_vous == null)
            {
                return NotFound();
            }

            return rendez_vous;
        }
        [HttpGet("RendezVousCli/{nom}")]
        public async Task<ActionResult<Rendez_vous>> GetImageC(String? nom)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from Rendez_vous,Clients where (Clients.emailClient=Rendez_vous.emailClient) and Clients.emailClient  =  '" + nom + "'", SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<Rendez_vous> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Rendez_vous image = new();
                    image.idRendezVous = Convert.ToInt32(data.Rows[i]["idRendezVous"]);
                    image.NomClient = Convert.ToString(data.Rows[i]["nomClient"]);
                    image.EmailClient = Convert.ToString(data.Rows[i]["emailClient"]);
                    image.Motif = Convert.ToString(data.Rows[i]["motif"]);
                    image.DateRendezvous = Convert.ToDateTime(data.Rows[i]["dateRendezvous"]);
                    image.informationComplementaire = Convert.ToString(data.Rows[i]["informationComplementaire"]);
                    image.idCategorie = Convert.ToInt32(data.Rows[i]["idCategorie"]);

                    list.Add(image);

                }

            }

            return new JsonResult(list);

        }

        // PUT: api/Rendez_vous/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRendez_vous(int id, Rendez_vous rendez_vous)
        {
            if (id != rendez_vous.idRendezVous)
            {
                return BadRequest();
            }

            _context.Entry(rendez_vous).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Rendez_vousExists(id))
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

        // POST: api/Rendez_vous
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rendez_vous>> PostRendez_vous(Rendez_vous rendez_vous)
        {
            if (rendez_vous == null)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Rendez-vous non accepter", });
            }
            else
            {
                _context.Rendez_vous.Add(rendez_vous);
                await _context.SaveChangesAsync();

                return Ok(new { status = 200, isSuccess = true, message = "Rendez-vous accepter " });
            }
        }

        // DELETE: api/Rendez_vous/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRendez_vous(int id)
        {
            var rendez_vous = await _context.Rendez_vous.FindAsync(id);
            if (rendez_vous == null)
            {
                return NotFound();
            }

            _context.Rendez_vous.Remove(rendez_vous);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Rendez_vousExists(int id)
        {
            return _context.Rendez_vous.Any(e => e.idRendezVous == id);
        }
    }
}
