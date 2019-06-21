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
    public class ServiceRepository:IRepository<ServiceEntity>
    {
        private readonly CarContext db;
        public ServiceRepository(CarContext context)
        {
            db = context;
        }
        public void Create(ServiceEntity item)
        {
            db.ServiceEntities.Add(item);
        }

        public void Delete(int id)
        {
            ServiceEntity item = db.ServiceEntities.Find(id);
            if (item != null)
                db.ServiceEntities.Remove(item);
        }

        public IEnumerable<ServiceEntity> Find(Func<ServiceEntity, bool> predicate)
        {
            return db.ServiceEntities.Where(predicate).ToList();
        }

        public ServiceEntity Get(int id)
        {
            return db.ServiceEntities.Find(id);
        }

        public IEnumerable<ServiceEntity> GetAll()
        {
            return db.ServiceEntities;
        }

        public void Update(ServiceEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
