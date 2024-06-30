using JogadorAPI.DBModels;
using JogadorAPI.Models;
using JogadorAPI.Repositories;
using JogadorAPI.ViewModels;
using MySql.Data.MySqlClient;
using Opw.HttpExceptions;

namespace JogadorAPI.Services
{
    public static class EventoService
    {
        public static EventoSelectViewModel Create(
            Evento evento,
            MySqlConnection connection)
        {
            EventoRepository repository = new EventoRepository(connection);
            var id = repository.Create(evento);
            if (id == 0 || id == null)
                throw new HttpException("Falha ao salvar dados no banco de dados, tente novamente mais tarde");

            EventoSelectDbModel eventoSelect = repository.SelectEvento(id);

            return new EventoSelectViewModel(
                eventoSelect.ID_EVENTO,
                eventoSelect.DESCRICAO,
                eventoSelect.CIDADE,
                eventoSelect.BAIRRO,
                eventoSelect.HORARIO,
                eventoSelect.DURACAO_MINUTOS,
                eventoSelect.POSICAO,
                eventoSelect.CUSTO,
                eventoSelect.NOME_JOGADOR);
        }

        public static EventoSelectViewModel GetEventoUsuario(
            int usuarioId,
            MySqlConnection connection)
        {
            EventoRepository repository = new EventoRepository(connection);
            int? eventoId = repository.SelectIdEvento(usuarioId);
            if (eventoId == 0 || eventoId == null)
                throw new NotFoundException($"Evento para usuário com id: {usuarioId} não encontrado");

            EventoSelectDbModel eventoSelect = repository.SelectEvento((int)eventoId);

       

            return new EventoSelectViewModel(
                eventoSelect.ID_EVENTO,
                eventoSelect.DESCRICAO,
                eventoSelect.CIDADE,
                eventoSelect.BAIRRO,
                eventoSelect.HORARIO,
                eventoSelect.DURACAO_MINUTOS,
                eventoSelect.POSICAO,
                eventoSelect.CUSTO,
                eventoSelect.NOME_JOGADOR);
        }
    }
}
