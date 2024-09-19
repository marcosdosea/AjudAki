using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers
{
    public class ProfissionalController : Controller
    {
        // GET: ProfissionalController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProfissionalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfissionalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfissionalController/Create
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

        // GET: ProfissionalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfissionalController/Edit/5
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

        // GET: ProfissionalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfissionalController/Delete/5
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
