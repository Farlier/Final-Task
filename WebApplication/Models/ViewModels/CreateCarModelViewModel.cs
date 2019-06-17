using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class CreateCarModelViewModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string ManufacturerName { get; set; }
        public int PassengerCount { get; set; }
        public int DoorCount { get; set; }
        public bool AirConditioning { get; set; }
        public string GearBox { get; set; }
        public string QualityClassName { get; set; }
        public int SmallLuggageCount { get; set; }
        public int LargeLuggageCount { get; set; }
    }
}