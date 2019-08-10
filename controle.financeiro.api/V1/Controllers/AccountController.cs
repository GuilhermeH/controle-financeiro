using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controle.financeiro.domain.Commands;
using controle.financeiro.domain.Contracts;
using controle.financeiro.domain.Flows;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace controle.financeiro.api.V1.Controllers
{
    [Route("api/v1/account")]
    public class AccountController : ControllerBase
    {
        private readonly AccountFlows _accountFlows;
        private readonly IAccountRepository _accountRepository;

        public AccountController(AccountFlows accountFlows, IAccountRepository accountRepository)
        {
            _accountFlows = accountFlows;
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public ActionResult Post([FromBody]AccountCommandInput command)
        {
            var result = _accountFlows.AddAccount(command);
            if (result.IsValid())
            {
                return Ok(result);
            }
            return BadRequest(result.GetErrors());
        }

        [HttpGet, Route("")]
        public ActionResult GetAll()
        {
            var accounts = _accountRepository.GetAll();
            return Ok(accounts);
        }
        [HttpGet, Route("types")]
        public ActionResult Get()
        {
            var types = _accountRepository.GetTypes();
            return Ok(types);
        }
    }
}