using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
        public int PassengerCount { get; set; }
        public int DoorCount { get; set; }
        public bool AirConditioning { get; set; }
        public string GearBox { get; set; }
        public string QualityClass { get; set; }
        public decimal Price { get; set; }
    }
}