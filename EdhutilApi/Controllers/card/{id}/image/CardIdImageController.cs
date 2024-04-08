using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Edhutil.Api.Controllers
{
    [ApiController]
    [Route("card/{id}/image")]
    public class CardIdImageController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get
        (
            Guid id,
            [FromQuery(Name="crop")] bool crop = false
        )
        {
            Guid imageGuid = new();
            using (NpgsqlConnection connection = new("Host=localhost;Port=5432;Username=admin;Password=56a16c6a-8813-4204-bec6-5bb3739e356b;Database=edhutil"))
            {
                string query = "SELECT scryfall_id FROM cards WHERE uuid = @Uuid";
                imageGuid = connection.Query<Guid>(query, new { Uuid = id }).FirstOrDefault();
            }
            string imageId = imageGuid.ToString().ToLower();
            string url = string.Empty;
            if (crop)
            {
                url = $"https://cards.scryfall.io/art_crop/front/{imageId[0]}/{imageId[1]}/{imageId}.jpg";
            }
            else
            {
                url = $"https://cards.scryfall.io/large/front/{imageId[0]}/{imageId[1]}/{imageId}.jpg";
            }
            return Ok(url);
        }
    }
}

