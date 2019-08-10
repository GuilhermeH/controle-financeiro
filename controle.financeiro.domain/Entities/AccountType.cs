using controle.financeiro.shared.Entities;
using System.Collections;
using System.Collections.Generic;

namespace controle.financeiro.domain.Entities
{
    public class AccountType
    {
        public AccountType()
        {
        }

        public string Name { get; private set; }
        public int Code { get; private set; }

        public List<AccountType> GetTypes()
        {
            var types = new List<AccountType>
            {
                new AccountType { Name = "Current", Code = 1 },
                new AccountType { Name = "Saving", Code = 2 },
                new AccountType { Name = "Investiment", Code = 3 }
            };

            return types;

        }
    }


}


