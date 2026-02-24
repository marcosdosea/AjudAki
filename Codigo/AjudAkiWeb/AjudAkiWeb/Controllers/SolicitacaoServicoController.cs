using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AjudAkiWeb.Controllers
{
    public class SolicitacaoServicoController : Controller
    {


        private readonly ISolicitacaoServicoService solicitacaoServicoService;
        private readonly IClienteService clienteService;
        private readonly IProfissionalService profissionalService;
        private readonly ITipoServicoService tipoServicoService;
        private readonly IMapper mapper;

        public SolicitacaoServicoController(ISolicitacaoServicoService solicitacaoServicoService, IClienteService clienteService,
                                            IProfissionalService profissionalService, ITipoServicoService tipoServicoService, IMapper mapper)
        {
            this.clienteService = clienteService;
            this.profissionalService = profissionalService;
            this.solicitacaoServicoService = solicitacaoServicoService;
            this.tipoServicoService = tipoServicoService;
            this.mapper = mapper;
        }

        // GET: SolicitacaoServicoController
        public ActionResult Index()
        {
            var lista = solicitacaoServicoService.GetAll();
            var model = mapper.Map<IEnumerable<SolicitacaoServicoViewModel>>(lista);
            return View(model);
        }

        // GET: SolicitacaoServicoController/Details/5
        public ActionResult Details(uint id)
        {
            var entity = solicitacaoServicoService.Get(id);
            if (entity == null) return NotFound();

            var model = mapper.Map<SolicitacaoServicoViewModel>(entity);
            return View(model);
        }

        // GET: SolicitacaoServicoController/Create
        public ActionResult Create()
        {
            var model = new SolicitacaoServicoViewModel();
            PreencherSelectLists(model);
            return View(model);
        }

        // POST: SolicitacaoServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SolicitacaoServicoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = mapper.Map<Solicitacaoservico>(model);
                solicitacaoServicoService.Create(entity);
                return RedirectToAction(nameof(Index));
            }

            PreencherSelectLists(model);
            return View(model);
        }

        // GET: SolicitacaoServicoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var entity = solicitacaoServicoService.Get(id);
            if (entity == null) return NotFound();

            var model = mapper.Map<SolicitacaoServicoViewModel>(entity);
            PreencherSelectLists(model);
            return View(model);
        }

        // POST: SolicitacaoServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, SolicitacaoServicoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = mapper.Map<Solicitacaoservico>(model);
                solicitacaoServicoService.Edit(entity);
                return RedirectToAction(nameof(Index));
            }

            PreencherSelectLists(model);
            return View(model);
        }

        // GET: SolicitacaoServicoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var entity = solicitacaoServicoService.Get(id);
            if (entity == null) return NotFound();

            var model = mapper.Map<SolicitacaoServicoViewModel>(entity);
            return View(model);
        }

        // POST: SolicitacaoServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, SolicitacaoServicoViewModel model)
        {
            solicitacaoServicoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private void PreencherSelectLists(SolicitacaoServicoViewModel model)
        {
            model.ListaClientes = new SelectList(clienteService.GetAll(), "Id", "Nome", model.IdCliente);
            model.ListaProfissionais = new SelectList(profissionalService.GetAll(), "Id", "Nome", model.IdProfissional);
            model.ListaTiposServico = new SelectList(tipoServicoService.GetAll(), "Id", "Nome", model.IdTipoServico);
        }
    }
}
