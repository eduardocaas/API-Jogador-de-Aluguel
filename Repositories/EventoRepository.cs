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
        }

        public dynamic SelectEvento(int id)
        {

        }
    }
}
