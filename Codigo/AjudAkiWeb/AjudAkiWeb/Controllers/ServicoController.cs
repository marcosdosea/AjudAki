using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

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
            var listaOfertarServicoViewModel = mapper.Map<List<OfertarServicoViewModel>>(listaServicos);
            return View(listaOfertarServicoViewModel);
        }

        // GET: ServicoController/Details/5
        public ActionResult Details(uint id)
        {
            var servico = servicoService.Get(id);
            var ofertarServicoViewModel = mapper.Map<OfertarServicoViewModel>(servico);
            return View(ofertarServicoViewModel);
        }

        // GET: ServicoController/Create
        public ActionResult Create()
        {
            var servicoViewModel = new OfertarServicoViewModel();
            servicoViewModel.Data = DateTime.Now;
            return View(servicoViewModel);
        }

        // POST: ServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfertarServicoViewModel servicoViewModel)
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
            var servicoViewModel = mapper.Map<OfertarServicoViewModel>(servico);
            return View(servicoViewModel);
        }

        // POST: ServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, OfertarServicoViewModel servicoViewModel)
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
            var servicoViewModel = mapper.Map<OfertarServicoViewModel>(servico);
            return View(servicoViewModel);
        }

        // POST: ProfissionalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OfertarServicoViewModel servicoViewModel)
        {
            servicoService.Delete(servicoViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
