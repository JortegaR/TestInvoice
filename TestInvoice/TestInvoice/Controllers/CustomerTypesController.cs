using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestInvoice.Models;

namespace TestInvoice.Controllers
{
    public class CustomerTypesController : Controller
    {
        CustomerTypeViewModel model = new CustomerTypeViewModel();
        // GET: CustomerTypes
        public ActionResult Index()
        {
            return View(model.ObtenerCustomerTypes());
        }

        // GET: CustomerTypes/Details/5
        public ActionResult Detalle(int id)
        {
            return View(model.ObtenerCustomerTypes(id));
        }

        // GET: CustomerTypes/Create
        public ActionResult Nuevo()
        {
            return View(model);
        }

        // POST: CustomerTypes/Create
        [HttpPost]
        public ActionResult Nuevo(CustomerTypeViewModel customerType)
        {
            model.Agregar(customerType);
            return RedirectToAction("Index", "CustomerTypes");
        }

        // GET: CustomerTypes/Edit/5
        public ActionResult Editar(int id)
        {
            return View(model.ObtenerCustomerTypes(id));
        }

        // POST: CustomerTypes/Edit/5
        [HttpPost]
        public ActionResult Editar(CustomerTypeViewModel customerType)
        {
            model.Editar(customerType);
            return RedirectToAction("Index", "CustomerTypes");
        }

        // GET: CustomerTypes/Delete/5
        public ActionResult Borrar(int id)
        {
            return View(model.ObtenerCustomerTypes(id));
        }

        // POST: CustomerTypes/Delete/5
        [HttpPost]
        public ActionResult Borrar(CustomerTypeViewModel customerType)
        {
            model._message = model.Borrar(customerType._customerTypeId);
            if (model._message == "OK") return RedirectToAction("Index", "CustomerTypes");
            else
            {
                model = model.ObtenerCustomerTypes(customerType._customerTypeId);
                return View(model);
            }
        }
    }
}
