using Dapper;
using Npgsql;

namespace Edhutil.Api.Services
{
    public class CardProvider
    {
        private string _connectionString = string.Empty;

        public CardProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CardProvider
        (
            string hostname,
            string port,
            string username,
            string password,
            string database
        )
        {
            _connectionString = $"Host={hostname};Port={port};Username={username};Password={password};Database={database}";
        }

        public Models.Card GetCardByUuid(Guid id)
        {
            Models.Card card = new();
            string query = "SELECT * FROM cards WHERE uuid = @Uuid";
            using (NpgsqlConnection connection = new(_connectionString))
            {
                card = connection
                    .Query<Models.Card>(query, new { Uuid = id })
                    .FirstOrDefault() ?? new();
            }
            return card;
        }

        public Models.Card GetRandomCard()
        {
            Models.Card card = new();
            string query = "SELECT * FROM cards ORDER BY RANDOM() LIMIT 1";
            using (NpgsqlConnection connection = new(_connectionString))
            {
                card = connection
                    .Query<Models.Card>(query)
                    .FirstOrDefault() ?? new();
            }
            return card;
        }

        public Guid GetScryfallIdByUuid(Guid id)
        {
            Guid scryfallId = new();
            string query = "SELECT scryfall_id FROM cards WHERE uuid = @Uuid";
            using (NpgsqlConnection connection = new(_connectionString))
            {
                scryfallId = connection
                    .Query<Guid>(query, new { Uuid = id })
                    .FirstOrDefault();
            }
            return scryfallId;
        }
    }
}

