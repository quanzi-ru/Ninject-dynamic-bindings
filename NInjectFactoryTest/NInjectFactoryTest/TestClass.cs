using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NInjectFactoryTest
{
    class TestClass : ITestInterface
    {
        protected virtual string data => "This is nonconfigurable class";

        public string Data => data;
    }
}
