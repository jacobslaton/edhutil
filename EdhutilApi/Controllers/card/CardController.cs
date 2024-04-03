using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edhutil.Api.Controllers
{
    [ApiController]
    [Route("card")]
    public class CardController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello API!");
        }

        [HttpGet("{id}")]
        public string Get(string id)
        {
            return $"Hello with ID {id}.";
        }
    }
}

