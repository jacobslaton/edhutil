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
            LeadershipSkills card = new();
            using (NpgsqlConnection connection = new("Host=localhost;Port=5432;Username=admin;Password=a4bf0a0c-3a67-40df-b0d6-1264e514cc4b;Database=edhutil"))
            {
                string query = "SELECT leadershipskills FROM cards ORDER BY RANDOM() LIMIT 1";
                card = connection.Query<LeadershipSkills>(query).FirstOrDefault() ?? new();
            }
            return Ok(card);
        }
    }
}

