using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DAL.Entities;

namespace WebApplication.BLL.DataTransferObjects
{
    public class CarModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int PassengerCount { get; set; }
        public int DoorCount { get; set; }
        public bool AirConditioning { get; set; }
        public string GearBox { get; set; }
        public int QualityClassId { get; set; }
        public QualityClass QualityClass { get; set; }
        public int SmallLuggageCount { get; set; }
        public int LargeLuggageCount { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
    }
}
