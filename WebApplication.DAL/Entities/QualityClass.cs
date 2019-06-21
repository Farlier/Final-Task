using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.DAL.Entities
{
    public class QualityClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        
    }
}
