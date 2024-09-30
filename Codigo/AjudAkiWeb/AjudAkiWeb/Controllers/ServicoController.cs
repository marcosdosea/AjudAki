using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers
{
    public class ServicoController : Controller
    {
        private readonly IServicoService servicoService;
        private readonly IMapper mapper;

        public ServicoController(IServicoService servicoService, IMapper mapper)
        {
            this.servicoService = servicoService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var listaServicos = servicoService.GetAll();
            var listaServicoViewModel = mapper.Map<List<ServicoViewModel>>(listaServicos);
            return View(listaServicoViewModel);
        }

        // GET: ServicoController/Details/5
        public ActionResult Details(uint id)
        {
            var servico = servicoService.Get(id);
            var servicoViewModel = mapper.Map<ServicoViewModel>(servico);
            return View(servicoViewModel);
        }

        // GET: ServicoController/Create
        public ActionResult Create()
        {
            var servicoViewModel = new ServicoViewModel();
            servicoViewModel.Data = DateTime.Now;
            return View(servicoViewModel);
        }

        // POST: ServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicoViewModel servicoViewModel)
        {
            if (ModelState.IsValid)
            {
                var servico = mapper.Map<Servico>(servicoViewModel);
                servicoService.Create(servico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ServicoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var servico = servicoService.Get(id);
            var servicoViewModel = mapper.Map<ServicoViewModel>(servico);
            return View(servicoViewModel);
        }

        // POST: ServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ServicoViewModel servicoViewModel)
        {
            if (ModelState.IsValid)
            {
                var servico = mapper.Map<Servico>(servicoViewModel);
                servicoService.Edit(servico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ServicoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var servico = servicoService.Get(id);
            var servicoViewModel = mapper.Map<ServicoViewModel>(servico);
            return View(servicoViewModel);
        }

        // POST: ProfissionalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, ServicoViewModel servicoViewModel)
        {
            servicoService.Delete(servicoViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
