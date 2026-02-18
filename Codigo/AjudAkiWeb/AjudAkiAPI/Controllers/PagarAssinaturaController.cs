
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
    public class PagarAssinaturaController : ControllerBase
    {
        private readonly IAssinaturaService assinaturaService;
        private readonly IPagarAssinaturaService pagarAssinaturaService;
        private readonly IProfissionalService profissionalService;
        private readonly IMapper mapper;

        public PagarAssinaturaController(IPagarAssinaturaService pagarAssinaturaService, IAssinaturaService assinaturaService, IProfissionalService profissionalService, IMapper mapper)
        {
            this.pagarAssinaturaService = pagarAssinaturaService;
            this.assinaturaService = assinaturaService;
            this.profissionalService = profissionalService;
            this.mapper = mapper;
        }

        // GET: api/<PagarAssinaturaController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaPagarAssinatura = pagarAssinaturaService.GetAll();

            return Ok(listaPagarAssinatura);
        }

        // GET api/<PagarAssinaturaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var pagarAssinatura = pagarAssinaturaService.Get(id);
            if (pagarAssinatura == null)
                return NotFound("Assinatura a pagar não encontrada");

            PagarAssinaturaViewModel pagarAssinaturaViewModel = mapper.Map<PagarAssinaturaViewModel>(pagarAssinatura);
            return Ok(pagarAssinaturaViewModel);
        }

        // POST api/<PagarAssinaturaController>
        [HttpPost]
        public ActionResult Post([FromBody] PagarAssinaturaViewModel pagarAssinaturaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var pagarAssinatura = mapper.Map<Pagamentoassinatura>(pagarAssinaturaViewModel);
            pagarAssinaturaService.Create(pagarAssinatura);

            return Ok();
        }

        // PUT api/<PagarAssinaturaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PagarAssinaturaViewModel pagarAssinaturaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var pagarAssinatura = mapper.Map<Pagamentoassinatura>(pagarAssinaturaViewModel);
            if (pagarAssinatura == null)
                return NotFound();

            pagarAssinaturaService.Edit(pagarAssinatura);

            return Ok();
        }

        // DELETE api/<PagarAssinaturaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            var pagarAssinatura = pagarAssinaturaService.Get(id);
            if (pagarAssinatura == null)
                return NotFound();

            pagarAssinaturaService.Delete(id);
            return Ok();
        }
    }
}