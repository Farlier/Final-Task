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
    public class ManufacturerRepository : IRepository<Manufacturer>
    {
        private CarContext db;
        public ManufacturerRepository(CarContext context)
        {
            db = context;
        }
        public void Create(Manufacturer item)
        {
            db.Manufacturers.Add(item);
        }

        public void Delete(int id)
        {
            Manufacturer item = db.Manufacturers.Find(id);
            if (item != null)
                db.Manufacturers.Remove(item);
        }

        public IEnumerable<Manufacturer> Find(Func<Manufacturer, bool> predicate)
        {
            return db.Manufacturers.Where(predicate).ToList();
        }

        public Manufacturer Get(int id)
        {
            return db.Manufacturers.Find(id);
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return db.Manufacturers;
        }

        public void Update(Manufacturer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
