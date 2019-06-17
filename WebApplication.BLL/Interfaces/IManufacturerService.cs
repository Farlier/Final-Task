using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BLL.DataTransferObjects;

namespace WebApplication.BLL.Interfaces
{
    public interface IManufacturerService
    {
        ManufacturerDTO GetManufacturer(int? id);
        IEnumerable<ManufacturerDTO> GetManufacturers();
        void CreateManufacturer(ManufacturerDTO item);
        void Dispose();
    }
}
