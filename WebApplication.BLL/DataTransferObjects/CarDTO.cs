using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.BLL.DataTransferObjects
{
    public class CarDTO
    {
        public int Id { get; set; }
        public int CarModelId { get; set; }
        public int RentalCenterId { get; set; }
    }
}
