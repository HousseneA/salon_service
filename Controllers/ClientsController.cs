using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Salon_service.Model;
using System.Data;
using HttpClientService;
namespace Salon_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly tableContext _context;
        public static IWebHostEnvironment _webHostEnvironment;
        public static IConfiguration _configuration;
   


        public ClientsController(tableContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
    
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }
        [HttpGet("Cli/{nom}")]
        public JsonResult GEtcli(String? nom)
        {
           

            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from Clients where emailClient ='" + nom + "'", SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            List<Client> list = new();
            if (data.Rows.Count > 0)
            {
                for(int i =0;i< data.Rows.Count; i++)
                {
                    Client cli = new();
                    cli.idClient = Convert.ToInt32(data.Rows[i]["idClient"]);
                    cli.NomClient = Convert.ToString(data.Rows[i]["nomClient"]);
                    cli.EmailClient = Convert.ToString(data.Rows[i]["emailClient"]);
                    list.Add(cli);

                }

            }
           
                return new JsonResult(list);
           
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.idClient)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Registre")]
        public async Task<ActionResult<Client>> PostClient([FromBody] Client client)
        {
            var account = _context.Clients.SingleOrDefault(x => x.EmailClient == client.EmailClient);
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            SqlDataAdapter query = new SqlDataAdapter("select * from Clients where emailClient ='" + client.EmailClient + "'", SqlDataSource);
            DataTable data = new DataTable();
            query.Fill(data);
            if (data.Rows.Count > 0)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Invalid User", });
            }
            else
            {
                client.PasswordClient = BCrypt.Net.BCrypt.HashPassword(client.PasswordClient);
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return Ok(new { status = 200, isSuccess = true, message = "User Login " });

            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Client>> Login([FromBody] Client client)
        {
            var account = _context.Clients.SingleOrDefault(x => x.EmailClient == client.EmailClient);
            // client.PasswordClient = BCrypt.Net.BCrypt.HashPassword(client.PasswordClient);
            SqlConnection SqlDataSource = new SqlConnection("Data Source=localhost;Initial Catalog=isalo;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            //SqlDataAdapter query = new SqlDataAdapter("select * from Clients where emailClient = " + client.EmailClient, SqlDataSource);
            //DataTable data = new DataTable();
            //query.Fill(data);

            if (account == null || !BCrypt.Net.BCrypt.Verify(client.PasswordClient, account.PasswordClient))
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
        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.idClient == id);
        }
    }
}
