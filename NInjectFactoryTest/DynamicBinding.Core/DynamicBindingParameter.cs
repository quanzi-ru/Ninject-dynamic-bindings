using System;
using System.Diagnostics;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Planning.Targets;

namespace DynamicBinding.Core
{
    public class DynamicBindingParameter : Parameter
    {
        public DynamicBindingParameter(string name, object values, bool shouldInherit) : base(name, values, shouldInherit)
        {
            Debug.Assert(values.GetType().IsArray, "Values should be an array of input strings");
            Debug.Assert(values.GetType().GetElementType() == typeof(string), "Values should be an array of input strings");
        }

        public DynamicBindingParameter(string name, Func<IContext, object> valueCallback, bool shouldInherit) : base(name, valueCallback, shouldInherit)
        {
            throw new NotImplementedException("Additional constructors not supported");
        }

        public DynamicBindingParameter(string name, Func<IContext, ITarget, object> valueCallback, bool shouldInherit) : base(name, valueCallback, shouldInherit)
        {
            throw new NotImplementedException("Additional constructors not supported");
        }
    }
}
