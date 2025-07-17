using AjudAkiAPI.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AjudAkiWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoServicoController : ControllerBase
    {
        private readonly ISolicitacaoServicoService solicitacaoServicoService;
        private readonly IClienteService clienteService;
        private readonly IProfissionalService profissionalService;
        private readonly ITipoServicoService tipoServicoService;
        private readonly IMapper mapper;

        public SolicitacaoServicoController(ISolicitacaoServicoService solicitacaoServicoService, IClienteService clienteService,
                                            IProfissionalService profissionalService, ITipoServicoService tipoServicoService, IMapper mapper)
        {
            this.clienteService = clienteService;
            this.profissionalService = profissionalService;
            this.solicitacaoServicoService = solicitacaoServicoService;
            this.tipoServicoService = tipoServicoService;
            this.mapper = mapper;
        }

        // GET: api/<SolicitacaoServicoController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaSolicitacaoServicos = solicitacaoServicoService.GetAll();

            return Ok(listaSolicitacaoServicos);
        }

        // GET api/<SolicitacaoServicoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var solicitacaoServico = solicitacaoServicoService.Get(id);
            if (solicitacaoServico == null)
                return NotFound("Solicitação de serviço não encontrada");

            SolicitacaoServicoViewModel solicitacaoServicoViewModel = mapper.Map<SolicitacaoServicoViewModel>(solicitacaoServico);
            return Ok(solicitacaoServicoViewModel);
        }

        // POST api/<SolicitacaoServicoController>
        [HttpPost]
        public ActionResult Post([FromBody] SolicitacaoServicoViewModel solicitacaoServicoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var solicitacaoServico = mapper.Map<Solicitacaoservico>(solicitacaoServicoViewModel);
            solicitacaoServicoService.Create(solicitacaoServico);

            return Ok();
        }

        // PUT api/<SolicitacaoServicoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SolicitacaoServicoViewModel solicitacaoServicoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var solicitacaoservico = mapper.Map<Solicitacaoservico>(solicitacaoServicoViewModel);
            if (solicitacaoservico == null)
                return NotFound();

            solicitacaoServicoService.Edit(solicitacaoservico);

            return Ok();
        }

        // DELETE api/<SolicitacaoServicoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            var solicitacaoservico = solicitacaoServicoService.Get(id);
            if (solicitacaoservico == null)
                return NotFound();

            solicitacaoServicoService.Delete(id);
            return Ok();
        }
    }
}