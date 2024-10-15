using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlX.XDevAPI;

namespace AjudAkiWeb.Controllers
{
    public class ProfissionalController : Controller
    {
        private readonly IAssinaturaService assinaturaService;
        private readonly IProfissionalService profissionalService;
        private readonly IMapper mapper;

        public ProfissionalController(IProfissionalService profissionalService, IAssinaturaService assinaturaService, IMapper mapper)
        {
            this.profissionalService = profissionalService;
            this.assinaturaService = assinaturaService;
            this.mapper = mapper;
        }

        // GET: ProfissionalController
        public ActionResult Index()
        {
            var listaProfissionais = profissionalService.GetAll();
            var listaProfissionalViewModel = mapper.Map<List<ProfissionalViewModel>>(listaProfissionais);
            return View(listaProfissionalViewModel);
        }

        // GET: ProfissionalController/Details/5
        public ActionResult Details(uint id)
        {
            var profissional = profissionalService.Get(id);
            var profissionalViewModel = mapper.Map<ProfissionalViewModel>(profissional);
            return View(profissionalViewModel);
        }

        // GET: ProfissionalController/Create
        public ActionResult Create()
        {
            var profissionalViewModel = new ProfissionalViewModel();
            profissionalViewModel.DataNascimento = DateTime.Now;
            IEnumerable<Assinatura> listaAssinaturas = assinaturaService.GetAll();
            profissionalViewModel.ListaAssinaturas = new SelectList(listaAssinaturas, "Id", "Nome", null);
            
            // Repreencher a lista de status
            var tipoPessoaListItems = Enum.GetValues(typeof(TipoPessoaEnum))
                .Cast<TipoPessoaEnum>()
                .Select(status => new SelectListItem
                {
                    Value = status.ToString(),
                    Text = status.ToString()
                })
                .ToList();

            profissionalViewModel.TipoPessoaList = new SelectList(tipoPessoaListItems, "Value", "Text");
            return View(profissionalViewModel);
        }

        // POST: ProfissionalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfissionalViewModel profissionalViewModel)
        {
            if (ModelState.IsValid)
            {
                var profissional = mapper.Map<Pessoa>(profissionalViewModel);
                profissionalService.Create(profissional);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProfissionalController/Edit/5
        public ActionResult Edit(uint id)
        {
            var profissional = profissionalService.Get(id);
            var profissionalViewModel = mapper.Map<ProfissionalViewModel>(profissional);
            IEnumerable<Assinatura> listaAssinaturas = assinaturaService.GetAll();

            profissionalViewModel.ListaAssinaturas = new SelectList(listaAssinaturas, "Id", "Nome",
                        listaAssinaturas.FirstOrDefault(e => e.Id.Equals(profissional.IdAssinatura)));

            return View(profissionalViewModel);
        }

        // POST: ProfissionalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ProfissionalViewModel profissionalViewModel)
        {
            if (ModelState.IsValid)
            {
                var profissional = mapper.Map<Pessoa>(profissionalViewModel);
                profissionalService.Edit(profissional);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProfissionalController/Delete/5
        public ActionResult Delete(uint id)
        {
            var profissional = profissionalService.Get(id);
            var profissionalViewModel = mapper.Map<ProfissionalViewModel>(profissional);
            return View(profissionalViewModel);
        }

        // POST: ProfissionalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProfissionalViewModel profissionalViewModel)
        {
            profissionalService.Delete(profissionalViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
