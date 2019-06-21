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
    class QualityClassService : IQualityClassService
    {
        IUnitOfWork Db { get; set; }

        public QualityClassService(IUnitOfWork unit)
        {
            Db = unit;
        }
        public void Dispose()
        {
            Db.Dispose();
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

        public IEnumerable<QualityClassDTO> GetQualityClasses()
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<QualityClass, QualityClassDTO>()).CreateMapper();
            var qc = mapper.Map<IEnumerable<QualityClass>, List<QualityClassDTO>>(Db.QualityClasses.GetAll());
            return qc;
        }

        public void CreateQualityClass(QualityClassDTO item)
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<QualityClassDTO, QualityClass>()).CreateMapper();
            var newItem = mapper.Map<QualityClassDTO, QualityClass>(item);
            Db.QualityClasses.Create(newItem);
            Db.Save();
        }

        public void DeleteQualityClass(QualityClassDTO item)
        {
            Db.QualityClasses.Delete(item.Id);
            Db.Save();
        }
    }
}
