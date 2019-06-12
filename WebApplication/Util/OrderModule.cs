using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.BLL.Interfaces;
using WebApplication.BLL.Services;

namespace WebApplication.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}