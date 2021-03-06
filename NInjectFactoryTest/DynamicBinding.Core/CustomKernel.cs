﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Ninject;
using Ninject.Activation;
using Ninject.Activation.Providers;
using Ninject.Parameters;
using Ninject.Planning;
using Ninject.Planning.Bindings;
using Ninject.Planning.Targets;
using Ninject.Selection;
using Ninject.Selection.Heuristics;

namespace DynamicBinding.Core
{
    public class CustomKernel : StandardKernel
    {
        public override IEnumerable<IBinding> GetBindings(Type service)
        {
            var existingBindings = base.GetBindings(service).ToList();

            var dynamicBindings = existingBindings.Where(b => b.Parameters.Any(p => p is DynamicBindingParameter)).ToArray();

            foreach (var binding in dynamicBindings)
            {
                var parameters = binding.Parameters.Where(p => p is DynamicBindingParameter).ToArray();
                
                if (parameters.Length > 1)
                    throw new NotImplementedException("Multiple dynamic binding parameters are not supported");

                var parameter = parameters.First();
                var customRequest = new Request(service, (m) => true, new IParameter[0], () => null, false, false);
                
                var values = parameter.GetValue(CreateContext(customRequest, binding), null) as IEnumerable<string>;

                existingBindings.AddRange(values.Select(value => CreateCustomBinding(service, binding.ProviderCallback, value)));
            }

            existingBindings.RemoveAll(b => b.Parameters.Any(p => p is DynamicBindingParameter));

            return existingBindings;
        }

        private IBinding CreateCustomBinding(Type service, Func<IContext, IProvider> providerCallback, string value)
        {
            var binding = new Binding(service);
            binding.Parameters.Add(new ConstructorArgument("input", value));
            binding.ProviderCallback = providerCallback;
            return binding;
        }
    }
}
