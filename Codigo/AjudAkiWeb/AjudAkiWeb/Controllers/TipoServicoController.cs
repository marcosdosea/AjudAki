using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace AjudAkiWeb.Controllers
{
    public class TipoServicoController : Controller
    {
        private readonly ITipoServicoService tipoServicoService;
        private readonly IMapper mapper;

        public TipoServicoController(ITipoServicoService tipoServicoService, IMapper mapper)
        {
            this.tipoServicoService = tipoServicoService;
            this.mapper = mapper;
        }

        // GET: TipoServicoController
        public ActionResult Index()
        {
            var listaTipoServicos = tipoServicoService.GetAll();
            var listaTipoServicoViewModel = mapper.Map<List<TipoServicoViewModel>>(listaTipoServicos);
            
            return View(listaTipoServicoViewModel);
        }

        // GET: TipoServicoController/Details/5
        public ActionResult Details(uint id)
        {
            var tipoServico = tipoServicoService.Get(id);
            var tipoServicoViewModel = mapper.Map<TipoServicoViewModel>(tipoServico);
            
            return View(tipoServicoViewModel);
        }

        // GET: TipoServicoController/Create
        public ActionResult Create()
        {
            var tipoServicoViewModel = new TipoServicoViewModel();
            
            return View(tipoServicoViewModel);
        }

        // POST: TipoServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoServicoViewModel tipoServicoViewModel)
        {
            if (ModelState.IsValid)
            {
                var tipoServico = mapper.Map<Tiposervico>(tipoServicoViewModel);
                tipoServicoService.Create(tipoServico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipoServicoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var tipoServico = tipoServicoService.Get(id);
            var tipoServicoViewModel = mapper.Map<TipoServicoViewModel>(tipoServico);
            
            return View(tipoServicoViewModel);
        }

        // POST: TipoServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoServicoViewModel tipoServicoViewModel)
        {
            if (ModelState.IsValid)
            {
                var tipoServico = mapper.Map<Tiposervico>(tipoServicoViewModel);
                tipoServicoService.Edit(tipoServico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipoServicoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var tipoServico = tipoServicoService.Get(id);
            var tipoServicoViewModel = mapper.Map<TipoServicoViewModel>(tipoServico);
            
            return View(tipoServicoViewModel);
        }

        // POST: TipoServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoServicoViewModel tipoServicoViewModel)
        {
            tipoServicoService.Delete(tipoServicoViewModel.Id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
