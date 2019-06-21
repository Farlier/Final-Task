using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class OrderView
    {
        public bool NeedDriver { get; set; }
        public int DayCount { get; set; }

        public int ModelId { get; set; }

    }
}