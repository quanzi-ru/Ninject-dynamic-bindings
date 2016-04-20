using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DynamicBinding.Core;
using Ninject;

namespace NInjectFactoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new CustomKernel();
            kernel.Load<TestModule>();

            var testClasses = kernel.GetAll<ITestInterface>();

            foreach (var c in testClasses)
            {
                Console.WriteLine(c.Data);
            }
            Console.Read();
        }
    }
}
