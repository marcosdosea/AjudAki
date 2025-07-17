
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
    public class TipoServicoController : ControllerBase
    {
        private readonly IAreaAtuacaoService areaAtuacaoService;
        private readonly IAgendaService agendaService;
        private readonly ITipoServicoService tipoServicoService;
        private readonly IMapper mapper;

        public TipoServicoController(ITipoServicoService tipoServicoService, IAgendaService agendaService, IAreaAtuacaoService areaAtuacaoService, IMapper mapper)
        {
            this.tipoServicoService = tipoServicoService;
            this.agendaService = agendaService;
            this.areaAtuacaoService = areaAtuacaoService;
            this.mapper = mapper;
        }

        // GET: api/<TipoServicoController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaTipoServicos = areaAtuacaoService.GetAll();

            return Ok(listaTipoServicos);
        }

        // GET api/<TipoServicoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var tipoServico = tipoServicoService.Get(id);
            if (tipoServico == null)
                return NotFound("Tipo de serviço não encontrado");

            TipoServicoViewModel tipoServicoViewModel = mapper.Map<TipoServicoViewModel>(tipoServico);
            return Ok(tipoServicoViewModel);
        }

        // POST api/<TipoServicoController>
        [HttpPost]
        public ActionResult Post([FromBody] TipoServicoViewModel tipoServicoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var tipoServico = mapper.Map<Tiposervico>(tipoServicoViewModel);
            tipoServicoService.Create(tipoServico);

            return Ok();
        }

        // PUT api/<TipoServicoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TipoServicoViewModel tipoServicoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var tipoServico = mapper.Map<Tiposervico>(tipoServicoViewModel);
            if (tipoServico == null)
                return NotFound();

            tipoServicoService.Edit(tipoServico);

            return Ok();
        }

        // DELETE api/<TipoServicoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            var tipoServico = tipoServicoService.Get(id);
            if (tipoServico == null)
                return NotFound();

            tipoServicoService.Delete(id);
            return Ok();
        }
    }
}