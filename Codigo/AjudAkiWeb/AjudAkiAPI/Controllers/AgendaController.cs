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
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService agendaService;
        private readonly IMapper mapper;

        public AgendaController(IAgendaService agendaService, IMapper mapper)
        {
            this.agendaService = agendaService;
            this.mapper = mapper;
        }

        // GET: api/<AgendaController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaAgendas = agendaService.GetAll();

            return Ok(listaAgendas);
        }

        // GET api/<AgendaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var agenda = agendaService.Get(id);
            if (agenda == null)
                return NotFound("Agenda não encontrada");

            AgendaViewModel agendaViewModel = mapper.Map<AgendaViewModel>(agenda);
            return Ok(agendaViewModel);
        }

        // POST api/<AgendaController>
        [HttpPost]
        public ActionResult Post([FromBody] AgendaViewModel agendaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var agenda = mapper.Map<Agendum>(agendaViewModel);
            agendaService.Create(agenda);

            return Ok();
        }

        // PUT api/<AgendaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AgendaViewModel agendaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var agenda = mapper.Map<Agendum>(agendaViewModel);
            if (agenda == null)
                return NotFound();

            agendaService.Edit(agenda);

            return Ok();
        }

        // DELETE api/<AgendaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            var agenda = agendaService.Get(id);
            if (agenda == null)
                return NotFound();

            agendaService.Delete(id);
            return Ok();
        }
    }
}