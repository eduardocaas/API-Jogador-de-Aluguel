using Dapper;
using JogadorAPI.DBModels;
using JogadorAPI.Models;
using JogadorAPI.ViewModels;
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

        public dynamic SelectEvento(int id) // Visão de Usuário
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

        public dynamic SelectIdEvento(int usuarioId)
        {
            var sql = @"SELECT 
                            ID_EVENTO
                        FROM
                            Evento
                        WHERE 
                            USUARIO_ID = @UsuarioId
                        LIMIT 1";

            var model = _connection.Query(sql, new { UsuarioId = usuarioId });
            dynamic? id = model.FirstOrDefault().ID_EVENTO;
            return id;
        }

        public dynamic SelectEventoList(string cidade, byte posicao) // Visão de Jogador
        {
            string sql = @" 
                        SELECT
                            e.ID_EVENTO,
                            e.DESCRICAO,
                            e.CIDADE,
                            e.BAIRRO,
                            e.HORARIO,
                            e.DURACAO_MINUTOS,
                            e.POSICAO,
                            e.CUSTO,
                            u.NOME AS 'NOME_USUARIO' 
                        FROM 
                            EVENTO e 
                        LEFT JOIN 
                            Usuario u 
                        ON 
                            e.USUARIO_ID = u.ID_USUARIO 
                        WHERE 
                            e.JOGADOR_ID IS NULL
                        AND 
                            e.CIDADE = @Cidade 
                        AND 
                            e.POSICAO = @Posicao
                        AND 
                            e.STATUS = 0";

            IEnumerable<dynamic> models = _connection.Query(sql, new { Cidade = cidade, Posicao = posicao });
            var modelList = models.ToList();

            if (modelList.Count != 0)
            {
                List<EventoJogadorViewModel> eventos = new List<EventoJogadorViewModel>();
                eventos = modelList.Select(item =>
                    new EventoJogadorViewModel(
                        IdEvento: item.ID_EVENTO,
                        Descricao: item.DESCRICAO,
                        Cidade: item.CIDADE,
                        Bairro: item.BAIRRO,
                        Horario: item.HORARIO,
                        DuracaoMinutos: item.DURACAO_MINUTOS,
                        Posicao: item.POSICAO,
                        Custo: item.CUSTO,
                        NomeUsuario: item.NOME_USUARIO)).ToList();

                return eventos;
            }

            return new List<EventoJogadorViewModel>();
        }
    }
}
