using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BLL.DataTransferObjects;
using WebApplication.BLL.Interfaces;
using WebApplication.DAL.Entities;
using WebApplication.DAL.Interfaces;

namespace WebApplication.BLL.Services
{
  

    class ServiceInfrastructure : IServiceIfrastructure
    {
        IUnitOfWork Db { get; set; }
        public ServiceInfrastructure(IUnitOfWork unit)
        {
            Db = unit;
        }
        public void Dispose()
        {
            Db.Dispose();
        }
        public void AddService(ServiceEntityDTO serv)
        {
            Db.Services.Create(serv);
            Db.Save();
        }

        public void DeleteService(int id)
        {
            Db.Services.Delete(id);
            Db.Save();
        }

        public ServiceEntityDTO GetService(int? id)
        {
            var mapper = new AutoMapper.MapperConfiguration(cg => cg.CreateMap<ServiceEntity, ServiceEntityDTO>()).CreateMapper();
            var serv = mapper.Map<ServiceEntity, ServiceEntityDTO>(Db.Services.Get(id.Value));
            return serv;
        }

        public IEnumerable<ServiceEntityDTO> GetServices()
        {
            var mapper = new AutoMapper.MapperConfiguration(cg => cg.CreateMap<ServiceEntity, ServiceEntityDTO>()).CreateMapper();
            var serv = mapper.Map<List<ServiceEntity>,IEnumerable< ServiceEntityDTO>>(Db.Services.GetAll().ToList());
            return serv;
        }
    }
}
