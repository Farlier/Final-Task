using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BLL.BusinessModels;
using WebApplication.BLL.DataTransferObjects;
using WebApplication.BLL.Infrastructure;
using WebApplication.BLL.Interfaces;
using WebApplication.DAL.Entities;
using WebApplication.DAL.Interfaces;

namespace WebApplication.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Db { get; set; }

        public OrderService(IUnitOfWork unit)
        {
            Db = unit;
        }
        public void Dispose()
        {
            Db.Dispose();
        }

       

        public void MakeOrder(OrderDTO orderDto)
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<OrderDTO,Order>()).CreateMapper();
            var order = mapper.Map<OrderDTO, Order>(orderDto);



        }
    }
}
