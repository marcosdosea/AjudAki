using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AjudAkiWeb.Controllers
{
    public class ContratacaoController : Controller
    {
        private readonly IContratacaoService contratacaoService;
        private readonly IClienteService clienteService;
        private readonly IServicoService servicoService;
        private readonly IMapper mapper;

        public ContratacaoController(IContratacaoService contratacaoService, IClienteService clienteService, IServicoService servicoService, IMapper mapper)
        {
            this.contratacaoService = contratacaoService;
            this.clienteService = clienteService;
            this.servicoService = servicoService;
            this.mapper = mapper;
        }

        // GET: ContratacaoController
        public ActionResult Index()
        {
            var listaContratacoes = contratacaoService.GetAll();
            var listaContratacaoViewModel = mapper.Map<List<ContratacaoViewModel>>(listaContratacoes);

            return View(listaContratacaoViewModel);
        }

        // GET: ContratacaoController/Details/5
        public ActionResult Details(uint id)
        {
            var contratacao = contratacaoService.Get(id);
            var contratacaoViewModel = mapper.Map<ContratacaoViewModel>(contratacao);

            return View(contratacaoViewModel);
        }

        // GET: ContratacaoController/Create
        public ActionResult Create()
        {
            var contratacaoViewModel = new ContratacaoViewModel();

            IEnumerable<Pessoa> listaClientes = clienteService.GetAll();
            IEnumerable<Servico> listaServicos = servicoService.GetAll();

            contratacaoViewModel.ListaClientes = new SelectList(listaClientes, "Id", "Nome", null);
            contratacaoViewModel.ListaServicos = new SelectList(listaServicos, "Id", "Nome", null);

            // Repreencher a lista de status
            var statusListItems = Enum.GetValues(typeof(ContratacaoStatusEnum))
                .Cast<ContratacaoStatusEnum>()
                .Select(status => new SelectListItem
                {
                    Value = status.ToString(),
                    Text = status.ToString()
                })
                .ToList();

            contratacaoViewModel.StatusList = new SelectList(statusListItems, "Value", "Text");


            contratacaoViewModel.Data = DateTime.Now;

            return View(contratacaoViewModel);
        }

        // POST: ContratacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContratacaoViewModel contratacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var contratacao = mapper.Map<Contratacao>(contratacaoViewModel);
                contratacaoService.Create(contratacao);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ContratacaoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var contratacao = contratacaoService.Get(id);
            var contratacaoViewModel = mapper.Map<ContratacaoViewModel>(contratacao);

            IEnumerable<Pessoa> listaClientes = clienteService.GetAll();
            IEnumerable<Servico> listaServicos = servicoService.GetAll();

            contratacaoViewModel.ListaClientes = new SelectList(listaClientes, "Id", "Nome",
                listaClientes.FirstOrDefault(e => e.Id.Equals(contratacao.IdCliente)));

            contratacaoViewModel.ListaServicos = new SelectList(listaServicos, "Id", "Nome",
                listaServicos.FirstOrDefault(e => e.Id.Equals(contratacao.IdServico)));


            return View(contratacaoViewModel);
        }

        // POST: ContratacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ContratacaoViewModel contratacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var contratacao = mapper.Map<Contratacao>(contratacaoViewModel);
                contratacaoService.Edit(contratacao);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ContratacaoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var contratacao = contratacaoService.Get(id);
            var contratacaoViewModel = mapper.Map<ContratacaoViewModel>(contratacao);

            return View(contratacaoViewModel);
        }

        // POST: ContratacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ContratacaoViewModel contratacaoViewModel)
        {
            contratacaoService.Delete(contratacaoViewModel.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
