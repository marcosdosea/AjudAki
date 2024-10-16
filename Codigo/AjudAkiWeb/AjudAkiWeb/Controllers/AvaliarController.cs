using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;

namespace AjudAkiWeb.Controllers
{
    public class AvaliarController : Controller
    {
        private readonly IContratacaoService contratacaoService;
        private readonly IAvaliarService avaliarService;
        private readonly IMapper mapper;

        public AvaliarController(IAvaliarService avaliarService, IContratacaoService contratacaoService, IMapper mapper)
        {
            this.avaliarService = avaliarService;
            this.contratacaoService = contratacaoService;
            this.mapper = mapper;
        }

        // GET: AvaliarController
        public ActionResult Index()
        {
            var listaAvaliar = avaliarService.GetAll();
            var listaAvaliarViewModel = mapper.Map<List<AvaliarViewModel>>(listaAvaliar);

            return View(listaAvaliarViewModel);
        }
        // GET: AvaliarController/Details/5
        public ActionResult Details(uint id)
        {
            var avaliar = avaliarService.Get(id);
            var avaliarsViewModel = mapper.Map<AvaliarViewModel>(avaliar);

            return View(avaliarsViewModel);
        }

        // GET: AvaliarController/Create
        public ActionResult Create()
        {
            var avaliarViewModel = new AvaliarViewModel();
            IEnumerable<Contratacao> listaContratacaos = contratacaoService.GetAll();
            avaliarViewModel.ListaContratacaos = new SelectList(listaContratacaos, "Id", "Nome", null);
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
