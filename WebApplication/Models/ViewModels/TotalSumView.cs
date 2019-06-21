using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class TotalSumView
    {
        public string Car { get; set; }
        public decimal PricePerDay { get; set; }
        public int DayCount { get; set; }
        public decimal Price { get; set; }
        public bool Driver { get; set; }
        public decimal DriverPrice { get; set; }
        public decimal Sum { get; set; }
    }
}