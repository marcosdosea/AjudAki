using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers
{
    public class AvaliacaoController : Controller
    {
        // GET: AvaliacaoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AvaliacaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AvaliacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvaliacaoController/Create
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

        // GET: AvaliacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AvaliacaoController/Edit/5
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

        // GET: AvaliacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AvaliacaoController/Delete/5
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
