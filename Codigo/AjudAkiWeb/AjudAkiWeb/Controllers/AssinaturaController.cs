using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Core;
using AutoMapper;
using AjudAkiWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AjudAkiWeb.Controllers
{
    public class AssinaturaController : Controller
    {
        private readonly IAssinaturaService assinaturaService;
        private readonly IMapper mapper;

        public AssinaturaController(IAssinaturaService assinaturaService, IMapper mapper)
        {
            this.assinaturaService = assinaturaService;
            this.mapper = mapper;
        }

        // GET: AssinaturaController
        public ActionResult Index()
        {
            try
            {
                var listaAssinaturas = assinaturaService.GetAll();
                var listaAssinaturaViewModel = mapper.Map<List<AssinaturaViewModel>>(listaAssinaturas);
                return View(listaAssinaturaViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao carregar assinaturas: {ex.Message}";
                return View(new List<AssinaturaViewModel>());
            }
        }

        // GET: AssinaturaController/Details/5
        public ActionResult Details(uint id)
        {
            var assinatura = assinaturaService.Get(id);
            if (assinatura == null)
            {
                TempData["ErrorMessage"] = "Assinatura não encontrada.";
                return RedirectToAction(nameof(Index));
            }

            var assinaturaViewModel = mapper.Map<AssinaturaViewModel>(assinatura);
            return View(assinaturaViewModel);
        }

        // GET: AssinaturaController/Create
        public ActionResult Create()
        {
            var assinaturaViewModel = new AssinaturaViewModel();
            PopularSelectLists(assinaturaViewModel);
            return View(assinaturaViewModel);
        }

        // POST: AssinaturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssinaturaViewModel assinaturaViewModel)
        {
            if (!ModelState.IsValid)
            {
                PopularSelectLists(assinaturaViewModel);
                return View(assinaturaViewModel);
            }

            try
            {
                var assinatura = mapper.Map<Assinatura>(assinaturaViewModel);
                assinaturaService.Create(assinatura);
                TempData["SuccessMessage"] = "Assinatura criada com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao criar assinatura: {ex.Message}";
                PopularSelectLists(assinaturaViewModel);
                return View(assinaturaViewModel);
            }
        }

        // GET: AssinaturaController/Edit/5
        public ActionResult Edit(uint id)
        {
            var assinatura = assinaturaService.Get(id);
            if (assinatura == null)
            {
                TempData["ErrorMessage"] = "Assinatura não encontrada.";
                return RedirectToAction(nameof(Index));
            }

            var assinaturaViewModel = mapper.Map<AssinaturaViewModel>(assinatura);
            PopularSelectLists(assinaturaViewModel);
            return View(assinaturaViewModel);
        }

        // POST: AssinaturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, AssinaturaViewModel assinaturaViewModel)
        {
            if (id != assinaturaViewModel.Id)
            {
                TempData["ErrorMessage"] = "IDs não correspondem.";
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                PopularSelectLists(assinaturaViewModel);
                return View(assinaturaViewModel);
            }

            try
            {
                var assinatura = mapper.Map<Assinatura>(assinaturaViewModel);
                assinaturaService.Edit(assinatura);
                TempData["SuccessMessage"] = "Assinatura atualizada com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao atualizar assinatura: {ex.Message}";
                PopularSelectLists(assinaturaViewModel);
                return View(assinaturaViewModel);
            }
        }

        // GET: AssinaturaController/Delete/5
        public ActionResult Delete(uint id)
        {
            var assinatura = assinaturaService.Get(id);
            if (assinatura == null)
            {
                TempData["ErrorMessage"] = "Assinatura não encontrada.";
                return RedirectToAction(nameof(Index));
            }

            var assinaturaViewModel = mapper.Map<AssinaturaViewModel>(assinatura);
            return View(assinaturaViewModel);
        }

        // POST: AssinaturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, AssinaturaViewModel assinaturaViewModel)
        {
            if (id != assinaturaViewModel.Id)
            {
                TempData["ErrorMessage"] = "IDs não correspondem.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                assinaturaService.Delete(id);
                TempData["SuccessMessage"] = "Assinatura excluída com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao excluir assinatura: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        private void PopularSelectLists(AssinaturaViewModel viewModel)
        {
            var statusListItems = Enum.GetValues(typeof(AssinaturaStatusEnum))
               .Cast<AssinaturaStatusEnum>()
               .Select(status => new SelectListItem
               {
                   Value = status.ToString(),
                   Text = status.ToString()
               })
               .ToList();

            var planoListItems = Enum.GetValues(typeof(AssinaturaNomeEnum))
               .Cast<AssinaturaNomeEnum>()
               .Select(plano => new SelectListItem
               {
                   Value = plano.ToString(),
                   Text = plano.ToString()
               })
               .ToList();

            var selectedStatus = viewModel.Id == 0 ? null : viewModel.Status.ToString();
            var selectedPlano = viewModel.Id == 0 ? null : viewModel.Nome.ToString();

            viewModel.StatusList = new SelectList(statusListItems, "Value", "Text", selectedStatus);
            viewModel.PlanoList = new SelectList(planoListItems, "Value", "Text", selectedPlano);
        }
    }
}
