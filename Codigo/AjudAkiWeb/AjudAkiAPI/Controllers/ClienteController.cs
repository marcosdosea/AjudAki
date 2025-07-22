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
    public class ClienteController : ControllerBase
    {
        private readonly IAssinaturaService assinaturaService;
        private readonly IClienteService clienteService;
        private readonly IMapper mapper;

        public ClienteController(IClienteService clienteService, IAssinaturaService assinaturaService, IMapper mapper)
        {
            this.clienteService = clienteService;
            this.assinaturaService = assinaturaService;
            this.mapper = mapper;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaClientes = clienteService.GetAll();

            return Ok(listaClientes);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var cliente = clienteService.Get(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado");

            ClienteViewModel clienteViewModel = mapper.Map<ClienteViewModel>(cliente);
            return Ok(clienteViewModel);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var cliente = mapper.Map<Pessoa>(clienteViewModel);
            clienteService.Create(cliente);

            return Ok();
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var cliente = mapper.Map<Pessoa>(clienteViewModel);
            if (cliente == null)
                return NotFound();

            clienteService.Edit(cliente);

            return Ok();
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            var cliente = clienteService.Get(id);
            if (cliente == null)
                return NotFound();

            clienteService.Delete(id);
            return Ok();
        }
    }
}