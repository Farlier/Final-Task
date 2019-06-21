using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BLL.DataTransferObjects;
using WebApplication.BLL.Interfaces;
using WebApplication.Models;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class OrderController : Controller
    {
        IOrderService _orderService;
        ICarService _carService;
        ICarModelService _carModelService;

        public OrderController(IOrderService orderService, ICarService carService, ICarModelService carModelService)
        {
            _orderService = orderService;
            _carService = carService;
            _carModelService = carModelService;
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Rent(int id)
        {
            return View(new OrderView { ModelId = id });
        }

        [HttpPost]
        public ActionResult Rent(OrderView order)
        {
            OrderDTO newOrder = new OrderDTO();
            //TotalSumView totalSumView = new TotalSumView
            //{
                
            //}

            newOrder.CarId = _carService.GetAvaibleCars().FirstOrDefault(it => it.CarModelId == order.ModelId).Id;
            newOrder.DayCount = order.DayCount;
            newOrder.UserId=User.Identity.GetUserId();
            newOrder.WithDriver = order.NeedDriver;

            _orderService.MakeOrder(newOrder);

            return View();
        }


        public ActionResult ViewOrders()
        {
            return View();
        }

        public ActionResult ViewOrder(int id)
        {
            return View();
        }
    }
}