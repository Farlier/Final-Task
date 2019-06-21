using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class CreateCarModelViewModel
    {
        [DisplayName("Имя модели")]
        public string Name { get; set; }

        [DisplayName("Производитель")]
        public string ManufacturerName { get; set; }

        [DisplayName("Количество пасажиров")]
        public int PassengerCount { get; set; }

        [DisplayName("Количество дверей")]
        public int DoorCount { get; set; }

        [DisplayName("Кондиционер")]
        public bool AirConditioning { get; set; }

        [DisplayName("Коробка передач")]
        public string GearBox { get; set; }

        [DisplayName("Класс качества")]
        public string QualityClassName { get; set; }

        [DisplayName("Вместимость (небольшие сумки)")]
        public int SmallLuggageCount { get; set; }

        [DisplayName("Вместимость (большие сумки)")]
        public int LargeLuggageCount { get; set; }

        public IEnumerable<string> GearBoxType
        {
            get
            {
                return Enum.GetNames(typeof(EnumGearBoxType));
            }
        }

        public IEnumerable<string> ManufacturersView { get; set; }
        public IEnumerable<string> QualityClassesView { get; set; }

        public enum EnumGearBoxType
        {
            Автомат,
            Ручная
        }


    }
}