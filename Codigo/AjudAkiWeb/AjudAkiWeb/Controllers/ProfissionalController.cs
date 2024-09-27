using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace AjudAkiWeb.Controllers
{
    public class ProfissionalController : Controller
    {
        private readonly IProfissionalService ProfissionalService;
        private readonly IMapper mapper;

        public ProfissionalController(IProfissionalService ProfissionalService, IMapper mapper)
        {
            this.ProfissionalService = ProfissionalService;
            this.mapper = mapper;
        }

        // GET: ProfissionalController
        public ActionResult Index()
        {
            var listaProfissionais = ProfissionalService.GetAll();
            var listaProfissionalViewModel = mapper.Map<List<ProfissionalViewModel>>(listaProfissionais);
            return View(listaProfissionalViewModel);
        }

        // GET: ProfissionalController/Details/5
        public ActionResult Details(uint id)
        {
            var Profissional = ProfissionalService.Get(id);
            var ProfissionalViewModel = mapper.Map<ProfissionalViewModel>(Profissional);
            return View(ProfissionalViewModel);
        }

        // GET: ProfissionalController/Create
        public ActionResult Create()
        {
            var ProfissionalViewModel = new ProfissionalViewModel();
            ProfissionalViewModel.DataNascimento = DateTime.Now;
            return View(ProfissionalViewModel);
        }

        // POST: ProfissionalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfissionalViewModel ProfissionalViewModel)
        {
            if (ModelState.IsValid)
            {
                var Profissional = mapper.Map<Pessoa>(ProfissionalViewModel);
                ProfissionalService.Create(Profissional);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProfissionalController/Edit/5
        public ActionResult Edit(uint id)
        {
            var Profissional = ProfissionalService.Get(id);
            var ProfissionalViewModel = mapper.Map<ProfissionalViewModel>(Profissional);
            return View(ProfissionalViewModel);
        }

        // POST: ProfissionalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ProfissionalViewModel ProfissionalViewModel)
        {
            if (ModelState.IsValid)
            {
                var Profissional = mapper.Map<Pessoa>(ProfissionalViewModel);
                ProfissionalService.Edit(Profissional);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProfissionalController/Delete/5
        public ActionResult Delete(uint id)
        {
            var Profissional = ProfissionalService.Get(id);
            var ProfissionalViewModel = mapper.Map<ClienteViewModel>(Profissional);
            return View(ProfissionalViewModel);
        }

        // POST: ProfissionalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProfissionalViewModel ProfissionalViewModel)
        {
            ProfissionalService.Delete(ProfissionalViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
