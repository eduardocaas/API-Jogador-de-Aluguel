using Dapper;
using JogadorAPI.DTO;
using JogadorAPI.Models;
using MySql.Data.MySqlClient;
using Opw.HttpExceptions;

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

        public string GetPasswordByEmail(string email)
        {
            var query = @"SELECT SENHA FROM Jogador WHERE Jogador.EMAIL = @Email";

            var hashSenha = _connection.Query<dynamic>(query, new { Email = email });
            if (hashSenha.FirstOrDefault() == null)
                throw new BadRequestException("Email ou senha incorretos");

            return hashSenha.FirstOrDefault().SENHA;
        }

        public LoginSessionDTO GetSessionLoginByEmail(string email)
        {
            var query = @"SELECT ID_JOGADOR, EMAIL FROM Jogador WHERE Jogador.EMAIL = @Email";

            var result = _connection.Query<dynamic>(query, new { Email = email });

            LoginSessionDTO loginSession = new LoginSessionDTO();
            loginSession.Id = result.FirstOrDefault().ID_JOGADOR;
            loginSession.Email = result.FirstOrDefault().EMAIL;

            return loginSession;
        }

    }
}
