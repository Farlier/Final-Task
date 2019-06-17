using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public bool WithDriver { get; set; }
    }
}