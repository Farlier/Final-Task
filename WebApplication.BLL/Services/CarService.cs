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
    public class CarService : ICarService
    {
        IUnitOfWork Db { get; set; }
        public CarService(IUnitOfWork unit)
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

            var mapper = new MapperConfiguration(cg => cg.CreateMap<Car, CarDTO>()).CreateMapper();
            var carDto = mapper.Map<Car, CarDTO>(car);

            return carDto;
        }

        public IEnumerable<CarDTO> GetCars()
        {
            var cars = Db.Cars.GetAll().ToList();
            var mapper = new MapperConfiguration(cg => cg.CreateMap<Car, CarDTO>()).CreateMapper();
            var carsDto = mapper.Map<IEnumerable<Car>, List<CarDTO>>(cars);

            return carsDto;
        }

        public IEnumerable<CarDTO> GetAvaibleCars()
        { 
            var cars = Db.Cars.GetAll().Except(Db.CarsInUse.GetAll().ToList());
            var mapper = new MapperConfiguration(cg => cg.CreateMap<Car, CarDTO>()).CreateMapper();
            var carsDto = mapper.Map<IEnumerable<Car>, List<CarDTO>>(cars);

            return carsDto;
        }

        public void CreateCar(CarDTO item)
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<CarDTO, Car>()).CreateMapper();
            var car = mapper.Map<CarDTO, Car>(item);
            Db.Cars.Create(car);
            Db.Save();
        }

        public QualityClassDTO GetQualityClass(int? id)
        {
            if (id != null)
            {
                var mapper = new MapperConfiguration(cg => cg.CreateMap<QualityClass, QualityClassDTO>()).CreateMapper();
                var qc = mapper.Map<QualityClass, QualityClassDTO>(Db.QualityClasses.Get(id.Value));
                return qc;
            }
            else
                throw new ValidationException("Класса качества с таким ID нет!", "");
        }

        public IEnumerable<QualityClassDTO> GetQualityClassDTOs()
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<QualityClass, QualityClassDTO>()).CreateMapper();
            var qc = mapper.Map<IEnumerable<QualityClass>, List<QualityClassDTO>>(Db.QualityClasses.GetAll());
            return qc;
        }

        public void DeleteCar(CarDTO item)
        {
            Db.Cars.Delete(item.Id);
            Db.Save();
        }

        public void DeleteCars(IEnumerable<CarDTO> item)
        {
            foreach (var it in item)
                Db.Cars.Delete(it.Id);
            Db.Save();
        }
    }
}
