using Microsoft.AspNetCore.Mvc;

namespace Edhutil.Api.Controllers
{
    [ApiController]
    [Route("card/random")]
    public class CardRandomController : ControllerBase
    {
        private readonly Services.CardProvider _cardProvider;

        public CardRandomController(Services.CardProvider cardProvider)
        {
            _cardProvider = cardProvider;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cardProvider.GetRandomCard());
        }
    }
}

