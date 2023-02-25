using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KHBackend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class KHAPIController : ControllerBase
    {
        [HttpGet]
        [Route("getUserByEmail/{Email}/{Password}")]
        public IActionResult Test(string email)
        {
             
            return Ok(email);
        }
    }
}
