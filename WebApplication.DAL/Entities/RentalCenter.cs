using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.DAL.Entities
{
    public class RentalCenter
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string City { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}
