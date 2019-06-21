using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BLL.Interfaces;
using WebApplication.BLL.Services;
using WebApplication.DAL.Interfaces;
using WebApplication.DAL.Repositories;

namespace WebApplication.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string conectionString;
        public ServiceModule(string connection)
        {
            conectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(conectionString);
            Bind<IOrderService>().To<OrderService>().WithConstructorArgument(conectionString);
            Bind<ICarService>().To<CarService>().WithConstructorArgument(conectionString);
            Bind<ICarModelService>().To<CarModelService>().WithConstructorArgument(conectionString);
            Bind<IManufacturerService>().To<ManufacturerService>().WithConstructorArgument(conectionString);
            Bind<IQualityClassService>().To<QualityClassService>().WithConstructorArgument(conectionString);
            Bind<IRentalCenterService>().To<RentalCenterService>().WithConstructorArgument(conectionString);
        }
    }
}
