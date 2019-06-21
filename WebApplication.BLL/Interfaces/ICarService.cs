using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BLL.DataTransferObjects;

namespace WebApplication.BLL.Interfaces
{
    public interface ICarService
    {
        CarDTO GetCar(int? id);
        IEnumerable<CarDTO> GetCars();
        IEnumerable<CarDTO> GetAvaibleCars();
        void CreateCar(CarDTO item);
        void DeleteCar(CarDTO item);
        void DeleteCars(IEnumerable<CarDTO> item);
        void Dispose();
    }
}
