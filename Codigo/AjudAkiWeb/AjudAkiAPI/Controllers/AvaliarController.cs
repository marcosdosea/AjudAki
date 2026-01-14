
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
    public class AvaliarController : ControllerBase
    {
        private readonly IContratacaoService contratacaoService;
        private readonly IAvaliarService avaliarService;
        private readonly IMapper mapper;

        public AvaliarController(IAvaliarService avaliarService, IContratacaoService contratacaoService, IMapper mapper)
        {
            this.avaliarService = avaliarService;
            this.contratacaoService = contratacaoService;
            this.mapper = mapper;
        }

        // GET: api/<AvaliarController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaAvaliar = avaliarService.GetAll();

            return Ok(listaAvaliar);
        }

        // GET api/<AvaliarController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var avaliar = avaliarService.Get(id);
            if (avaliar == null)
                return NotFound("Avaliação não encontrada");

            AvaliarViewModel avaliarViewModel = mapper.Map<AvaliarViewModel>(avaliar);
            return Ok(avaliarViewModel);
        }

        // POST api/<AvaliarController>
        [HttpPost]
        public ActionResult Post([FromBody] AvaliarViewModel avaliarViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var avaliar = mapper.Map<Avaliacao>(avaliarViewModel);
            avaliarService.Create(avaliar);

            return Ok();
        }

        // PUT api/<AvaliarController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AvaliarViewModel avaliarViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var avaliar = mapper.Map<Avaliacao>(avaliarViewModel);
            if (avaliar == null)
                return NotFound();

            avaliarService.Edit(avaliar);

            return Ok();
        }

        // DELETE api/<AvaliarController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            var avaliar = avaliarService.Get(id);
            if (avaliar == null)
                return NotFound();

            avaliarService.Delete(id);
            return Ok();
        }
    }
}