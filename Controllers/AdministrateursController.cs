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
    public class AdministrateursController : ControllerBase
    {
        private readonly tableContext _context;

        public AdministrateursController(tableContext context)
        {
            _context = context;
        }

        // GET: api/Administrateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrateur>>> GetAdministrateurs()
        {
            return await _context.Administrateurs.ToListAsync();
        }

        // GET: api/Administrateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrateur>> GetAdministrateur(int id)
        {
            var administrateur = await _context.Administrateurs.FindAsync(id);

            if (administrateur == null)
            {
                return NotFound();
            }

            return administrateur;
        }


        [HttpGet("Cli/{nom}")]
        public JsonResult GEtcli(String? nom)
        {


            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from Administrateurs where emailAdmin ='" + nom + "'", SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<Administrateur> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Administrateur cli = new();
                    cli.idAdmin = Convert.ToInt32(data.Rows[i]["idAdmin"]);
                    cli.NomAdmin = Convert.ToString(data.Rows[i]["nomAdmin"]);
                    cli.EmailAdmin = Convert.ToString(data.Rows[i]["emailAdmin"]);
                    list.Add(cli);

                }

            }

            return new JsonResult(list);

        }

        [HttpPost]
        [Route("Registre")]
        public async Task<ActionResult<Administrateur>> PostClient([FromBody] Administrateur administrateur)
        {
            var account = _context.Clients.SingleOrDefault(x => x.EmailClient == administrateur.EmailAdmin);
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from Administrateurs where emailAdmin ='" + administrateur.EmailAdmin + "'", SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            if (data.Rows.Count > 0)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Invalid User", });
            }
            else
            {
                administrateur.PasswordAdmin = BCrypt.Net.BCrypt.HashPassword(administrateur.PasswordAdmin);
                _context.Administrateurs.Add(administrateur);
                await _context.SaveChangesAsync();
                return Ok(new { status = 200, isSuccess = true, message = "User Login " });

            }
        }

        [Route("Login")]
        public async Task<ActionResult<Administrateur>> Login([FromBody] Administrateur administrateur)
        {
            var account = _context.Administrateurs.SingleOrDefault(x => x.EmailAdmin == administrateur.EmailAdmin);
            // client.PasswordClient = BCrypt.Net.BCrypt.HashPassword(client.PasswordClient);
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            //SqlDataAdapter query = new SqlDataAdapter("select * from Clients where emailClient = " + client.EmailClient, SqlDataSource);
            //DataTable data = new DataTable();
            //query.Fill(data);

            if (account == null || !BCrypt.Net.BCrypt.Verify(administrateur.PasswordAdmin, account.PasswordAdmin))
            {
                // authentication failed
                return Ok(new { status = 401, isSuccess = false, message = "Invalid User", });
            }
            else
            {
                // authentication successful
                return Ok(new { status = 200, isSuccess = true, message = "User Login " });
            }


        }

        // PUT: api/Administrateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrateur(int id, Administrateur administrateur)
        {
            if (id != administrateur.idAdmin)
            {
                return BadRequest();
            }

            _context.Entry(administrateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrateurExists(id))
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

        // POST: api/Administrateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Administrateur>> PostAdministrateur(Administrateur administrateur)
        {
            _context.Administrateurs.Add(administrateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrateur", new { id = administrateur.idAdmin }, administrateur);
        }

        // DELETE: api/Administrateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrateur(int id)
        {
            var administrateur = await _context.Administrateurs.FindAsync(id);
            if (administrateur == null)
            {
                return NotFound();
            }

            _context.Administrateurs.Remove(administrateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministrateurExists(int id)
        {
            return _context.Administrateurs.Any(e => e.idAdmin == id);
        }
    }
}
