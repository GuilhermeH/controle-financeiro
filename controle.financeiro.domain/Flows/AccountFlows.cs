using controle.financeiro.domain.Commands;
using controle.financeiro.domain.Contracts;
using controle.financeiro.domain.Entities;
using System.Collections.Generic;

namespace controle.financeiro.domain.Flows
{
    public class AccountFlows
    {
        private readonly IAccountRepository _accountRepository;
        public AccountFlows(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account AddAccount(AccountCommandInput commandInput)
        {
            var account = new Account(commandInput.Name, commandInput.Type.Code, commandInput.InitialBalance);

            if (account.IsValid())
            {
                _accountRepository.Insert(account);
            }

            return account;
        }

        public IEnumerable<AccountType> GetTypes()
        {
            var types = new AccountType().GetTypes();
            return types;
        }
    }
}
