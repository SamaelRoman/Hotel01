using Hotel01.BLL.Interfaces;
using Hotel01.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel01.Util
{
    public class PresentationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();
        }
    }
}