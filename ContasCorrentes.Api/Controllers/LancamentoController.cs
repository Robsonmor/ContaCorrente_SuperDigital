using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContasCorrentes.Domain.Interfaces.Services;
using ContasCorrentes.Domain.Schemas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContasCorrentes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : Controller
    {
        protected readonly ILancamentoService _lancamentoService;

        public LancamentoController(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult Lancamento([FromBody] LancamentoSchema lancamentoSchema)
        {
            if (lancamentoSchema == null)
                return BadRequest();

            return Ok(_lancamentoService.Lancamento(lancamentoSchema));
        }
    }
}