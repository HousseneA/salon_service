using System;
using System.Collections.Generic;
using System.Data.Common;
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
    public class IconCsController : ControllerBase
    {
        private readonly tableContext _context;
        public static IWebHostEnvironment _webHostEnvironment;
        public static IConfiguration _configuration;

        public IconCsController(tableContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        // GET: api/IconCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IconC>>> GetIconCategories()
        {
            return await _context.IconCategories.ToListAsync();
        }

        // GET: api/IconCs/5
        [HttpGet("profil/{id}")]
        public async Task<ActionResult<IconC>> GetIconC(int id)
        {
            List<IconC> list = new List<IconC>();

            var connex = _context.Database.GetDbConnection();

            connex.Open();
            using (var con = connex.CreateCommand())
            {
                String query = "select idIcon,iconCategorie from IconCategories,Categories where (IconCategories.idCategorie = Categories.idCategorie) and Categories.idCategorie =  " + id;
                con.CommandText = query;
                DbDataReader reader = await con.ExecuteReaderAsync();
                if (reader.Read())
                {
                    while (await reader.ReadAsync())
                    {
                        var row = new IconC
                        {
                            idIcon = reader.GetInt32(0),
                            iconCategorie = reader.GetString(1),

                        };
                        list.Add(row);

                    }
                }
                reader.DisposeAsync();
            }
            return new JsonResult(list);
        }

        // PUT: api/IconCs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIconC(int id, IconC iconC)
        {
            if (id != iconC.idIcon)
            {
                return BadRequest();
            }
            if (iconC.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\assets2\\img\\icon\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\assets2\\img\\icon\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\assets2\\img\\icon\\" + iconC.file.FileName))
                {
                    iconC.file.CopyTo(fileStream);
                    fileStream.Flush();



                }
            }

            iconC.iconCategorie = iconC.file.FileName;

            _context.Entry(iconC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IconCExists(id))
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

        // POST: api/IconCs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IconC>> PostIconC([FromForm] IconC iconC)
        {
            if (iconC.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\assets2\\img\\icon\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\assets2\\img\\icon\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\assets2\\img\\icon\\" + iconC.file.FileName))
                {
                    iconC.file.CopyTo(fileStream);
                    fileStream.Flush();



                }
            }

            iconC.iconCategorie = iconC.file.FileName;
            _context.IconCategories.Add(iconC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIconC", new { id = iconC.idIcon }, iconC);
        }

        // DELETE: api/IconCs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIconC(int id)
        {
            var iconC = await _context.IconCategories.FindAsync(id);
            if (iconC == null)
            {
                return NotFound();
            }

            _context.IconCategories.Remove(iconC);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IconCExists(int id)
        {
            return _context.IconCategories.Any(e => e.idIcon == id);
        }
    }
}
