using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestInvoice.Data;

namespace TestInvoice.Models
{
    public class CustomerViewModel
    {
        TestInvoiceEntities _entities = new TestInvoiceEntities();

        public int _customerId { get; set; }
        public string _custName { get; set; }
        public string _adress { get; set; }
        public bool _status { get; set; }
        public int _customerTypeId { get; set; }
        public string _customerTypeDescripcion { get; set; }
        public string _message { get; set; }
        public IEnumerable<CustomerTypes> _customerTypes { get; set; }


        public List<CustomerViewModel> ObtenerCustomer()
        {
            var model = _entities.Customers.Select(data => new CustomerViewModel
            {
                _customerId = data.Id,
                _custName = data.CustName,
                _adress = data.Adress,
                _status = data.Status,
                _customerTypeId = data.CustomerTypeId,
                _customerTypeDescripcion = data.CustomerTypes.Description
            }).ToList();
            return model;
        }


        public void Agregar(CustomerViewModel model)
        {
            Customers customer = new Customers();
            customer.CustName = model._custName;
            customer.Adress = model._adress;
            customer.Status = model._status;
            customer.CustomerTypeId = model._customerTypeId;
            _entities.Customers.Add(customer);
            _entities.SaveChanges();
        }

        public CustomerViewModel ObtenerCustomer(int id)
        {
            var model = _entities.Customers.Where(x => x.Id == id).Select(data => new CustomerViewModel
            {
                _customerId = data.Id,
                _custName = data.CustName,
                _adress = data.Adress,
                _status = data.Status,
                _customerTypeId = data.CustomerTypeId,
                _customerTypeDescripcion = data.CustomerTypes.Description
            }).FirstOrDefault();
            model._customerTypes = ObtenerListaCustomerTypes();
            return model;
        }

        public void Editar(CustomerViewModel Model)
        {
            Customers customerType = _entities.Customers.Find(Model._customerId);
            customerType.CustName = Model._custName;
            customerType.Adress = Model._adress;
            customerType.Status = Model._status;
            customerType.CustomerTypeId = Model._customerTypeId;
            _entities.SaveChanges();
        }

        public string Borrar(int id)
        {
            Customers model = _entities.Customers.Find(id);

            if(model.Invoice.Count == 0)
            {
                _entities.Customers.Remove(model);
                _entities.SaveChanges();
                return "OK";
            }
            else return "No se puede borrar el cliente por que tiene facturas enlazadas";
            
        }

        public IEnumerable<CustomerTypes> ObtenerListaCustomerTypes()
        {
            return _entities.CustomerTypes.ToList();
        }
    }
}