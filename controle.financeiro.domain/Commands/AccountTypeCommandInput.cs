using System;
using System.Collections.Generic;
using System.Text;

namespace controle.financeiro.domain.Commands
{
    public class AccountTypeCommandInput
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
