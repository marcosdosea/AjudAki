using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using AjudAkiWeb.Models;
using Core;

namespace AjudAkiWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService clienteService;
        private readonly IMapper mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            this.clienteService = clienteService;
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
                clienteViewModel.Edit(cliente);
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
