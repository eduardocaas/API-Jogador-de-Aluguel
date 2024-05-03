using JogadorAPI.DTO;
using JogadorAPI.Models;
using JogadorAPI.Repositories;
using JogadorAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Opw.HttpExceptions;
using System.Data.Common;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Cadastro(
            [FromBody] Usuario usuario,
            [FromServices] MySqlConnection connection)
        {
            try
            {
                UsuarioService.Create(usuario, connection);
                return Ok(new
                {
                    message = "Usuário criado com sucesso",
                    date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                });
            }
            catch (HttpException hException)
            {
                return StatusCode((int)hException.StatusCode, new
                {
                    message = hException.Message,
                    date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                });
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("Duplicate"))
                {
                    return StatusCode(StatusCodes.Status409Conflict, new
                    {
                        message = exception.Message,
                        date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                    });
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = exception.Message,
                    date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                });
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(
            [FromBody] LoginDTO login,
            [FromServices] MySqlConnection connection)
        {
            try
            {
                LoginSessionDTO sessionDTO = UsuarioService.Login(login, connection);
                if (sessionDTO.Id == 0 && sessionDTO.Email.Equals("null"))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new
                    {
                        message = "Login ou senha incorretos",
                        date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                    });
                }
                return Ok(sessionDTO);
            }
            catch (BadRequestException badException)
            {
                return StatusCode((int)badException.StatusCode, new
                {
                    message = badException.Message,
                    date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                });
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = exception.Message,
                    date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                });
            }
        }
    }
}
