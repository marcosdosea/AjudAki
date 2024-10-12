using AjudAkiWeb.Models;
using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.IsisMtt;

namespace AjudAkiWeb.Controllers
{
    public class SolicitacaoServicoController : Controller
    {
        private readonly ISolicitacaoServicoService solicitacaoServicoService;
        private readonly IMapper mapper;

        public SolicitacaoServicoController(ISolicitacaoServicoService solicitacaoServicoService, IMapper mapper)
        {
            this.solicitacaoServicoService = solicitacaoServicoService;
            this.mapper = mapper;
        }

        // GET: SolicitacaoServicoController
        public ActionResult Index()
        {
            var listaAolicitacoesServico = solicitacaoServicoService.GetAll();
            var listaSolicitacoesServicoViewModel = mapper.Map<List<SolicitacaoServicoViewModel>>(listaAolicitacoesServico);
            return View(listaSolicitacoesServicoViewModel);
        }

        // GET: SolicitacaoServicoController/Details/5
        public ActionResult Details(uint id)
        {
            var solicitacaoServico = solicitacaoServicoService.Get(id);
            var solicitacaoServicoViewModel = mapper.Map<SolicitacaoServicoViewModel>(solicitacaoServico);
            return View();
        }

        // GET: SolicitacaoServicoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitacaoServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SolicitacaoServicoController/Edit/5
        public ActionResult Edit(uint id)
        {
            return View();
        }

        // POST: SolicitacaoServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SolicitacaoServicoController/Delete/5
        public ActionResult Delete(uint id)
        {
            return View();
        }

        // POST: SolicitacaoServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
