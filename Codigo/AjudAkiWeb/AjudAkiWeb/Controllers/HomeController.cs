using AjudAkiWeb.Models;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AjudAkiWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicoService _servicoService;

        public HomeController(ILogger<HomeController> logger, IServicoService servicoService)
        {
            _logger = logger;
            _servicoService = servicoService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Buscar(string query)
        {
            var todosServicos = _servicoService.GetAll(); 

            if (!string.IsNullOrWhiteSpace(query))
            {
                todosServicos = todosServicos.Where(s =>
                    s.Nome != null &&
                    s.Nome.Contains(query, StringComparison.OrdinalIgnoreCase)
                );
            }

            return View("Index", todosServicos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
