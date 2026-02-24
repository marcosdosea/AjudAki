using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AjudAkiWeb.Controllers
{
    public class TipoServicoController : Controller
    {
        private readonly IAreaAtuacaoService areaAtuacaoService;
        private readonly IAgendaService agendaService;
        private readonly ITipoServicoService tipoServicoService;
        private readonly IMapper mapper;

        public TipoServicoController(ITipoServicoService tipoServicoService, IAgendaService agendaService, IAreaAtuacaoService areaAtuacaoService, IMapper mapper)
        {
            this.tipoServicoService = tipoServicoService;
            this.agendaService = agendaService;
            this.areaAtuacaoService = areaAtuacaoService;
            this.mapper = mapper;
        }

        // GET: TipoServicoController
        // GET: TipoServicoController
        public ActionResult Index()
        {
            return RedirectToAction("Index", "AreaAtuacao");
        }

        // GET: TipoServicoController/Details/5
        public ActionResult Details(uint id)
        {
            var tipoServico = tipoServicoService.Get(id);
            if (tipoServico == null)
            {
                return NotFound();
            }
            var tipoServicoViewModel = mapper.Map<TipoServicoViewModel>(tipoServico);
            return View(tipoServicoViewModel);
        }

        // GET: TipoServicoController/Create
        public ActionResult Create()
        {
            var tipoServicoViewModel = new TipoServicoViewModel();
            PopulateLists(tipoServicoViewModel);
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
                return RedirectToAction("Index", "AreaAtuacao");
            }
            PopulateLists(tipoServicoViewModel);
            return View(tipoServicoViewModel);
        }

        // GET: TipoServicoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var tipoServico = tipoServicoService.Get(id);
            if (tipoServico == null)
            {
                return NotFound();
            }
            var tipoServicoViewModel = mapper.Map<TipoServicoViewModel>(tipoServico);
            PopulateLists(tipoServicoViewModel);
            return View(tipoServicoViewModel);
        }

        // POST: TipoServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, TipoServicoViewModel tipoServicoViewModel)
        {
            if (id != tipoServicoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var tipoServico = mapper.Map<Tiposervico>(tipoServicoViewModel);
                tipoServicoService.Edit(tipoServico);
                return RedirectToAction("Index", "AreaAtuacao");
            }
            PopulateLists(tipoServicoViewModel);
            return View(tipoServicoViewModel);
        }

        // GET: TipoServicoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var tipoServico = tipoServicoService.Get(id);
            if (tipoServico == null)
            {
                return NotFound();
            }
            var tipoServicoViewModel = mapper.Map<TipoServicoViewModel>(tipoServico);
            return View(tipoServicoViewModel);
        }

        // POST: TipoServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, TipoServicoViewModel collection)
        {
            try
            {
                tipoServicoService.Delete(id);
                return RedirectToAction("Index", "AreaAtuacao");
            }
            catch
            {
                return RedirectToAction("Index", "AreaAtuacao");
            }
        }

        private void PopulateLists(TipoServicoViewModel viewModel)
        {
            var listaAgenda = agendaService.GetAll();
            var listaAreasAtuacoes = areaAtuacaoService.GetAll();

            viewModel.ListaAgenda = new SelectList(listaAgenda.Select(a => new
            {
                Id = a.Id,
                Descricao = $"{a.Data:dd/MM/yyyy} - {a.Turno}"
            }), "Id", "Descricao", viewModel.IdAgenda);

            viewModel.ListaAreasAtuacoes = new SelectList(listaAreasAtuacoes, "Id", "Nome", viewModel.IdAreaAtuacao);
        }
    }
}
