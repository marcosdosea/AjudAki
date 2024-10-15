using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using AjudAkiWeb.Models;
using Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AjudAkiWeb.Controllers
{
    public class ClienteController : Controller
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

        // GET: ClienteController
        public ActionResult Index()
        {
            var listaClientes = clienteService.GetAll();
            var listaClienteViewModel = mapper.Map<List<ClienteViewModel>>(listaClientes);

            return View(listaClienteViewModel);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(uint id)
        {
            var cliente = clienteService.Get(id);
            var clienteViewModel = mapper.Map<ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            var clienteViewModel = new ClienteViewModel();
            clienteViewModel.DataNascimento = DateTime.Now;

            IEnumerable<Assinatura> listaAssinaturas = assinaturaService.GetAll();

            clienteViewModel.ListaAssinaturas = new SelectList(listaAssinaturas, "Id", "Nome", null);

            return View(clienteViewModel);
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = mapper.Map<Pessoa>(clienteViewModel);
                clienteService.Create(cliente);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(uint id)
        {
            var cliente = clienteService.Get(id);
            var clienteViewModel = mapper.Map<ClienteViewModel>(cliente);

            IEnumerable<Assinatura> listaAssinaturas = assinaturaService.GetAll();

            clienteViewModel.ListaAssinaturas = new SelectList(listaAssinaturas, "Id", "Nome",
                        listaAssinaturas.FirstOrDefault(e => e.Id.Equals(cliente.IdAssinatura)));

            return View(clienteViewModel);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = mapper.Map<Pessoa>(clienteViewModel);
                clienteService.Edit(cliente);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(uint id)
        {
            var cliente = clienteService.Get(id);
            var clienteViewModel = mapper.Map<ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteViewModel clienteViewModel)
        {
            clienteService.Delete(clienteViewModel.Id);

            return RedirectToAction(nameof(Index));
        }
    }

}
