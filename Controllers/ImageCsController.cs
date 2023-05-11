using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

using Salon_service.Model;
using System.Data.Common;
using System.Data;

namespace Salon_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageCsController : ControllerBase
    {
        private readonly tableContext _context;
        public static IWebHostEnvironment _webHostEnvironment;
        public static IConfiguration _configuration;
        public ImageCsController(tableContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        public List<ImageC> listS = new List<ImageC>();
        // GET: api/ImageCs
        [HttpGet]
        public JsonResult OnGet()
        {
            listS = Affichage();
            return new JsonResult(listS);
        }
        public static List<ImageC> Affichage()
        {
            List<ImageC> list = new List<ImageC>();
       
            String SqlDataSource = "Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False";
            String query = "select * from ImageCategories";

            using (SqlConnection con = new SqlConnection(SqlDataSource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        while (lecteur.Read())
                        {
                            ImageC site = new ImageC();
                            site.idImage = Convert.ToInt32(lecteur["idImage"]);
                            site.ImageCategorie = Convert.ToString(lecteur["ImageCategorie"]);
                            site.idCategorie = Convert.ToInt32(lecteur["idCategorie"]);
                           
                            list.Add(site);
                        }
                    }
                }
            }
            return list;
        }
         public async Task<ActionResult<IEnumerable<ImageC>>> GetImageCategories()
         {
             return await _context.ImageCategories.ToListAsync();
         }

         // GET: api/ImageCs/5
         [HttpGet("{id}")]
         public async Task<ActionResult<ImageC>> GetImageC(int? id)
         {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from ImageCategories,Categories where (ImageCategories.idCategorie = Categories.idCategorie) and Categories.idCategorie =  " + id, SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<ImageC> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    ImageC image = new();
                    image.idImage = Convert.ToInt32(data.Rows[i]["idImage"]);
                    image.ImageCategorie = Convert.ToString(data.Rows[i]["ImageCategorie"]);

                    list.Add(image);

                }

            }

            return new JsonResult(list);
           
        }
        
        // PUT: api/ImageCs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageC(int id,[FromForm] ImageC imageC)
        {
            if (id != imageC.idImage)
            {
                return BadRequest();
            }
            if (imageC.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\image\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\image\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\image\\" + imageC.file.FileName))
                {
                    imageC.file.CopyTo(fileStream);
                    fileStream.Flush();



                }
            }

            imageC.ImageCategorie = imageC.file.FileName;

            _context.Entry(imageC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageCExists(id))
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

        // POST: api/ImageCs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageC>> PostImageC([FromForm] ImageC imageC)
        {
            
                if (imageC.file.Length > 0)
                {
                    if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\image\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\image\\");

                    }
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\image\\" + imageC.file.FileName))
                    {
                        imageC.file.CopyTo(fileStream);
                        fileStream.Flush();

                       

                    }
                }

            imageC.ImageCategorie = imageC.file.FileName;
            
            _context.ImageCategories.Add(imageC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageC", new { id = imageC.idImage }, imageC);
        }

        // DELETE: api/ImageCs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageC(int id)
        {
            var imageC = await _context.ImageCategories.FindAsync(id);
            if (imageC == null)
            {
                return NotFound();
            }

            _context.ImageCategories.Remove(imageC);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageCExists(int id)
        {
            return _context.ImageCategories.Any(e => e.idImage == id);
        }
    }
}
