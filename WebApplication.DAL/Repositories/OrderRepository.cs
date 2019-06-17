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
    public class OrderRepository: IRepository<Order>
    {
        private readonly CarContext db;
        public OrderRepository(CarContext context)
        {
            db = context;
        }
        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order item = db.Orders.Find(id);
            if (item != null)
                db.Orders.Remove(item);
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return db.Orders.Where(predicate).ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
