using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DAL.Entities;

namespace WebApplication.BLL.BusinessModels
{
    public class PriceCalculator
    {
        readonly Manufacturer manufacturer;
        readonly QualityClass qualityClass;

        public PriceCalculator(Manufacturer mr, QualityClass qc)
        {
            manufacturer = mr;
            qualityClass = qc;
        }

        public decimal GetPrice()
        {
            return manufacturer.Price + (decimal)0.6 * qualityClass.Price;        }
    }
}
