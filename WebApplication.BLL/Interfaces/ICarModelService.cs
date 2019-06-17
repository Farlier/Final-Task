using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BLL.DataTransferObjects;

namespace WebApplication.BLL.Interfaces
{
    public interface ICarModelService
    {
        CarModelDTO GetCarModel(int? id);
        IEnumerable<CarModelDTO> GetCarModels();
        void CreateCarModel(CarModelDTO item);
        void Dispose();
    }
}
