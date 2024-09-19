using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers
{
    public class TipoServicoController : Controller
    {
        // GET: TipoServicoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoServicoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoServicoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoServicoController/Create
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

        // GET: TipoServicoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoServicoController/Edit/5
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

        // GET: TipoServicoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoServicoController/Delete/5
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
