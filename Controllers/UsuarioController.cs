using JogadorAPI.Models;
using JogadorAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Net.Mime;

namespace JogadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpPost]
        [Route("cadastro")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Cadastro(
            [FromBody] Usuario usuario,
            [FromServices] MySqlConnection connection)
        {
            UsuarioRepository repository = new UsuarioRepository(connection);
            var rows = repository.Create(usuario);
            return Ok(rows);
        }
    }
}
