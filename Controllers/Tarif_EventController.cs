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
    public class Tarif_EventController : ControllerBase
    {
        private readonly tableContext _context;
        public static IWebHostEnvironment _webHostEnvironment;
        public static IConfiguration _configuration;
        public Tarif_EventController(tableContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        // GET: api/Tarif_Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarif_Event>>> GetTarif_Event()
        {
            return await _context.Tarif_Event.ToListAsync();
        }

        // GET: api/Tarif_Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarif_Event>> GetTarif_Event(int id)
        {
            var tarif_Event = await _context.Tarif_Event.FindAsync(id);

            if (tarif_Event == null)
            {
                return NotFound();
            }

            return tarif_Event;
        }
        [HttpGet("tarif/{id}")]
        public async Task<ActionResult<Tarif_Event>> GetTarif(int id)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from Tarif_Event,Categories where (Tarif_Event.idCategorie = Categories.idCategorie) and Categories.idCategorie =  " + id, SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<Tarif_Event> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Tarif_Event tarif_Event = new();
                    tarif_Event.idtarifEvent = Convert.ToInt32(data.Rows[i]["idtarifEvent"]);
                    tarif_Event.NomTarifEvent = Convert.ToString(data.Rows[i]["NomTarifEvent"]);
                    tarif_Event.DescriptionTarifEvent = Convert.ToString(data.Rows[i]["DescriptionTarifEvent"]);
                    tarif_Event.imageTarifEvent = Convert.ToString(data.Rows[i]["imageTarifEvent"]);
                    tarif_Event.PrixTarif = Convert.ToInt32(data.Rows[i]["PrixTarif"]);
                    list.Add(tarif_Event);

                }

            }
            return new JsonResult(list);
        }

        // PUT: api/Tarif_Event/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarif_Event(int id, [FromForm] Tarif_Event tarif_Event)
        {
            if (id != tarif_Event.idtarifEvent)
            {
                return BadRequest();
            }
            if (tarif_Event.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\tarif\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\tarif\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\tarif\\" + tarif_Event.file.FileName))
                {
                    tarif_Event.file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }

            tarif_Event.imageTarifEvent = tarif_Event.file.FileName;
            _context.Entry(tarif_Event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tarif_EventExists(id))
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

        // POST: api/Tarif_Event
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tarif_Event>> PostTarif_Event([FromForm] Tarif_Event tarif_Event)
        {
            if (tarif_Event.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\tarif\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\tarif\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\tarif\\" + tarif_Event.file.FileName))
                {
                    tarif_Event.file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }

            tarif_Event.imageTarifEvent = tarif_Event.file.FileName;
            _context.Tarif_Event.Add(tarif_Event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarif_Event", new { id = tarif_Event.idtarifEvent }, tarif_Event);
        }

        // DELETE: api/Tarif_Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarif_Event(int id)
        {
            var tarif_Event = await _context.Tarif_Event.FindAsync(id);
            if (tarif_Event == null)
            {
                return NotFound();
            }

            _context.Tarif_Event.Remove(tarif_Event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Tarif_EventExists(int id)
        {
            return _context.Tarif_Event.Any(e => e.idtarifEvent == id);
        }
    }
}
