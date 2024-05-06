using JogadorAPI.Models;
using JogadorAPI.Services;
using JogadorAPI.Util;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Opw.HttpExceptions;
using System.Net.Mime;

namespace JogadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {

        [HttpPost]
        [Route("cadastro")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Cadastro(
            [FromBody] Jogador jogador,
            [FromServices] MySqlConnection connection)
        {
            try
            {
                if (!CpfUtil.IsCpf(jogador.CPF))
                {
                    return BadRequest(new
                    {
                        message = "Informe um CPF válido",
                        date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                    });
                }

                JogadorService.Create(jogador, connection);
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
    }
}
