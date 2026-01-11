using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service;

namespace AjudAkiWeb.Controllers
{
    public class AvaliarController : Controller
    {
        private readonly IContratacaoService contratacaoService;
        private readonly IAvaliarService avaliarService;
        private readonly IServicoService servicoService;
        private readonly IProfissionalService profissionalService;
        private readonly IMapper mapper;

        public AvaliarController(IAvaliarService avaliarService, IContratacaoService contratacaoService, IServicoService servicoService, IProfissionalService profissionalService, IMapper mapper)
        {
            this.avaliarService = avaliarService;
            this.contratacaoService = contratacaoService;
            this.servicoService = servicoService;
            this.profissionalService = profissionalService;
            this.mapper = mapper;
        }

        // GET: AvaliarController
        public ActionResult Index()
        {
            var listaAvaliar = avaliarService.GetAll();
            var listaAvaliarViewModel = mapper.Map<List<AvaliarViewModel>>(listaAvaliar);

            // Carregar nomes dos profissionais
            foreach (var avaliacao in listaAvaliarViewModel)
            {
                avaliacao.NomeProfissional = ObterNomeProfissional(avaliacao.IdContratacao);
            }

            return View(listaAvaliarViewModel);
        }
        // GET: AvaliarController/Details/5
        public ActionResult Details(uint id)
        {
            var avaliar = avaliarService.Get(id);
            var avaliarsViewModel = mapper.Map<AvaliarViewModel>(avaliar);

            // Carregar nome do profissional
            avaliarsViewModel.NomeProfissional = ObterNomeProfissional(avaliarsViewModel.IdContratacao);

            return View(avaliarsViewModel);
        }

        private string? ObterNomeProfissional(int idContratacao)
        {
            var contratacao = contratacaoService.Get((uint)idContratacao);
            if (contratacao != null)
            {
                var servico = servicoService.Get(contratacao.IdServico);
                if (servico != null)
                {
                    var profissional = profissionalService.Get(servico.IdProfissional);
                    return profissional?.Nome;
                }
            }
            return null;
        }

        // GET: AvaliarController/Create
        public ActionResult Create()
        {
            var avaliarViewModel = new AvaliarViewModel();
            // Materializar a lista primeiro para evitar erro de DataReader
            var listaContratacaos = contratacaoService.GetAll().ToList();
            
            // Criar SelectList com nome da contratação e profissional
            var items = new List<SelectListItem>();
            foreach (var contratacao in listaContratacaos)
            {
                var servico = servicoService.Get(contratacao.IdServico);
                string displayText = contratacao.Nome;
                
                if (servico != null)
                {
                    var profissional = profissionalService.Get(servico.IdProfissional);
                    if (profissional != null)
                    {
                        displayText = $"{contratacao.Nome} - Prof: {profissional.Nome}";
                    }
                }
                
                items.Add(new SelectListItem
                {
                    Value = contratacao.Id.ToString(),
                    Text = displayText
                });
            }
            
            avaliarViewModel.ListaContratacaos = new SelectList(items, "Value", "Text", null);
            return View(avaliarViewModel);
        }

        // POST: AvaliarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AvaliarViewModel avaliarViewModel)
        {
            if (ModelState.IsValid)
            {
                var avaliar = mapper.Map<Avaliacao>(avaliarViewModel);
                avaliarService.Create(avaliar);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
