using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BLL.DataTransferObjects;
using WebApplication.DAL.Entities;

namespace WebApplication.BLL.Interfaces
{
    interface IServiceIfrastructure
    {
        void AddService(ServiceEntityDTO serv);
        void DeleteService(int id);
        ServiceEntityDTO GetService(int? id);
        IEnumerable<ServiceEntityDTO> GetServices();
    }
}
