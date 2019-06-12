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
    class CarModelRepository:IRepository<CarModel>
    {
        private CarContext db;
        public CarModelRepository(CarContext context)
        {
            db = context;
        }
        public void Create(CarModel item)
        {
            db.CarModels.Add(item);
        }

        public void Delete(int id)
        {
            CarModel item = db.CarModels.Find(id);
            if (item != null)
                db.CarModels.Remove(item);
        }

        public IEnumerable<CarModel> Find(Func<CarModel, bool> predicate)
        {
            return db.CarModels.Where(predicate).ToList();
        }

        public CarModel Get(int id)
        {
            return db.CarModels.Find(id);
        }

        public IEnumerable<CarModel> GetAll()
        {
            return db.CarModels;
        }

        public void Update(CarModel item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
