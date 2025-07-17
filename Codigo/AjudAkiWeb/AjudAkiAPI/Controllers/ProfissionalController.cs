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
    public class ProfissionalController : ControllerBase
    {
        private readonly IAssinaturaService assinaturaService;
        private readonly IProfissionalService profissionalService;
        private readonly IMapper mapper;

        public ProfissionalController(IProfissionalService profissionalService, IAssinaturaService assinaturaService, IMapper mapper)
        {
            this.profissionalService = profissionalService;
            this.assinaturaService = assinaturaService;
            this.mapper = mapper;
        }

        // GET: api/<ProfissionalController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaProfissionais = profissionalService.GetAll();

            return Ok(listaProfissionais);
        }

        // GET api/<ProfissionalController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var profissional = profissionalService.Get(id);
            if (profissional == null)
                return NotFound("Profissional não encontrado");

            ProfissionalViewModel profissionalViewModel = mapper.Map<ProfissionalViewModel>(profissional);
            return Ok(profissionalViewModel);
        }

        // POST api/<ProfissionalController>
        [HttpPost]
        public ActionResult Post([FromBody] ProfissionalViewModel profissionalViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var profissional = mapper.Map<Pessoa>(profissionalViewModel);
            profissionalService.Create(profissional);

            return Ok();
        }

        // PUT api/<ProfissionalController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProfissionalViewModel profissionalViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var profissional = mapper.Map<Pessoa>(profissionalViewModel);
            if (profissional == null)
                return NotFound();

            profissionalService.Edit(profissional);

            return Ok();
        }

        // DELETE api/<ProfissionalController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            var profissional = profissionalService.Get(id);
            if (profissional == null)
                return NotFound();

            profissionalService.Delete(id);
            return Ok();
        }
    }
}