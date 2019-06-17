using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.BLL.DataTransferObjects;

namespace WebApplication.Models.ViewModels
{
    public class ViewClass
    {
        public string View { get; set; }
        public object NewModel { get; set; }
    }
}