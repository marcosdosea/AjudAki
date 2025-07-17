
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
    public class AreaAtuacaoController : ControllerBase
    {
        private readonly IAreaAtuacaoService areaAtuacaoService;
        private readonly IMapper mapper;

        public AreaAtuacaoController(IAreaAtuacaoService areaAtuacaoService, IMapper mapper)
        {
            this.areaAtuacaoService = areaAtuacaoService;
            this.mapper = mapper;
        }

        // GET: api/<AreaAtuacaoController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaAreasAtuacao = areaAtuacaoService.GetAll();

            return Ok(listaAreasAtuacao);
        }

        // GET api/<AreaAtuacaoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var areaAtuacao = areaAtuacaoService.Get(id);
            if (areaAtuacao == null)
                return NotFound("Área de atuação não encontrada");

            AreaAtuacaoViewModel areaAtuacaoViewModel = mapper.Map<AreaAtuacaoViewModel>(areaAtuacao);
            return Ok(areaAtuacaoViewModel);
        }

        // POST api/<AreaAtuacaoController>
        [HttpPost]
        public ActionResult Post([FromBody] AreaAtuacaoViewModel areaAtuacaoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var areaAtuacao = mapper.Map<Areaatuacao>(areaAtuacaoViewModel);
            areaAtuacaoService.Create(areaAtuacao);

            return Ok();
        }

        // PUT api/<AreaAtuacaoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AreaAtuacaoViewModel areaAtuacaoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var areaAtuacao = mapper.Map<Areaatuacao>(areaAtuacaoViewModel);
            if (areaAtuacao == null)
                return NotFound();

            areaAtuacaoService.Edit(areaAtuacao);

            return Ok();
        }

        // DELETE api/<AreaAtuacaoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            var areaAtuacao = areaAtuacaoService.Get(id);
            if (areaAtuacao == null)
                return NotFound();

            areaAtuacaoService.Delete(id);
            return Ok();
        }
    }
}