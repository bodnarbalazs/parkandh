using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KHBackend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class KHAPIController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {

            return Ok("Anyád");
        }
    }
}
