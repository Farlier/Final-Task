using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DAL.Entities;

namespace WebApplication.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Manufacturer> Manufacturers { get; }
        IRepository<CarModel> CarModels { get; }
        IRepository<QualityClass> QualityClasses { get; }
        IRepository<Car> Cars { get; }
        IRepository<Order> Orders { get; }
        IRepository<CarInUse> CarsInUse { get; }
        IRepository<ServiceEntity> Services { get; }
        void Save();
    }
}
