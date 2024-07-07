using JogadorAPI.InputModels;
using JogadorAPI.Models;
using JogadorAPI.Services;
using JogadorAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Opw.HttpExceptions;
using System.Net.Mime;

namespace JogadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create(
            [FromBody] EventoInputModel inputModel,
            [FromServices] MySqlConnection connection)
        {
            try
            {
                Evento evento = new Evento(
                                inputModel.IdUsuario,
                                inputModel.Cidade,
                                inputModel.Bairro,
                                inputModel.Horario,
                                inputModel.DuracaoMinutos,
                                inputModel.Descricao,
                                inputModel.Posicao);

                EventoSelectViewModel model = EventoService.Create(evento, connection);
                return Ok(model);
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
                if (exception.Message.Contains("foreign"))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new
                    {
                        message = "Id de usuário inválido",
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

        [HttpGet]
        [Route("{usuarioId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(
            [FromRoute] int usuarioId,
            [FromServices] MySqlConnection connection) // Get visão de Usuário - retorna Evento
        {
            try
            {
                EventoSelectViewModel model = EventoService.GetEventoUsuario(usuarioId, connection);
                return Ok(model);
            }
            catch (NotFoundException nfException)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = nfException,
                    date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                });
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("binding on a null"))
                {
                    return StatusCode(StatusCodes.Status404NotFound, new
                    {
                        message = $"Evento para usuário com id: {usuarioId} não encontrado",
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(
            [FromQuery] string cidade,
            [FromQuery] byte posicao)
        {
            try
            {
                List<EventoJogadorViewModel> eventos = EventoService.GetEventosJogador(cidade, posicao, connection);
                if (eventos.Count == 0)
                    return NoContent();

                return Ok(eventos);
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            throw new NotImplementedException();
            // Retorna evento apenas para jogador -> escalado -> retorna 404 se nao tiver escalado
            
        }
    }
}
