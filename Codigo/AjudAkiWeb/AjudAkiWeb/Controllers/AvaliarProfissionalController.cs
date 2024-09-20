using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers
{
    public class AvaliarProfissionalController : Controller
    {
        // GET: AvaliarProfissionalController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AvaliarProfissionalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AvaliarProfissionalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvaliarProfissionalController/Create
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

        // GET: AvaliarProfissionalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AvaliarProfissionalController/Edit/5
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

        // GET: AvaliarProfissionalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AvaliarProfissionalController/Delete/5
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
