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
    public class ModelPropertiesRepository:IRepository<ModelProperties>
    {
        private CarContext db;
        public ModelPropertiesRepository(CarContext context)
        {
            db = context;
        }
        public void Create(ModelProperties item)
        {
            db.ModelProperties.Add(item);
        }

        public void Delete(int id)
        {
            ModelProperties item = db.ModelProperties.Find(id);
            if (item != null)
                db.ModelProperties.Remove(item);
        }

        public IEnumerable<ModelProperties> Find(Func<ModelProperties, bool> predicate)
        {
            return db.ModelProperties.Where(predicate).ToList();
        }

        public ModelProperties Get(int id)
        {
            return db.ModelProperties.Find(id);
        }

        public IEnumerable<ModelProperties> GetAll()
        {
            return db.ModelProperties;
        }

        public void Update(ModelProperties item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
