using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DAL.Entities;

namespace WebApplication.DAL.EFContexts
{
    public class CarContext : DbContext
    {
        public IDbSet<Manufacturer> Manufacturers { get; set; }
        public IDbSet<CarModel> CarModels { get; set; }
        public IDbSet<QualityClass> QualityClasses { get; set; }
        public IDbSet<Car> Cars { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<RentalCenter> RentalCenters { get; set; }
        public IDbSet<CarInUse> CarsInUse { get; set; }
        public IDbSet<ServiceEntity> ServiceEntities { get; set; }

        static CarContext()
        {
            Database.SetInitializer(new CarInitializer());
        }

        public CarContext(string connectionString)
            :base(connectionString)
        {

        }
    }
}
