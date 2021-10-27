using Hotel01.DAL.Interfaces;
using Hotel01.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel01.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private  string ConnectionString;
        public ServiceModule(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(ConnectionString);
        }
    }
}
