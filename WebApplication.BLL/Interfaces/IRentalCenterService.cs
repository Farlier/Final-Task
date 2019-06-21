using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BLL.DataTransferObjects;
namespace WebApplication.BLL.Interfaces
{
    public interface IRentalCenterService
    {
        void AddRentalCenter();
        void DeleteRentalCenter();
        RentalCenterDTO GetRentalCenter(int? id);
        IEnumerable<RentalCenterDTO> GetRentalCenters();
    }
}
