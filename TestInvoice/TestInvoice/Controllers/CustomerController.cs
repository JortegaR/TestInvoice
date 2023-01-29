using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestInvoice.Data;
using TestInvoice.Models;

namespace TestInvoice.Controllers
{
    public class CustomerController : Controller
    {
        CustomerViewModel model = new CustomerViewModel();
        // GET: Customer
        public ActionResult Index()
        {
            return View(model.ObtenerCustomer());
        }

        // GET: Customer/Details/5
        public ActionResult Detalle(int id)
        {
            return View(model.ObtenerCustomer(id));
        }

        // GET: Customer/Create
        public ActionResult Nuevo()
        {
            model._customerTypes = model.ObtenerListaCustomerTypes();
            return View(model);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Nuevo(CustomerViewModel customer)
        {
            model.Agregar(customer);
            return RedirectToAction("Index", "Customer");
        }

        // GET: Customer/Edit/5
        public ActionResult Editar(int id)
        {
            model._customerTypes = model.ObtenerListaCustomerTypes();
            return View(model.ObtenerCustomer(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Editar(CustomerViewModel customer)
        {
            model.Editar(customer);
            return RedirectToAction("Index", "Customer");
        }

        // GET: Customer/Delete/5
        public ActionResult Borrar(int id)
        {
            return View(model.ObtenerCustomer(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Borrar(CustomerViewModel customer)
        {
            model._message = model.Borrar(customer._customerId);
            if (model._message == "OK") return RedirectToAction("Index", "Customer");
            else
            {
                model = model.ObtenerCustomer(customer._customerId);
                return View(model);
            }
        }
    }
}
