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
    public class QualityClassRepository:IRepository<QualityClass>
    {
        private CarContext db;
        public QualityClassRepository(CarContext context)
        {
            db = context;
        }
        public void Create(QualityClass item)
        {
            db.QualityClasses.Add(item);
        }

        public void Delete(int id)
        {
            QualityClass item = db.QualityClasses.Find(id);
            if (item != null)
                db.QualityClasses.Remove(item);
        }

        public IEnumerable<QualityClass> Find(Func<QualityClass, bool> predicate)
        {
            return db.QualityClasses.Where(predicate).ToList();
        }

        public QualityClass Get(int id)
        {
            return db.QualityClasses.Find(id);
        }

        public IEnumerable<QualityClass> GetAll()
        {
            return db.QualityClasses;
        }

        public void Update(QualityClass item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
