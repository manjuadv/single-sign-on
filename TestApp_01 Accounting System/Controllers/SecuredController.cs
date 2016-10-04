using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp_01_Accounting_System.Models;

namespace TestApp_01_Accounting_System.Controllers
{
    public class SecuredController : Controller
    {
        //
        // GET: /Secured/
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CashFlowHistory()
        {
            IList<CashFlowItem> cashFlowItems = Builder<CashFlowItem>.CreateListOfSize(10).Build();
            return View(cashFlowItems);
        }
	}
}