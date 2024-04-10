using Microsoft.AspNetCore.Mvc;

namespace Edhutil.Api.Controllers
{
    [ApiController]
    [Route("card/{id}/image")]
    public class CardIdImageController : ControllerBase
    {
        private readonly Services.CardProvider _cardProvider;

        public CardIdImageController(Services.CardProvider cardProvider)
        {
            _cardProvider = cardProvider;
        }

        [HttpGet]
        public IActionResult Get
        (
            Guid id,
            [FromQuery(Name="crop")] bool crop = false
        )
        {
            Guid imageGuid = _cardProvider.GetScryfallIdByUuid(id);
            string imageId = imageGuid.ToString().ToLower();
            if (crop)
            {
                return Ok($"https://cards.scryfall.io/art_crop/front/{imageId[0]}/{imageId[1]}/{imageId}.jpg");
            }
            return Ok($"https://cards.scryfall.io/large/front/{imageId[0]}/{imageId[1]}/{imageId}.jpg");
        }
    }
}

