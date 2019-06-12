using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DAL.EFContexts;
using WebApplication.DAL.Entities;
using WebApplication.DAL.Interfaces;

namespace WebApplication.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CarContext db;
        CarModelRepository carModelRepository;
        CarRepository carRepository;
        ManufacturerRepository manufacturerRepository;
        ModelPropertiesRepository modelPropertiesRepository;
        OrderRepository orderRepository;
        QualityClassRepository qualityClassRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new CarContext(connectionString);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public IRepository<Manufacturer> Manufacturers
        {
            get
            {
                if (manufacturerRepository == null)
                    manufacturerRepository = new ManufacturerRepository(db);
                return manufacturerRepository;
            }
        }
        public IRepository<CarModel> CarModels
        {
            get
            {
                if (carModelRepository == null)
                    carModelRepository = new CarModelRepository(db);
                return carModelRepository;
            }
        }
        public IRepository<ModelProperties> ModelProperties
        {
            get
            {
                if (modelPropertiesRepository == null)
                    modelPropertiesRepository = new ModelPropertiesRepository(db);
                return modelPropertiesRepository;
            }
        }
        public IRepository<QualityClass> QualityClasses
        {
            get
            {
                if (qualityClassRepository == null)
                    qualityClassRepository = new QualityClassRepository(db);
                return qualityClassRepository;
            }
        }
        public IRepository<Car> Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepository(db);
                return carRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
