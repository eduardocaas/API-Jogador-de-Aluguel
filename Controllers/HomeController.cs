using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JogadorAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Get()
            => Ok(new { status = "API is up to date", date = DateTime.Now.ToString("dd/MM/yyyy - HH:mm") });
    }
}
