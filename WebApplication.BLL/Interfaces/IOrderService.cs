using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BLL.DataTransferObjects;

namespace WebApplication.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        CarDTO GetCar(int? id);
        IEnumerable<CarDTO> GetCars();
        IEnumerable<CarDTO> GetAvaibleCars(); 
        void Dispose();
    }
}
