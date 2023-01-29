using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using TestInvoice.Data;

namespace TestInvoice.Models
{
    public class InvoiceViewModel
    {
        public int _invoiceId { get; set; }
        public int _customerId { get; set; }

        public decimal _totalItbis { get; set; }
        public decimal _subTotal { get; set; }
        public decimal _total { get; set; }

        public ICollection<InvoiceDetail> _invoiceDetail { get; set; }


    }
}