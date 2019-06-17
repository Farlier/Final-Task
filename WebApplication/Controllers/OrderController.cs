using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BLL.DataTransferObjects;
using WebApplication.BLL.Interfaces;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderController : Controller
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MakeOrder()
        {
            return View(new OrderViewModel());
        }

        [HttpPost]
        public ActionResult FinalizeOrder(OrderViewModel newOrder)
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<OrderViewModel, OrderDTO > ()).CreateMapper();
            var orderDto = mapper.Map<OrderViewModel, OrderDTO> (newOrder);
            _orderService.MakeOrder(orderDto);
            return View();
        }

        public ActionResult ViewOrders()
        {
            return View();
        }

        public ActionResult ViewOrders(int id)
        {
            return View();
        }
    }
}