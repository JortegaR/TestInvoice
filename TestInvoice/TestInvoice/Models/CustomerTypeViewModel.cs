using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestInvoice.Data;

namespace TestInvoice.Models
{
    public class CustomerTypeViewModel
    {
        TestInvoiceEntities _entities = new TestInvoiceEntities();
        public int _customerTypeId { get; set; }
        public string _descripcion { get; set; }
        public string _message { get; set; }


        public List<CustomerTypeViewModel> ObtenerCustomerTypes()
        {
            var model = _entities.CustomerTypes.Select(data => new CustomerTypeViewModel
            {
                _customerTypeId = data.Id,
                _descripcion = data.Description
            }).ToList();
            return model;
        }


        public void Agregar(CustomerTypeViewModel model)
        {
            CustomerTypes customerType = new CustomerTypes();
            customerType.Description = model._descripcion;
            _entities.CustomerTypes.Add(customerType);
            _entities.SaveChanges();
        }

        public CustomerTypeViewModel ObtenerCustomerTypes(int id)
        {
            var model = _entities.CustomerTypes.Where(x => x.Id == id).Select(data => new CustomerTypeViewModel
            {
                _customerTypeId = data.Id,
                _descripcion = data.Description
            }).FirstOrDefault();
            return model;
        }

        public void Editar(CustomerTypeViewModel Model)
        {
            CustomerTypes customerType = _entities.CustomerTypes.Find(Model._customerTypeId);
            customerType.Description = Model._descripcion;
            _entities.SaveChanges();
        }

        public string Borrar(int id)
        {
            CustomerTypes model = _entities.CustomerTypes.Find(id);

            if(model.Customers == null)
            {
                _entities.CustomerTypes.Remove(model);
                _entities.SaveChanges();
                return "OK";
            }
            else return "No se puede borrar el tipo cliente por que tiene cliente enlazados";
        }
    }
}