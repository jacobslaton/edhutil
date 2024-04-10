using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Edhutil.Api.Controllers
{
    [ApiController]
    [Route("card/{id}")]
    public class CardIdController : ControllerBase
    {
        private Services.CardProvider _cardProvider;

        public CardIdController(Services.CardProvider cardProvider)
        {
            _cardProvider = cardProvider;
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return Ok(_cardProvider.GetCardByUuid(id));
        }
    }
}

