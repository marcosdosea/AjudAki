using AutoMapper;
using AjudAkiWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers
{
    public class AreaAtuacaoController : Controller
    {
        private readonly IAreaAtuacaoService _areaAtuacaoService;
        private readonly IMapper _mapper;

        public AreaAtuacaoController(IAreaAtuacaoService areaAtuacaoService, IMapper mapper)
        {
            _areaAtuacaoService = areaAtuacaoService;
            _mapper = mapper;
        }

        // GET: AreaAtuacaoController
        public ActionResult Index()
        {
            var listaAreasAtuacao = _areaAtuacaoService.GetAll();
            var listaAreasAtuacaoViewModel = _mapper.Map<List<AreaAtuacaoViewModel>>(listaAreasAtuacao);
            return View(listaAreasAtuacaoViewModel);
        }

        // GET: AreaAtuacaoController/Details/5
        public ActionResult Details(uint id)
        {
            var areaAtuacao = _areaAtuacaoService.Get(id);
            var areaAtuacaoViewModel = _mapper.Map<AreaAtuacaoViewModel>(areaAtuacao);
            return View(areaAtuacaoViewModel);
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
                var areaAtuacao = _mapper.Map<Areaatuacao>(areaAtuacaoViewModel);
                _areaAtuacaoService.Create(areaAtuacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AreaAtuacaoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var areaAtuacao = _areaAtuacaoService.Get(id);
            var areaAtuacaoViewModel = _mapper.Map<AreaAtuacaoViewModel>(areaAtuacao);
            return View(areaAtuacaoViewModel);
        }

        // POST: AreaAtuacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, AreaAtuacaoViewModel areaAtuacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var areaAtuacao = _mapper.Map<Areaatuacao>(areaAtuacaoViewModel);
                _areaAtuacaoService.Edit(areaAtuacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AreaAtuacaoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var areaAtuacao = _areaAtuacaoService.Get(id);
            var areaAtuacaoViewModel = _mapper.Map<AreaAtuacaoViewModel>(areaAtuacao);
            return View(areaAtuacaoViewModel);
        }

        // POST: AreaAtuacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, AreaAtuacaoViewModel areaAtuacaoViewModel)
        {
            _areaAtuacaoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
