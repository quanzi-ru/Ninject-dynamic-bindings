using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NInjectFactoryTest
{
    class ConfigurableTestClass : TestClass
    {
        protected override string data { get; }

        public ConfigurableTestClass(string input)
        {
            data = input;
        }

    }
}
