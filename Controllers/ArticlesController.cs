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
    public class ArticlesController : ControllerBase
    {
        private readonly tableContext _context;
        private readonly tableC1 _tableC1;
        public static IWebHostEnvironment _webHostEnvironment;
        public static IConfiguration _configuration;

        public ArticlesController(tableContext context, tableC1 tableC1, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _tableC1 = tableC1;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticle()
        {
            return await _context.Article.ToListAsync();
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _context.Article.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }
        [HttpGet("article/{id}")]
        public async Task<ActionResult<Article>> GetS(int id)
        {
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from Article,Produit where (Article.idProduit = Produit.idProduit) and Produit.idProduit =  " + id, SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<Article> list = new();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Article article = new();
                    article.idArticle = Convert.ToInt32(data.Rows[i]["idArticle"]);
                    article.NomArticle = Convert.ToString(data.Rows[i]["nomArticle"]);
                    article.PrixArticle = Convert.ToInt32(data.Rows[i]["prixArticle"]);
                    article.NombreArticle = Convert.ToInt32(data.Rows[i]["nombreArticle"]);
                    article.imageArticle = Convert.ToString(data.Rows[i]["imageArticle"]);


                    list.Add(article);

                }

            }

            return new JsonResult(list);
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, [FromForm] Article article)
        {
            if (id != article.idArticle)
            {
                return BadRequest();
            }
            if (article.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\article\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\article\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\article\\" + article.file.FileName))
                {
                    article.file.CopyTo(fileStream);
                    fileStream.Flush();



                }
            }
            article.imageArticle = article.file.FileName;
            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
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

        // POST: api/Articles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle([FromForm] Article article)
        {
            if (article.file.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\article\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\article\\");

                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\projet\\public\\img\\article\\" + article.file.FileName))
                {
                    article.file.CopyTo(fileStream);
                    fileStream.Flush();



                }
            }
            article.imageArticle = article.file.FileName;
            _context.Article.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticle", new { id = article.idArticle }, article);
        }




        [HttpPost]
        [Route("post")]

        public async Task<ActionResult<Article1>> PostArticle1([FromBody] Article1 article1)
        {

            _tableC1.Article.Add(article1);
            await _tableC1.SaveChangesAsync();

            return CreatedAtAction("GetArticle", new { id = article1.idArticle }, article1);
        }


        [HttpPut("put/{id}")]

        public async Task<IActionResult> PutarticleT(int id, Article1 article1)
        {
            if (id != article1.idArticle)
            {
                return BadRequest();
            }

            _tableC1.Entry(article1).State = EntityState.Modified;

            
                await _tableC1.SaveChangesAsync();



            return Ok();
        }




        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _context.Article.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Article.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.idArticle == id);
        }
    }
}
