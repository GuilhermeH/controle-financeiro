using controle.financeiro.domain.Entities;
using MongoDB.Driver;

namespace controle.financeiro.infra.Context
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(string user, string password, string connectTo, string dataBase, string port)
        {
            var urlDataBase = $"mongodb://{user}:{password}{connectTo}.mlab.com:{port}/{dataBase}";
            MongoClient client = new MongoClient(urlDataBase);
            _database = client.GetDatabase(dataBase);
        }

        public IMongoCollection<Account> GetAccountCollection()
        {
            return _database.GetCollection<Account>("accounts");
        }
    }
}
