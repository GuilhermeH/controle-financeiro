using controle.financeiro.shared.Entities;
using System.Linq;

namespace controle.financeiro.domain.Entities
{
    public class Account : EntityBase
    {
        public Account(string name, int codeTypeAccount, decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                AddError(new Error("InitialBalance", "Saldo não pode ser menor que zero"));
            }

            Name = name;
            InitialBalance = initialBalance;
            Balance = initialBalance;
            Type = new AccountType().GetTypes().Where(t => t.Code == codeTypeAccount).FirstOrDefault() ?? null;

            if (Type == null)
            {
                AddError(new Error("Type", "Tipo de conta inválido")); 
            }
        }

        public string Name { get; private set; }
        public AccountType Type { get; private set; }
        public decimal Balance { get; private set; }
        public decimal InitialBalance { get; private set; }

        
    }

    
}
