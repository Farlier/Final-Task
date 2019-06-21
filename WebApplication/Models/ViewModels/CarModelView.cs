using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApplication.BLL.DataTransferObjects;

namespace WebApplication.Models.ViewModels
{
    public class CarModelView:CarModelDTO
    {
        [DisplayName("В наличии")]
        public int Count { get; set; }
    }
}