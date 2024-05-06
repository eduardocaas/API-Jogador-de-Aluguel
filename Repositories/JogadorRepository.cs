using Dapper;
using JogadorAPI.Models;
using MySql.Data.MySqlClient;

namespace JogadorAPI.Repositories
{
    public class JogadorRepository : Repository<Jogador>
    {

        private readonly MySqlConnection _connection;

        public JogadorRepository(MySqlConnection connection) : base(connection)
            => _connection = connection;

        public dynamic Create(Jogador jogador)
        {
            string sql = @"INSERT INTO Jogador 
                               (EMAIL, TELEFONE, CPF, NOME, SENHA, CIDADE, BAIRRO, POSICAO) 
                           VALUES 
                               (@Email, @Telefone, @CPF, @Nome, @Senha, @Cidade, @Bairro, @Posicao)";

            var data = new
            {
                Email = jogador.Email,
                Telefone = jogador.Telefone,
                CPF = jogador.CPF,
                Nome = jogador.Nome,
                Senha = jogador.Senha,
                Cidade = jogador.Cidade,
                Bairro = jogador.Bairro,
                Posicao = jogador.Posicao
            };

            var rowsAffected = _connection.Execute(sql, data);
            return rowsAffected;
        }

    }
}
