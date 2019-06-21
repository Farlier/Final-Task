using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApplication.BLL.DataTransferObjects;

namespace WebApplication.Models.ViewModels
{
    public class CreateCarViewModel
    {
        [DisplayName("Модель")]
        public string ModelName { get; set; }

        public IEnumerable<string> ValidModels { get; set; }
    }
}