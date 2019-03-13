using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FizzBuzzEnterpriseEdition.Bindings
{
	public class BindingKernel
	{
		// Todo: make this a hashset, catch duplicate key exception and rethrow our own "already bound" exception
		private List<Binding> bindings = new List<Binding>();

		public BindingKernel() { }


		public BindingKernel(IKernelBindings binding) : this(new List<IKernelBindings> { binding }) { }

		public BindingKernel(IEnumerable<IKernelBindings> bindings)
		{
			BindList(bindings.Select(b => b.GetType()));
		}

		public BindingKernel(Assembly assembly)
		{
			BindList(FindDerivedTypes(assembly, typeof(IKernelBindings)));
		}

		private void BindList(IEnumerable<Type> bindings)
		{
			bindings.ToList().ForEach(t => ((IKernelBindings)this.Get(t)).Init(this));
		}

		public Binding Bind<T>()
		{
			Binding b = new Binding<T>();
			this.bindings.Add(b);
			return b;
		}

		public object Get<T>()
		{
			return Get(typeof(T));
		}

		private object Get(Type i)
		{
			if (i.IsInterface)
			{
				Type t = GetBindingByInterface(i).ImplementationType;
				return this.Get(t);
			}
			else if (i.IsClass)
			{
				ConstructorInfo defaultConstructorInfo = null;
				ConstructorInfo[] constructors = i.GetConstructors();
				foreach (ConstructorInfo ci in constructors)
				{
					ParameterInfo[] parameters = ci.GetParameters();

					if (parameters.Length == 0)
					{
						defaultConstructorInfo = ci;
						continue;
					}

					if (parameters.All(p => GetBindingByInterface(p.ParameterType) != null))
					{
						return ci.Invoke(parameters.Select(p => this.Get(p.ParameterType)).ToArray());
					}
				}
				try
				{
					return defaultConstructorInfo.Invoke(new object[] { });
				}
				catch (Exception ex)
				{
					throw ex; // Todo: don't know what to do with this yet
				}
			}
			else
				throw new ArgumentException("Argument must not be an abstract class type");
		}

		private Binding GetBindingByInterface(Type i)
		{
			return bindings.FirstOrDefault(b => b.InterfaceType.FullName == i.FullName);
		}

		private static IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
		{
			return assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t));
		}

		//private bool CanInstanciate(Type t)
		//{
		//	return Activator.
		//}
	}
}
