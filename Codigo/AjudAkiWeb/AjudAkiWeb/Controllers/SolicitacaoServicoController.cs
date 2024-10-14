using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers
{
    public class SolicitacaoServicoController : Controller
    {
        //TODO: Implementar lógicas de foreign Keys

        private readonly ISolicitacaoServicoService solicitacaoServicoService;
        private readonly IMapper mapper;

        public SolicitacaoServicoController(ISolicitacaoServicoService solicitacaoServicoService, IMapper mapper)
        {
            this.solicitacaoServicoService = solicitacaoServicoService;
            this.mapper = mapper;
        }

        // GET: SolicitacaoServicoController
        public ActionResult Index()
        {
            var listaAolicitacoesServico = solicitacaoServicoService.GetAll();
            var listaSolicitacoesServicoViewModel = mapper.Map<List<SolicitacaoServicoViewModel>>(listaAolicitacoesServico);

            return View(listaSolicitacoesServicoViewModel);
        }

        // GET: SolicitacaoServicoController/Details/5
        public ActionResult Details(uint id)
        {
            var solicitacaoServico = solicitacaoServicoService.Get(id);
            var solicitacaoServicoViewModel = mapper.Map<SolicitacaoServicoViewModel>(solicitacaoServico);
            return View();
        }

        // GET: SolicitacaoServicoController/Create
        public ActionResult Create()
        {
            var solicitacaoServicoViewModel = new SolicitacaoServicoViewModel();

            return View(solicitacaoServicoViewModel);
        }

        // POST: SolicitacaoServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SolicitacaoServicoViewModel solicitacaoServicoViewModel)
        {
            if (ModelState.IsValid)
            {
                var solicitacaoServico = mapper.Map<Solicitacaoservico>(solicitacaoServicoViewModel);
                solicitacaoServicoService.Create(solicitacaoServico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SolicitacaoServicoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var solicitacaoServico = solicitacaoServicoService.Get(id);
            var solicitacaoServicoViewModel = mapper.Map<SolicitacaoServicoViewModel>(solicitacaoServico);

            return View(solicitacaoServicoViewModel);
        }

        // POST: SolicitacaoServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, SolicitacaoServicoViewModel solicitacaoServicoViewModel)
        {
            if (ModelState.IsValid)
            {
                var solicitacaoServico = mapper.Map<Solicitacaoservico>(solicitacaoServicoViewModel);
                solicitacaoServicoService.Edit(solicitacaoServico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SolicitacaoServicoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var solicitacaoServico = solicitacaoServicoService.Get(id);
            var solicitacaoServicoViewModel = mapper.Map<SolicitacaoServicoViewModel>(solicitacaoServico);

            return View(solicitacaoServicoViewModel);
        }

        // POST: SolicitacaoServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, SolicitacaoServicoViewModel solicitacaoServicoViewModel)
        {
            solicitacaoServicoService.Delete(solicitacaoServicoViewModel.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
