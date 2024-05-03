using JogadorAPI.DTO;
using JogadorAPI.Models;
using JogadorAPI.Repositories;
using MySql.Data.MySqlClient;
using Opw.HttpExceptions;
using Scrypt;

namespace JogadorAPI.Services
{
    public static class UsuarioService
    {
        public static void Create(
            Usuario usuario, 
            MySqlConnection connection)
        {
            UsuarioRepository repository = new UsuarioRepository(connection);
            ScryptEncoder encoder = new ScryptEncoder();

            string hashSenha = encoder.Encode(usuario.Senha);
            usuario.Senha = hashSenha;

            var rows = repository.Create(usuario);
            if (rows == 0)
                throw new HttpException("Falha ao salvar dados no banco de dados, tente novamente mais tarde");
        }

        public static LoginSessionDTO Login(
            LoginDTO login,
            MySqlConnection connection)
        {
            UsuarioRepository repository = new UsuarioRepository(connection);
            ScryptEncoder encoder = new ScryptEncoder();

            string hashSenha = repository.GetPasswordByEmail(login.Email);

            bool areEquals = encoder.Compare(login.Senha, hashSenha);
            if (areEquals == true)
                return repository.GetSessionLoginByEmail(login.Email);

            return new LoginSessionDTO { Id = 0, Email = "null"};
        }
    }
}
