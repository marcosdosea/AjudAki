using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AjudAkiWeb.Controllers
{
    public class AgendaController : Controller
    {
        private readonly IAgendaService agendaService;
        private readonly IMapper mapper;

        public AgendaController(IAgendaService agendaService, IMapper mapper)
        {
            this.agendaService = agendaService;
            this.mapper = mapper;
        }

        // GET: AgendaController
        public ActionResult Index()
        {
            var listaAgendas = agendaService.GetAll();
            var listaAgendasViewModel = mapper.Map<List<AgendaViewModel>>(listaAgendas);

            return View(listaAgendasViewModel);
        }

        // GET: AgendaController/Details/5
        public ActionResult Details(uint id)
        {
            var agenda = agendaService.Get(id);
            var agendaViewModel = mapper.Map<AgendaViewModel>(agenda);

            return View(agendaViewModel);
        }

        // GET: AgendaController/Create
        public ActionResult Create()
        {
            var agendaViewModel = new AgendaViewModel();

            return View(agendaViewModel);
        }

        // POST: AgendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgendaViewModel agendaViewModel)
        {
            if (ModelState.IsValid)
            {
                var agenda = mapper.Map<Agendum>(agendaViewModel);
                agendaService.Create(agenda);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AgendaController/Edit/5
        public ActionResult Edit(uint id)
        {
            var agenda = agendaService.Get(id);
            var agendaViewModel = mapper.Map<AgendaViewModel>(agenda);

            return View(agendaViewModel);
        }

        // POST: AgendaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, AgendaViewModel agendaViewModel)
        {
            if (ModelState.IsValid)
            {
                var agenda = mapper.Map<Agendum>(agendaViewModel);
                agendaService.Edit(agenda);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AgendaController/Delete/5
        public ActionResult Delete(uint id)
        {
            var agenda = agendaService.Get(id);
            var agendaViewModel = mapper.Map<AgendaViewModel>(agenda);
            
            return View(agendaViewModel);
        }

        // POST: AgendaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AgendaViewModel agendaViewModel)
        {
            agendaService.Delete(agendaViewModel.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
