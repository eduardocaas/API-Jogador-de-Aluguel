using Dapper;
using JogadorAPI.DBModels;
using JogadorAPI.Models;
using MySql.Data.MySqlClient;
using System.Data;

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

            var rows = _connection.Execute(sql1, data);
            if (rows != 0)
            {
                var sql2 = "SELECT LAST_INSERT_ID()";
                var id = _connection.QuerySingle<int>(sql2);

                return id;
            }
            return 0;
        }

        public dynamic SelectEvento(int id)
        {
            string sql = @"GetEventoJogador";
            var pars = new { IdEvento = id };

            var dbModel = _connection.Query(
                sql,
                pars,
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return new EventoSelectDbModel(
                dbModel.ID_EVENTO,
                dbModel.DESCRICAO,
                dbModel.CIDADE,
                dbModel.BAIRRO,
                dbModel.HORARIO,
                //DateTime.ParseExact(dbModel.HORARIO, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                (ushort)dbModel.DURACAO_MINUTOS,
                (byte)dbModel.POSICAO,
                (ushort)dbModel.CUSTO,
                dbModel.NOME_JOGADOR);
        }
    }
}
