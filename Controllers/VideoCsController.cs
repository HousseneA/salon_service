using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
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
    public class VideoCsController : ControllerBase
    {
        private readonly tableContext _context;
        public static IWebHostEnvironment _webHostEnvironment;
        public static IConfiguration _configuration;

        public VideoCsController(tableContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        // GET: api/VideoCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoC>>> GetvideoCategories()
        {
            return await _context.videoCategories.ToListAsync();
        }

        // GET: api/VideoCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoC>> GetVideoC(int id)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from videoCategories,Categories where (videoCategories.idCategorie = Categories.idCategorie) and videoCategories.idCategorie =  " + id, SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<VideoC> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    VideoC video = new();
                    video.idVideo = Convert.ToInt32(data.Rows[i]["idVideo"]);
                    video.videoCategorie = Convert.ToString(data.Rows[i]["videoCategorie"]);

                    list.Add(video);

                }

            }

            return new JsonResult(list);
           
        }

        // PUT: api/VideoCs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoC(int id, [FromForm] VideoC videoC)

        {

            
            if (id != videoC.idVideo)
            {
                return BadRequest();
            }
            if (videoC.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\video\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\video\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\video\\" + videoC.file.FileName))
                {
                    videoC.file.CopyTo(fileStream);
                    fileStream.Flush();



                }
            }
            videoC.videoCategorie = videoC.file.FileName;
            _context.Entry(videoC).State = EntityState.Modified;

            try
            {
               
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoCExists(id))
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

        // POST: api/VideoCs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VideoC>> PostVideoC([FromForm] VideoC videoC)
        {
            if (videoC.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\video\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\video\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\video\\" + videoC.file.FileName))
                {
                    videoC.file.CopyTo(fileStream);
                    fileStream.Flush();



                }
            }
            videoC.videoCategorie = videoC.file.FileName;
            _context.videoCategories.Add(videoC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideoC", new { id = videoC.idVideo }, videoC);
        }

        // DELETE: api/VideoCs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoC(int id)
        {
            var videoC = await _context.videoCategories.FindAsync(id);
            if (videoC == null)
            {
                return NotFound();
            }

            _context.videoCategories.Remove(videoC);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoCExists(int id)
        {
            return _context.videoCategories.Any(e => e.idVideo == id);
        }
    }
}
