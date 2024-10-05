using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers
{
    public class AreaAtuacaoController : Controller
    {

        private readonly IAreaAtuacaoService areaAtuacaoService;
        private readonly IMapper mapper;

        public AreaAtuacaoController(IAreaAtuacaoService areaAtuacaoService, IMapper mapper)
        {
            this.areaAtuacaoService = areaAtuacaoService;
            this.mapper = mapper;
        }

        // GET: AreaAtuacaoController
        public ActionResult Index()
        {
            var listaAreasAtuacao = areaAtuacaoService.GetAll();
            var listaAreasAtuacaoViewModel = mapper.Map<List<AreaAtuacaoViewModel>>(listaAreasAtuacao);

            return View(listaAreasAtuacaoViewModel);
        }

        // GET: AreaAtuacaoController/Details/5
        public ActionResult Details(uint id)
        {
            var areaAtuacao = areaAtuacaoService.Get(id);
            var areasAtuacaoViewModel = mapper.Map<AreaAtuacaoViewModel>(areaAtuacao);
            
            return View(areasAtuacaoViewModel);
        }

        // GET: AreaAtuacaoController/Create
        public ActionResult Create()
        {
            var areaAtuacaoViewModel = new AreaAtuacaoViewModel();

            return View(areaAtuacaoViewModel);
        }

        // POST: AreaAtuacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AreaAtuacaoViewModel areaAtuacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var areaAtuacao = mapper.Map<Areaatuacao>(areaAtuacaoViewModel);
                areaAtuacaoService.Create(areaAtuacao);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: AreaAtuacaoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var areaAtuacao = areaAtuacaoService.Get(id);
            var areaAtuacaoViewModel = mapper.Map<AreaAtuacaoViewModel>(areaAtuacao);
            
            return View(areaAtuacaoViewModel);
        }

        // POST: AreaAtuacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, AreaAtuacaoViewModel areaAtuacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var areaAtuacao = mapper.Map<Areaatuacao>(areaAtuacaoViewModel);
                areaAtuacaoService.Edit(areaAtuacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AreaAtuacaoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var areaAtuacao = areaAtuacaoService.Get(id);
            var areaAtuacaoViewModel = mapper.Map<AreaAtuacaoViewModel>(areaAtuacao);

            return View(areaAtuacaoViewModel);
        }

        // POST: AreaAtuacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AreaAtuacaoViewModel areaAtuacaoViewModel)
        {
            areaAtuacaoService.Delete(areaAtuacaoViewModel.Id);

            return RedirectToAction(nameof(Index));

        }
    }
}
