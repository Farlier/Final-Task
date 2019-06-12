using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DAL.Interfaces;
using WebApplication.DAL.Repositories;

namespace WebApplication.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string conectionString;
        public ServiceModule(string connection)
        {
            conectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(conectionString);
        }
    }
}
