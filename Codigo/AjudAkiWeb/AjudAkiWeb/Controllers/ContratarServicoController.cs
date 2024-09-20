using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers
{
    public class ContratarServicoController : Controller
    {
        // GET: ContratarServicoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContratarServicoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContratarServicoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContratarServicoController/Create
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

        // GET: ContratarServicoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContratarServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ContratarServicoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContratarServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
