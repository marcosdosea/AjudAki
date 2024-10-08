using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers
{
    public class PagarAssinaturaController : Controller
    {
        private readonly IPagarAssinaturaService pagarAssinaturaService;
        private readonly IMapper mapper;

        public PagarAssinaturaController(IPagarAssinaturaService pagarAssinaturaService, IMapper mapper)
        {
            this.pagarAssinaturaService = pagarAssinaturaService;
            this.mapper = mapper;
        }
        // GET: PagarAssinaturaController
        public ActionResult Index()
        {
            var listaPagarAssinaturas = pagarAssinaturaService.GetAll();
            var listaPagarAssinaturaViewModel = mapper.Map<List<PagarAssinaturaViewModel>>(listaPagarAssinaturas);
            return View(listaPagarAssinaturaViewModel);
        }

        // GET: PagarAssinaturaController/Details/5
        public ActionResult Details(uint id)
        {
            var pagaraAsinatura = pagarAssinaturaService.Get(id);
            var pagarAssinaturaViewModel = mapper.Map<PagarAssinaturaViewModel>(pagaraAsinatura);
            return View(pagarAssinaturaViewModel);
        }

        // GET: PagarAssinaturaController/Create
        public ActionResult Create()
        {
            var pagarAssinaturaViewModel = new PagarAssinaturaViewModel();
            return View(pagarAssinaturaViewModel);
        }

        // POST: PagarAssinaturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PagarAssinaturaViewModel pagarAssinaturaViewModel)
        {
            if (ModelState.IsValid)
            {
                var pagarAssinatura = mapper.Map<Pagamentoassinatura>(pagarAssinaturaViewModel);
                pagarAssinaturaService.Create(pagarAssinatura);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PagarAssinaturaController/Edit/5
        public ActionResult Edit(uint id)
        {
            var pagarAssinatura = pagarAssinaturaService.Get(id);
            var pagarAssinaturaViewModel = mapper.Map<PagarAssinaturaViewModel>(pagarAssinatura);
            return View(pagarAssinaturaViewModel);
        }

        // POST: PagarAssinaturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, PagarAssinaturaViewModel pagarAssinaturaViewModel)
        {
            if (ModelState.IsValid)
            {
                var pagarAssinatura = mapper.Map<Pagamentoassinatura>(pagarAssinaturaViewModel);
                pagarAssinaturaService.Edit(pagarAssinatura);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PagarAssinaturaController/Delete/5
        public ActionResult Delete(uint id)
        {
            var pagarAssinatura = pagarAssinaturaService.Get(id);
            var pagarAssinaturaViewModel = mapper.Map<PagarAssinaturaViewModel>(pagarAssinatura);
            return View(pagarAssinaturaViewModel);
        }

        // POST: PagarAssinaturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, PagarAssinaturaViewModel pagarAssinaturaViewModel)
        {
            pagarAssinaturaService.Delete(pagarAssinaturaViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
