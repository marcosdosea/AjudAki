
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
    public class ServicoController : ControllerBase
    {
        private readonly IProfissionalService profissionalService;
        private readonly IServicoService servicoService;
        private readonly ITipoServicoService tipoServicoService;
        private readonly IAreaAtuacaoService areaAtuacaoService;
        private readonly IMapper mapper;

        public ServicoController(IServicoService servicoService, IProfissionalService profissionalService, ITipoServicoService tipoServicoService, IAreaAtuacaoService areaAtuacaoService, IMapper mapper)
        {
            this.profissionalService = profissionalService;
            this.servicoService = servicoService;
            this.tipoServicoService = tipoServicoService;
            this.areaAtuacaoService = areaAtuacaoService;
            this.mapper = mapper;
        }

        // GET: api/<AreaAtuacaoController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaServicos = servicoService.GetAll();

            return Ok(listaServicos);
        }

        // GET api/<AreaAtuacaoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var servico = servicoService.Get(id);
            if (servico == null)
                return NotFound("Serviço não encontrado");

            ServicoViewModel servicoViewModel = mapper.Map<ServicoViewModel>(servico);
            return Ok(servicoViewModel);
        }

        // POST api/<AreaAtuacaoController>
        [HttpPost]
        public ActionResult Post([FromBody] ServicoViewModel servicoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var servico = mapper.Map<Servico>(servicoViewModel);
            servicoService.Create(servico);

            return Ok();
        }

        // PUT api/<AreaAtuacaoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ServicoViewModel servicoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var servico = mapper.Map<Servico>(servicoViewModel);
            if (servico == null)
                return NotFound();

            servicoService.Edit(servico);

            return Ok();
        }

        // DELETE api/<AreaAtuacaoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            var servico = servicoService.Get(id);
            if (servico == null)
                return NotFound();

            servicoService.Delete(id);
            return Ok();
        }
    }
}