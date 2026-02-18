
using AjudAkiWeb.Models;
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
    public class ContratacaoController : ControllerBase
    {
        private readonly IContratacaoService contratacaoService;
        private readonly IClienteService clienteService;
        private readonly IServicoService servicoService;
        private readonly IMapper mapper;

        public ContratacaoController(IContratacaoService contratacaoService, IClienteService clienteService, IServicoService servicoService, IMapper mapper)
        {
            this.contratacaoService = contratacaoService;
            this.clienteService = clienteService;
            this.servicoService = servicoService;
            this.mapper = mapper;
        }

        // GET: api/<ContratacaoController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaContratacoes = contratacaoService.GetAll();

            return Ok(listaContratacoes);
        }

        // GET api/<ContratacaoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var contratacao = contratacaoService.Get(id);
            if (contratacao == null)
                return NotFound("Contratação não encontrada");

            ContratacaoViewModel contratacaoViewModel = mapper.Map<ContratacaoViewModel>(contratacao);
            return Ok(contratacaoViewModel);
        }

        // POST api/<ContratacaoController>
        [HttpPost]
        public ActionResult Post([FromBody] ContratacaoViewModel contratacaoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var contratacao = mapper.Map<Contratacao>(contratacaoViewModel);
            contratacaoService.Create(contratacao);

            return Ok();
        }

        // PUT api/<ContratacaoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ContratacaoViewModel contratacaoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var contratacao = mapper.Map<Contratacao>(contratacaoViewModel);
            if (contratacao == null)
                return NotFound();

            contratacaoService.Edit(contratacao);

            return Ok();
        }

        // DELETE api/<ContratacaoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            var contratacao = contratacaoService.Get(id);
            if (contratacao == null)
                return NotFound();

            contratacaoService.Delete(id);
            return Ok();
        }
    }
}