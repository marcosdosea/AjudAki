using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;

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
            IEnumerable<Agendum> listaAgenda = agendaService.GetAll();
            IEnumerable<Areaatuacao> listaAreasAtuacoes = areaAtuacaoService.GetAll();
            tipoServicoViewModel.ListaAgenda = new SelectList(listaAgenda, "Id", "Nome", null);
            tipoServicoViewModel.ListaAreasAtuacoes = new SelectList(listaAreasAtuacoes, "Id", "Nome", null);
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
