using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.DAL.Entities
{
    public class ModelProperties
    {
        [Key]
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
        public int PassengerCount { get; set; }
        public int DoorCount { get; set; }
        public bool AirConditioning { get; set; }
        public string GearBox { get; set; }
        public int QualityClassId { get; set; }
        public QualityClass QualityClass { get; set; }

    }
}
