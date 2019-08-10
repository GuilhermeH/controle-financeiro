using controle.financeiro.domain.Entities;
using MongoDB.Driver;

namespace controle.financeiro.infra.Context
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(string user, string password, string hash, string dataBase, string port)
        {
            var urlDataBase = $"mongodb://{user}:{password}{hash}.mlab.com:{port}/{dataBase}";// "mongodb://admin:c0ntr0l3@ds247377.mlab.com:47377/controlefinanceiro"
            //"urlDataBase": 
            MongoClient client = new MongoClient(urlDataBase);
            _database = client.GetDatabase(dataBase);
        }

        public IMongoCollection<Account> GetAccountCollection()
        {
            return _database.GetCollection<Account>("accounts");
        }
    }
}
