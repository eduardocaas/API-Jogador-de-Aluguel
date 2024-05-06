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
    }
}
