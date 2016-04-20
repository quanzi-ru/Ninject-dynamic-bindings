using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicBinding.Core;
using Ninject.Modules;

namespace NInjectFactoryTest
{
    class TestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestInterface>().To<TestClass>();
            Bind<ITestInterface>().To<ConfigurableTestClass>().WithParameter(new DynamicBindingParameter("test", new [] { "This is injected data" }, true));
        }
    }
}
