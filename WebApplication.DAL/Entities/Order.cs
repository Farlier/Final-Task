using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public bool WithDriver { get; set; }
        public decimal Sum { get; set; }
    }
}
