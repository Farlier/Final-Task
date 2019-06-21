using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.FilterModels
{
    public class FilterViewModel
    {
        public IEnumerable<ManufacturerFilter> manufacturerFilters { get; set; }
        public IEnumerable<QualityClassFilter> qualityClassFilters { get; set; }
        

        
    }
}
