using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BLL.DataTransferObjects;

namespace WebApplication.BLL.Interfaces
{
    public interface IQualityClassService
    {
        QualityClassDTO GetQualityClass(int? id);
        IEnumerable<QualityClassDTO> GetQualityClasses();
        void CreateQualityClass(QualityClassDTO item);
        void DeleteQualityClass(QualityClassDTO item);
        void Dispose();
    }
}
