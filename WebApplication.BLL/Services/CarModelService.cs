using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BLL.DataTransferObjects;
using WebApplication.BLL.Infrastructure;
using WebApplication.BLL.Interfaces;
using WebApplication.DAL.Entities;
using WebApplication.DAL.Interfaces;

namespace WebApplication.BLL.Services
{
    public class CarModelService : ICarModelService
    {
        IUnitOfWork Db { get; set; }

        public CarModelService(IUnitOfWork unit)
        {
            Db = unit;
        }
        public void Dispose()
        {
            Db.Dispose();
        }

        public CarModelDTO GetCarModel(int? id)
        {
            if (id == null)
                throw new ValidationException("Не задан Id модели!", "");
            var model = Db.CarModels.Get(id.Value);
            if (model == null)
                throw new ValidationException("Модель с заданым Id не найдена!", "");

            var mapper = new MapperConfiguration(cg => cg.CreateMap<CarModel, CarModelDTO>()).CreateMapper();
            var modelDto = mapper.Map<CarModel, CarModelDTO>(model);
            modelDto.Manufacturer = Db.Manufacturers.Get(modelDto.ManufacturerId);
            modelDto.QualityClass = Db.QualityClasses.Get(modelDto.QualityClassId);

            return modelDto;
        }

        public IEnumerable<CarModelDTO> GetCarModels()
        {
            var models = Db.CarModels.GetAll().ToList();
            var mapper = new MapperConfiguration(cg => cg.CreateMap<CarModel, CarModelDTO>()).CreateMapper();
            var modelsDto = mapper.Map<IEnumerable<CarModel>, List<CarModelDTO>>(models);
            for (int i = 0; i < modelsDto.Count; i++)
            {
                modelsDto[i].Manufacturer = Db.Manufacturers.Get(modelsDto[i].ManufacturerId);
                modelsDto[i].QualityClass = Db.QualityClasses.Get(modelsDto[i].QualityClassId);
                modelsDto[i].Price = Db.Manufacturers.Get(modelsDto[i].ManufacturerId).Price +
                    Db.QualityClasses.Get(modelsDto[i].QualityClassId).Price;
            }

            return modelsDto;
        }
                          
        public void CreateCarModel(CarModelDTO item)
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<CarModelDTO, CarModel>()).CreateMapper();
            var model = mapper.Map<CarModelDTO, CarModel>(item);
            Db.CarModels.Create(model);
            Db.Save();
        }

        public void DelteCarModel(CarModelDTO item)
        {
            Db.CarModels.Delete(item.Id);
            Db.Save();
        }

        public void DeletCarModels(IEnumerable<CarModelDTO> items)
        {
            foreach (var it in items)
                Db.CarModels.Delete(it.Id);
            Db.Save();
        }
    }
}
