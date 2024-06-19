using JogadorAPI.DTO;
using JogadorAPI.InputModels;
using JogadorAPI.Models;
using JogadorAPI.Repositories;
using MySql.Data.MySqlClient;
using Opw.HttpExceptions;
using Scrypt;

namespace JogadorAPI.Services
{
    public static class JogadorService
    {
        public static void Create(
            Jogador jogador,
            MySqlConnection connection)
        {
            JogadorRepository repository = new JogadorRepository(connection);
            ScryptEncoder encoder = new ScryptEncoder();

            string hashSenha = encoder.Encode(jogador.Senha);
            jogador.Senha = hashSenha;

            var rows = repository.Create(jogador);
            if (rows == 0)
                throw new HttpException("Falha ao salvar dados no banco de dados, tente novamente mais tarde");
        }

        public static LoginSessionDTO Login(
            LoginInputModel login,
            MySqlConnection connection)
        {
            JogadorRepository repository = new JogadorRepository(connection);
            ScryptEncoder encoder = new ScryptEncoder();

            string hashSenha = repository.GetPasswordByEmail(login.Email);

            bool areEquals = encoder.Compare(login.Senha, hashSenha);
            if (areEquals == true)
                return repository.GetSessionLoginByEmail(login.Email);

            return new LoginSessionDTO { Id = 0, Email = "null" };
        }
    }
}
