using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Core;
using AutoMapper;
using AjudAkiWeb.Models;

namespace AjudAkiWeb.Controllers
{
    public class AssinaturaController : Controller

    {
        private readonly IAssinaturaService assinaturaService;
        private readonly IMapper mapper;

        public AssinaturaController(IAssinaturaService assinaturaService, IMapper mapper)
        {
            this.assinaturaService = assinaturaService;
            this.mapper = mapper;
        }

        // GET: AssinaturaController
        public ActionResult Index()
        {
            var listaAssinaturas = assinaturaService.GetAll();
            var listaAssinaturaViewModel = mapper.Map<List<AssinaturaViewModel>>(listaAssinaturas);
            return View(listaAssinaturaViewModel);
        }

        // GET: AssinaturaController/Details/5
        public ActionResult Details(uint id)
        {
            var assinatura = assinaturaService.Get(id);
            var assinaturaViewModel = mapper.Map<AssinaturaViewModel>(assinatura);
            return View(assinaturaViewModel);
        }

        // GET: AssinaturaController/Create
        public ActionResult Create()
        {
            var assinaturaViewModel = new AssinaturaViewModel();
            return View(assinaturaViewModel);
        }

        // POST: AssinaturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssinaturaViewModel assinaturaViewModel)
        {
            if(ModelState.IsValid)
            {
                var assinatura = mapper.Map<Assinatura>(assinaturaViewModel);
                assinaturaService.Create(assinatura);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AssinaturaController/Edit/5
        public ActionResult Edit(uint id)
        {
            var assinatura = assinaturaService.Get(id);
            var assinaturaViewModel = mapper.Map<AssinaturaViewModel>(assinatura);
            return View(assinaturaViewModel);
        }

        // POST: AssinaturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, AssinaturaViewModel assinaturaViewModel)
        {
            if (ModelState.IsValid)
            {
                var assinatura = mapper.Map<Assinatura>(assinaturaViewModel);
                assinaturaService.Edit(assinatura);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AssinaturaController/Delete/5
        public ActionResult Delete(uint id)
        {
            var assinatura = assinaturaService.Get(id);
            var assinaturaViewModel = mapper.Map<AssinaturaViewModel>(assinatura);
            return View(assinaturaViewModel);
        }

        // POST: AssinaturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id,  AssinaturaViewModel assinaturaViewModel)
        {
            assinaturaService.Delete(assinaturaViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
