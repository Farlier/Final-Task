using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class CreateManufacturerViewModel
    {
        [DisplayName("Название производителя")]
        public string Name { get; set; }

        [DisplayName("Базовая цена на машины этого производителя")]
        public decimal Price { get; set; }
    }
}