using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AjudAkiWeb.Controllers
{
    public class ServicoController : Controller
    {
        private readonly IProfissionalService profissionalService;
        private readonly IServicoService servicoService;
        private readonly ITipoServicoService tipoServicoService;
        private readonly IMapper mapper;

        public ServicoController(IServicoService servicoService, IProfissionalService profissionalService, ITipoServicoService tipoServicoService, IMapper mapper)
        {
            this.profissionalService = profissionalService;
            this.servicoService = servicoService;
            this.tipoServicoService = tipoServicoService;
            this.mapper = mapper;
        }

        // GET: ServicoController
        public ActionResult Index()
        {
            var listaServicos = servicoService.GetAll();
            var listaServicoViewModel = mapper.Map<List<ServicoViewModel>>(listaServicos);
            return View(listaServicoViewModel);
        }

        // GET: ServicoController/Details/5
        public ActionResult Details(uint id)
        {
            var servico = servicoService.Get(id);
            var servicoViewModel = mapper.Map<ServicoViewModel>(servico);
            return View(servicoViewModel);
        }

        // GET: ServicoController/Create
        public ActionResult Create()
        {
            var servicoViewModel = new ServicoViewModel();
            IEnumerable<Pessoa> listaProfissionais = profissionalService.GetAll();
            IEnumerable<Tiposervico> listaTiposServico = tipoServicoService.GetAll();
            servicoViewModel.ListaTiposServico = new SelectList(listaTiposServico, "Id", "Nome", null);
            servicoViewModel.ListaProfissionais = new SelectList(listaProfissionais, "Id", "Nome", null);
            servicoViewModel.DataHoraSolicitacao = DateTime.Now;
            return View(servicoViewModel);
        }

        // POST: ServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicoViewModel servicoViewModel)
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
            var servicoViewModel = mapper.Map<ServicoViewModel>(servico);
            IEnumerable<Tiposervico> listaTiposServicos = tipoServicoService.GetAll();
            IEnumerable<Pessoa> listaProfissionais = profissionalService.GetAll();

            servicoViewModel.ListaTiposServico = new SelectList(listaTiposServicos, "Id", "Nome",
                listaTiposServicos.FirstOrDefault(e => e.Id.Equals(servico.IdTipoServico)));

            servicoViewModel.ListaProfissionais = new SelectList(listaProfissionais, "Id", "Nome",
                listaProfissionais.FirstOrDefault(e => e.Id.Equals(servico.IdProfissional)));

            return View(servicoViewModel);
        }

        // POST: ServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ServicoViewModel servicoViewModel)
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
            var servicoViewModel = mapper.Map<ServicoViewModel>(servico);
            return View(servicoViewModel);
        }

        // POST: ProfissionalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, ServicoViewModel servicoViewModel)
        {
            servicoService.Delete(servicoViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
