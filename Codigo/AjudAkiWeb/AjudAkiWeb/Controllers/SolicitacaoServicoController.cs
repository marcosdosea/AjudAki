using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlX.XDevAPI;

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
            this.mapper = mapper;
        }

        // GET: SolicitacaoServicoController
        public ActionResult Index()
        {
            var listaSolicitacoesServico = solicitacaoServicoService.GetAll();
            var listaSolicitacoesServicoViewModel = mapper.Map<List<SolicitacaoServicoViewModel>>(listaSolicitacoesServico);

            return View(listaSolicitacoesServicoViewModel);
        }

        // GET: SolicitacaoServicoController/Details/5
        public ActionResult Details(uint id)
        {
            var solicitacaoServico = solicitacaoServicoService.Get(id);
            var solicitacaoServicoViewModel = mapper.Map<SolicitacaoServicoViewModel>(solicitacaoServico);
            return View(solicitacaoServicoViewModel);
        }

        // GET: SolicitacaoServicoController/Create
        public ActionResult Create()
        {
            var solicitacaoServicoViewModel = new SolicitacaoServicoViewModel();

            IEnumerable<Pessoa> listaProfissionais = profissionalService.GetAll();
            IEnumerable<Pessoa> listaClientes = clienteService.GetAll();
            IEnumerable<Tiposervico> listaTiposServico = tipoServicoService.GetAll();

            solicitacaoServicoViewModel.ListaTiposServico = new SelectList(listaTiposServico, "Id", "Nome", null);

            var statusListItems = Enum.GetValues(typeof(StatusSolicitacaoEnum))
                                .Cast<StatusSolicitacaoEnum>()
                                .Select(status => new SelectListItem
                                {
                                    Value = status.ToString(),
                                    Text = status.ToString()
                                })
                                .ToList();

            solicitacaoServicoViewModel.ListaProfissionais = new SelectList(listaProfissionais, "Id", "Nome", null);
            solicitacaoServicoViewModel.ListaClientes = new SelectList(listaClientes, "Id", "Nome", null);



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

            IEnumerable<Tiposervico> listaTiposServicos = tipoServicoService.GetAll();
            IEnumerable<Pessoa> listaProfissionais = profissionalService.GetAll();
            IEnumerable<Pessoa> listaClientes = clienteService.GetAll();

            solicitacaoServicoViewModel.ListaTiposServico = new SelectList(listaTiposServicos, "Id", "Nome",
                listaTiposServicos.FirstOrDefault(e => e.Id.Equals(solicitacaoServico.IdTipoServico)));

            solicitacaoServicoViewModel.ListaProfissionais = new SelectList(listaProfissionais, "Id", "Nome",
                listaProfissionais.FirstOrDefault(e => e.Id.Equals(solicitacaoServico.IdProfissional)));

            solicitacaoServicoViewModel.ListaClientes = new SelectList(listaClientes, "Id", "Nome",
                listaClientes.FirstOrDefault(e => e.Id.Equals(solicitacaoServico.IdCliente)));


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
        public ActionResult Delete(SolicitacaoServicoViewModel solicitacaoServicoViewModel)
        {
            solicitacaoServicoService.Delete(solicitacaoServicoViewModel.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
