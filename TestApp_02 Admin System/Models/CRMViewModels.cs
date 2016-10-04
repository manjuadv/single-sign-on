using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp_02_Admin_System.Models
{
    public class CallLog
    {      
        public string CustomerName { get; set; }
        public string CalledBy { get; set; }
        public DateTime CalledOn { get; set; }
        public bool IsFeedbackPositive { get; set; }
    }
}