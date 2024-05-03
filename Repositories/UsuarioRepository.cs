using MySql.Data.MySqlClient;

namespace JogadorAPI.Repositories
{
    public class UsuarioRepository : Repository<UsuarioRepository>
    {
        private readonly MySqlConnection _connection;

        public UsuarioRepository(MySqlConnection connection) : base(connection)
            => _connection = connection;
    }
}
