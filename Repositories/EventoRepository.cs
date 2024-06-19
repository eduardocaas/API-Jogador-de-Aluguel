using JogadorAPI.Models;
using MySql.Data.MySqlClient;

namespace JogadorAPI.Repositories
{
    public class EventoRepository : Repository<Evento>
    {
        private readonly MySqlConnection _connection;

        public EventoRepository(MySqlConnection connection) : base(connection)
            => _connection = connection;
        public dynamic Create(Evento evento)
        {
            string sql1 = @"INSERT INTO Evento
                            (USUARIO_ID, 
                             CIDADE, 
                             BAIRRO, 
                             HORARIO, 
                             DURACAO_MINUTOS,
                             DESCRICAO,
                             POSICAO) 
                           VALUES
                            (@UsuarioId, 
                             @Cidade, 
                             @Bairro, 
                             @Horario, 
                             @Duracao, 
                             @Descricao,
                             @Posicao)";

            var data = new
            {
                UsuarioId = evento.IdUsuario,
                Cidade = evento.Cidade,
                Bairro = evento.Bairro,
                Horario = evento.Horario,
                Duracao = evento.DuracaoMinutos,
                Descricao = evento.Descricao,
                Posicao = evento.Posicao
            };
        }

        public dynamic SelectEvento(int id)
        {

        }
    }
}
