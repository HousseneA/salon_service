using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Digests;
using Salon_service.Model;

namespace Salon_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommmandesController : ControllerBase
    {
        private readonly tableContext _context;

        public CommmandesController(tableContext context)
        {
            _context = context;
        }

        // GET: api/Commmandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commmande>>> GetCommmande()
        {
            return await _context.Commmande.ToListAsync();
        }
        [HttpGet("commendeCli/{nom}")]
        public async Task<ActionResult<Commmande>> GetImageC(String? nom)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from Commmande,Clients where (Clients.emailClient=Commmande.emailClient) and Clients.emailClient  =  '" + nom + "'", SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<Commmande> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Commmande image = new();
                    image.IdCommand = Convert.ToInt32(data.Rows[i]["idCommand"]);
                    image.AdressL = Convert.ToString(data.Rows[i]["adressL"]);
                    image.EmailClient = Convert.ToString(data.Rows[i]["emailClient"]);
                    image.NombreCommande = Convert.ToInt32(data.Rows[i]["nombreCommande"]);
                    image.MontantCommande = Convert.ToInt32(data.Rows[i]["montantCommande"]);
                    image.NomArticle = Convert.ToString(data.Rows[i]["nomArticle"]);
                    image.DateCommande = Convert.ToDateTime(data.Rows[i]["dateCommande"]);

                    list.Add(image);

                }

            }

            return new JsonResult(list);

        }
        [HttpGet("commendeNombre/{nom}")]
        public async Task<ActionResult<Commmande>> GetIma(String? nom)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select sum(montantCommande) as nombre from Commmande,Clients where (Clients.emailClient=Commmande.emailClient) and Clients.emailClient  =  '" + nom + "'", SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<Commmande> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Commmande image = new();
                    image.IdCommand = Convert.ToInt32(data.Rows[i]["nombre"]);
 

                    list.Add(image);

                }

            }

            return new JsonResult(list);

        }

        [HttpGet("commendeDate/{nom}")]
        public async Task<ActionResult<Commmande>> Getdate(String? nom)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select Commmande.nomArticle,sum(nombreCommande) as nombre from Commmande,Clients where (Clients.emailClient=Commmande.emailClient) and Clients.emailClient  =  '" + nom + "' group by Commmande.nomArticle,day(Commmande.DateCommande),month(Commmande.DateCommande),year(Commmande.DateCommande)", SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<Commmande> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Commmande image = new();
                    image.NomArticle = Convert.ToString(data.Rows[i]["nomArticle"]);
                    image.NombreCommande = Convert.ToInt32(data.Rows[i]["nombre"]);
                 


                    list.Add(image);

                }

            }

            return new JsonResult(list);

        }
        [HttpGet("commendeDateNow/{email}/{nom}")]
        public async Task<ActionResult<Commmande>> Getdat(String email,DateTime? nom)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select *  from Commmande ,Clients where (Clients.emailClient=Commmande.emailClient) and Clients.emailClient='"+email+"' and dateCommande >='" + nom+ "'", SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<Commmande> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Commmande image = new();

                    image.IdCommand = Convert.ToInt32(data.Rows[i]["idCommand"]);
                    image.AdressL = Convert.ToString(data.Rows[i]["adressL"]);
                    image.EmailClient = Convert.ToString(data.Rows[i]["emailClient"]);
                    image.NombreCommande = Convert.ToInt32(data.Rows[i]["nombreCommande"]);
                    image.NomArticle = Convert.ToString(data.Rows[i]["nomArticle"]);
                    image.DateCommande = Convert.ToDateTime(data.Rows[i]["dateCommande"]);



                    list.Add(image);

                }

            }

            return new JsonResult(list);

        }
        [HttpGet("commendeDate2/{email}/{nom}/{nom1}")]
        public async Task<ActionResult<Commmande>> Getdat2(String email,DateTime? nom, DateTime? nom1)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select *  from Commmande ,Clients where (Clients.emailClient=Commmande.emailClient) and (Clients.emailClient='"+email+ "') and (Commmande.dateCommande BETWEEN '" + nom + "' and '" + nom1 + "')", SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<Commmande> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Commmande image = new();

                    image.IdCommand = Convert.ToInt32(data.Rows[i]["idCommand"]);
                    image.AdressL = Convert.ToString(data.Rows[i]["adressL"]);
                    image.EmailClient = Convert.ToString(data.Rows[i]["emailClient"]);
                    image.NombreCommande = Convert.ToInt32(data.Rows[i]["nombreCommande"]);
                    image.NomArticle = Convert.ToString(data.Rows[i]["nomArticle"]);
                    image.DateCommande = Convert.ToDateTime(data.Rows[i]["dateCommande"]);



                    list.Add(image);

                }

            }

            return new JsonResult(list);

        }

        // GET: api/Commmandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commmande>> GetCommmande(int id)
        {
            var commmande = await _context.Commmande.FindAsync(id);

            if (commmande == null)
            {
                return NotFound();
            }

            return commmande;
        }

        // PUT: api/Commmandes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommmande(int id, Commmande commmande)
        {
            if (id != commmande.IdCommand)
            {
                return BadRequest();
            }

            _context.Entry(commmande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommmandeExists(id))
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

        // POST: api/Commmandes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commmande>> PostCommmande(Commmande commmande)
        {
            _context.Commmande.Add(commmande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommmande", new { id = commmande.IdCommand }, commmande);
        }

        // DELETE: api/Commmandes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommmande(int id)
        {
            var commmande = await _context.Commmande.FindAsync(id);
            if (commmande == null)
            {
                return NotFound();
            }

            _context.Commmande.Remove(commmande);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("sup/{commmande}")]
        public async Task<IActionResult> DeleteC(Commmande commmande)
        {
            var commmand = _context.Commmande.SingleOrDefault(x => x.NombreCommande == commmande.NombreCommande);
            if (commmande == null)
            {
                return NotFound();
            }

            _context.Commmande.Remove(commmande);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool CommmandeExists(int id)
        {
            return _context.Commmande.Any(e => e.IdCommand == id);
        }
    }
}
