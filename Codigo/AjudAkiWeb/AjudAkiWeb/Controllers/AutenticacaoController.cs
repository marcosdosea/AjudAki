using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers
{
    public class AutenticacaoController : Controller
    {
        // GET: AutenticacaoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AutenticacaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AutenticacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutenticacaoController/Create
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

        // GET: AutenticacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AutenticacaoController/Edit/5
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

        // GET: AutenticacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AutenticacaoController/Delete/5
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
