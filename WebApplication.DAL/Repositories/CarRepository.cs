using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DAL.EFContexts;
using WebApplication.DAL.Entities;
using WebApplication.DAL.Interfaces;

namespace WebApplication.DAL.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private readonly CarContext db;
        public CarRepository(CarContext context)
        {
            db = context;
        }
        public void Create(Car item)
        {
            db.Cars.Add(item);
        }

        public void Delete(int id)
        {
            Car item = db.Cars.Find(id);
            if (item != null)
                db.Cars.Remove(item);
        }

        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            return db.Cars.Where(predicate).ToList();
        }

        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }

        public IEnumerable<Car> GetAll()
        {
            return db.Cars;
        }

        public void Update(Car item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
