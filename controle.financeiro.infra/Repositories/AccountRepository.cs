using controle.financeiro.domain.Contracts;
using controle.financeiro.domain.Entities;
using controle.financeiro.infra.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace controle.financeiro.infra.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MongoContext _mongoContext;

        public AccountRepository(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }
        public Account Insert(Account account)
        {
            _mongoContext.GetAccountCollection().InsertOne(account);
            return account;
        }

        public IEnumerable<AccountType> GetTypes()
        {
            var types = new AccountType().GetTypes();
            return types;
        }

        public IEnumerable<Account> GetAll()
        {
            var accounts = _mongoContext.GetAccountCollection().Find(c => true).ToList();
            return accounts;
        }
    }
}
