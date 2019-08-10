using controle.financeiro.domain.Entities;

namespace controle.financeiro.domain.Commands
{
    public class AccountCommandInput
    {
        public string Name { get; set; }
        public AccountTypeCommandInput Type { get; set; }
        public decimal InitialBalance { get; set; }
    }
}
