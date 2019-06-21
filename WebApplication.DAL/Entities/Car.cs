using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
        public int RentalCenterId { get; set; }
        public RentalCenter RentalCenter { get; set; }

    }
}
