using JogadorAPI.Models;
using JogadorAPI.Util;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Opw.HttpExceptions;

namespace JogadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
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
