using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Edhutil.Api
{
    [ApiController]
    [Route("card/random")]
    public class CardRandomController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Card card = new();
            using (NpgsqlConnection connection = new("Host=localhost;Port=5432;Username=admin;Password=56a16c6a-8813-4204-bec6-5bb3739e356b;Database=edhutil"))
            {
                string query = "SELECT * FROM cards ORDER BY RANDOM() LIMIT 1";
                card = connection.Query<Card>(query).FirstOrDefault() ?? new();
            }
            return Ok(card);
        }
    }
}

