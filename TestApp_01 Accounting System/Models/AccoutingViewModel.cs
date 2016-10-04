using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp_01_Accounting_System.Models
{
    public class CashFlowItem
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int InvoiceID { get; set; }
        public string Details { get; set; }
        public decimal Amount { get; set; }
    }
}