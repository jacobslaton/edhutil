using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Edhutil.Api.Controllers
{
    [ApiController]
    [Route("card/{id}")]
    public class CardIdController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            Card card = new();
            using (NpgsqlConnection connection = new("Host=localhost;Port=5432;Username=admin;Password=56a16c6a-8813-4204-bec6-5bb3739e356b;Database=edhutil"))
            {
                string query = "SELECT * FROM cards WHERE uuid = @Uuid";
                card = connection.Query<Card>(query, new { Uuid = id }).FirstOrDefault() ?? new();
            }
            return Ok(card);
        }
    }
}

