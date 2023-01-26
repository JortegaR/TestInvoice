using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestInvoice.Controllers
{
    public class TipoClienteController : Controller
    {
        // GET: TipoClienteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoClienteController/Create
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

        // GET: TipoClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoClienteController/Edit/5
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

        // GET: TipoClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoClienteController/Delete/5
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
