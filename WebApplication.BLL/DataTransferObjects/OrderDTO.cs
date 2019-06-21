using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.BLL.DataTransferObjects
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int DayCount { get; set; }
        public int CarId { get; set; }
        public bool WithDriver { get; set; }
        public string Status { get; set; }
    }
}
