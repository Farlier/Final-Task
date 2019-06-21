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
    public class ManufacturerService : IManufacturerService
    {
        IUnitOfWork Db { get; set; }

        public ManufacturerService(IUnitOfWork unit)
        {
            Db = unit;
        }
        public void Dispose()
        {
            Db.Dispose();
        }

        public ManufacturerDTO GetManufacturer(int? id)
        {
            if (id == null)
                throw new ValidationException("Не задан Id производителя!", "");
            var mr = Db.Manufacturers.Get(id.Value);
            if (mr == null)
                throw new ValidationException("Производитель с заданым Id не найден!", "");

            var mapper = new MapperConfiguration(cg => cg.CreateMap<Manufacturer, ManufacturerDTO>()).CreateMapper();
            var mrDto = mapper.Map<Manufacturer, ManufacturerDTO>(mr);

            return mrDto;
        }

        public IEnumerable<ManufacturerDTO> GetManufacturers()
        {
            var mrs = Db.Manufacturers.GetAll().ToList();
            var mapper = new MapperConfiguration(cg => cg.CreateMap<Manufacturer, ManufacturerDTO>()).CreateMapper();
            var mrsDto = mapper.Map<IEnumerable<Manufacturer>, List<ManufacturerDTO>>(mrs);

            return mrsDto;
        }

        public void CreateManufacturer(ManufacturerDTO item)
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<ManufacturerDTO, Manufacturer>()).CreateMapper();
            var mr = mapper.Map<ManufacturerDTO, Manufacturer>(item);
            Db.Manufacturers.Create(mr);
            Db.Save();
        }

        public void DeleteManufacturer(ManufacturerDTO item)
        {
            Db.Manufacturers.Delete(item.Id);
            Db.Save();
        }
    }
}
