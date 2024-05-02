using MySql.Data.MySqlClient;

namespace JogadorAPI.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly MySqlConnection _connection;

        public Repository(MySqlConnection connection)
            => _connection = connection;
    }
}
