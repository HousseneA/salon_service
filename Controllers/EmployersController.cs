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
    public class EmployersController : ControllerBase
    {
        private readonly tableContext _context;
        public static IWebHostEnvironment _webHostEnvironment;
        public static IConfiguration _configuration;

        public EmployersController(tableContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        // GET: api/Employers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employer>>> GetEmployer()
        {
            return await _context.Employer.ToListAsync();
        }

        // GET: api/Employers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employer>> GetEmployer(int id)
        {
            var employer = await _context.Employer.FindAsync(id);

            if (employer == null)
            {
                return NotFound();
            }

            return employer;
        }

        [HttpGet("employer/{id}")]
        public async Task<ActionResult<Employer>> GetS(int id)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from Employer,Categories where (Employer.idCategorie = Categories.idCategorie) and Categories.idCategorie =  " + id, SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<Employer> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Employer employer = new();
                    employer.idEmployer = Convert.ToInt32(data.Rows[i]["idEmployer"]);
                    employer.NomEmployer = Convert.ToString(data.Rows[i]["NomEmployer"]);
                    employer.Facebook = Convert.ToString(data.Rows[i]["Facebook"]);
                    employer.Linkedin = Convert.ToString(data.Rows[i]["Linkedin"]);
                    employer.Email = Convert.ToString(data.Rows[i]["Email"]);
                    employer.Titre = Convert.ToString(data.Rows[i]["Titre"]);
                    employer.imageEmployer = Convert.ToString(data.Rows[i]["imageEmployer"]);

                    list.Add(employer);

                }

            }

            return new JsonResult(list);
        }

        // PUT: api/Employers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployer(int id,[FromForm] Employer employer)
        {
            if (id != employer.idEmployer)
            {
                return BadRequest();
            }
            if (employer.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\employer\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\employer\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\employer\\" + employer.file.FileName))
                {
                    employer.file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }

            employer.imageEmployer = employer.file.FileName;

            _context.Entry(employer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(id))
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

        // POST: api/Employers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employer>> PostEmployer([FromForm] Employer employer)
        {

            if (employer.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\employer\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\employer\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\employer\\" + employer.file.FileName))
                {
                    employer.file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }

            employer.imageEmployer = employer.file.FileName;
            _context.Employer.Add(employer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployer", new { id = employer.idEmployer }, employer);
        }

        // DELETE: api/Employers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployer(int id)
        {
            var employer = await _context.Employer.FindAsync(id);
            if (employer == null)
            {
                return NotFound();
            }

            _context.Employer.Remove(employer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployerExists(int id)
        {
            return _context.Employer.Any(e => e.idEmployer == id);
        }
    }
}
