using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Salon_service.Model;

namespace Salon_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageGsController : ControllerBase
    {
        private readonly tableContext _context;
        public static IWebHostEnvironment _webHostEnvironment;
        public static IConfiguration _configuration;

        public ImageGsController(tableContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        // GET: api/ImageGs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageG>>> GetImageG()
        {
            return await _context.ImageG.ToListAsync();
        }

        // GET: api/ImageGs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageG>> GetImageG(int id)
        {
            var imageG = await _context.ImageG.FindAsync(id);

            if (imageG == null)
            {
                return NotFound();
            }

            return imageG;
        }
        [HttpGet("ImageG/{id}")]
        public async Task<ActionResult<ImageG>> GetImageC(int? id)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from ImageG,Categories where (ImageG.idCategorie = Categories.idCategorie) and Categories.idCategorie =  " + id, SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<ImageG> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    ImageG image = new();
                    image.idImage = Convert.ToInt32(data.Rows[i]["idImage"]);
                    image.ImageGallery = Convert.ToString(data.Rows[i]["ImageGallery"]);

                    list.Add(image);

                }

            }

            return new JsonResult(list);

        }
        // PUT: api/ImageGs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageG(int id, [FromForm] ImageG imageG)
        {
            if (id != imageG.idImage)
            {
                return BadRequest();
            }
            if (imageG.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\gallery\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\gallery\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\gallery\\" + imageG.file.FileName))
                {
                    imageG.file.CopyTo(fileStream);
                    fileStream.Flush();



                }
            }

            imageG.ImageGallery = imageG.file.FileName;

            _context.Entry(imageG).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageGExists(id))
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

        // POST: api/ImageGs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageG>> PostImageG([FromForm] ImageG imageG)
        {
            if (imageG.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\gallery\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\gallery\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\gallery\\" + imageG.file.FileName))
                {
                    imageG.file.CopyTo(fileStream);
                    fileStream.Flush();



                }
            }

            imageG.ImageGallery = imageG.file.FileName;
            _context.ImageG.Add(imageG);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageG", new { id = imageG.idImage }, imageG);
        }

        // DELETE: api/ImageGs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageG(int id)
        {
            var imageG = await _context.ImageG.FindAsync(id);
            if (imageG == null)
            {
                return NotFound();
            }

            _context.ImageG.Remove(imageG);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageGExists(int id)
        {
            return _context.ImageG.Any(e => e.idImage == id);
        }
    }
}
