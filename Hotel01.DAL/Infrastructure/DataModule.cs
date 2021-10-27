using Hotel01.DAL.Interfaces;
using Hotel01.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel01.DAL.Infrastructure
{
    class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookingInfoRepository>().To<BookingInfoRepository>();
            Bind<ICategoryInfoRepository>().To<CategoryInfoRepository>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            Bind<IRoomImageRepository>().To<RoomImageRepository>();
            Bind<IRoomRepository>().To<RoomRepository>();
            Bind<IServiceRepository>().To<ServiceRepository>();
        }
    }
}
