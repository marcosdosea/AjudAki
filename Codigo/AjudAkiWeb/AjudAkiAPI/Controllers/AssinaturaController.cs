
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
    public class AssinaturaController : ControllerBase
    {
        private readonly IAssinaturaService assinaturaService;
        private readonly IMapper mapper;

        public AssinaturaController(IAssinaturaService assinaturaService, IMapper mapper)
        {
            this.assinaturaService = assinaturaService;
            this.mapper = mapper;
        }

        // GET: api/<AssinaturaController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaAssinaturas = assinaturaService.GetAll();

            return Ok(listaAssinaturas);
        }

        // GET api/<AssinaturaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var assinatura = assinaturaService.Get(id);
            if (assinatura == null)
                return NotFound("Assinatura não encontrada");

            AssinaturaViewModel assinaturaViewModel = mapper.Map<AssinaturaViewModel>(assinatura);
            return Ok(assinaturaViewModel);
        }

        // POST api/<AssinaturaController>
        [HttpPost]
        public ActionResult Post([FromBody] AssinaturaViewModel assinaturaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var assinatura = mapper.Map<Assinatura>(assinaturaViewModel);
            assinaturaService.Create(assinatura);

            return Ok();
        }

        // PUT api/<AssinaturaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AssinaturaViewModel assinaturaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var assinatura = mapper.Map<Assinatura>(assinaturaViewModel);
            if (assinatura == null)
                return NotFound();

            assinaturaService.Edit(assinatura);

            return Ok();
        }

        // DELETE api/<AssinaturaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            var assinatura = assinaturaService.Get(id);
            if (assinatura == null)
                return NotFound();

            assinaturaService.Delete(id);
            return Ok();
        }
    }
}