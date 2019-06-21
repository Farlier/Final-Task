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
    public class CarInUseRepository : IRepository<CarInUse>
    {
        private readonly CarContext db;
        public CarInUseRepository(CarContext context)
        {
            db = context;
        }
        public void Create(CarInUse item)
        {
            db.CarsInUse.Add(item);
        }

        public void Delete(int id)
        {
            CarInUse item = db.CarsInUse.Find(id);
            if (item != null)
                db.CarsInUse.Remove(item);
        }

        public IEnumerable<CarInUse> Find(Func<CarInUse, bool> predicate)
        {
            return db.CarsInUse.Where(predicate).ToList();
        }

        public CarInUse Get(int id)
        {
            return db.CarsInUse.Find(id);
        }

        public IEnumerable<CarInUse> GetAll()
        {
            return db.CarsInUse;
        }

        public void Update(CarInUse item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
