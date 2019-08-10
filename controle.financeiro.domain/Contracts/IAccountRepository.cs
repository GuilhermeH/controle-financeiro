using controle.financeiro.domain.Entities;
using System.Collections.Generic;

namespace controle.financeiro.domain.Contracts
{
    public interface IAccountRepository
    {
        Account Insert(Account account);
        IEnumerable<Account> GetAll();
        IEnumerable<AccountType> GetTypes();
    }
}
