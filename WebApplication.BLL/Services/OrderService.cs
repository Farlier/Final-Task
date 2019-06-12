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

        public CarDTO GetCar(int? id)
        {
            if (id == null)
                throw new ValidationException("Не задан Id автомобиля!", "");
            var car = Db.Cars.Get(id.Value);
            if (car == null)
                throw new ValidationException("Автомобиль с заданым Id не найден!", "");
            return GetCarDTO(id.Value);
        }

        public IEnumerable<CarDTO> GetCars()
        {
            var cars = Db.Cars.GetAll().ToList();
            var carsDTO = new List<CarDTO>();
            foreach(var item in cars)
            {
                carsDTO.Add(GetCarDTO(item.Id));
            }
            return carsDTO;
        }

        public void MakeOrder(OrderDTO orderDto)
        {
            var car = Db.Cars.Get(orderDto.CarId);
            if(car==null)
                throw new ValidationException("Автомобиль с заданым Id не найден!", "");

            var model = Db.CarModels.Get(car.CarModelId);
            var properties = Db.ModelProperties.Get(car.CarModelId);
            var manufacturer = Db.Manufacturers.Get(model.ManufacturerId);
            var qualityclass = Db.QualityClasses.Get(properties.QualityClassId);
            var pricecalc = new PriceCalculator(manufacturer, qualityclass);

            decimal price = pricecalc.GetPrice();
            if (orderDto.WithDriver)
                price += 10;
            Order order = new Order
            {
                CarId = car.Id,
                Sum = price,
                UserId = orderDto.UserId,
                WithDriver = orderDto.WithDriver
            };
            Db.Orders.Create(order);
            Db.Save();
        }

        public IEnumerable<CarDTO> GetAvaibleCars()
        {
            var cars = Db.Cars.GetAll().Where(it=>it.AvaibleNow==true).ToList();
            var carsDTO = new List<CarDTO>();
            foreach (var item in cars)
            {
                carsDTO.Add(GetCarDTO(item.Id));
            }
            return carsDTO;
        }

        private CarDTO GetCarDTO(int carId)
        {
            var car = Db.Cars.Get(carId);
            var model = Db.CarModels.Get(car.CarModelId);         
            var properties = Db.ModelProperties.Get(car.CarModelId);
            var manufacturer = Db.Manufacturers.Get(model.ManufacturerId);
            var qualityclass = Db.QualityClasses.Get(properties.QualityClassId);
            var pricecalc = new PriceCalculator(manufacturer, qualityclass);

            return new CarDTO
            {
                Id = car.Id,
                AirConditioning = properties.AirConditioning,
                Avaible = car.AvaibleNow,
                DoorCount = properties.DoorCount,
                GearBox = properties.GearBox,
                Manufacturer = manufacturer.Name,
                Model = model.Name,
                PassengerCount = properties.PassengerCount,
                Price = pricecalc.GetPrice(),
                QualityClass = qualityclass.Name,
                Year = model.Year
            };
        }
    }
}
