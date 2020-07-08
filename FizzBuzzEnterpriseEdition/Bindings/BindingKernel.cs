using FizzBuzzEnterpriseEdition.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FizzBuzzEnterpriseEdition.Bindings
{
	public class BindingKernel
	{
		private Dictionary<Type, Binding> bindings = new Dictionary<Type, Binding>();

		public BindingKernel() : this(Assembly.GetExecutingAssembly()) { }

		public BindingKernel(IKernelBindings binding) : this(new List<IKernelBindings> { binding }) { }

		public BindingKernel(IEnumerable<IKernelBindings> bindings)
		{
			BindDerivedTypesList(bindings.Select(b => b.GetType()));
		}

		public BindingKernel(Assembly assembly)
		{
			BindDerivedTypesList(FindDerivedTypes(assembly, typeof(IKernelBindings)));
		}

		private void BindDerivedTypesList(IEnumerable<Type> derivedTypes)
		{
			foreach (Type derivedType in derivedTypes)
			{
				((IKernelBindings)this.Get(derivedType)).Init(this);
			}
		}

		public Binding Bind<T>()
		{
			Binding b = new Binding<T>();
			if (this.bindings.ContainsKey(typeof(T)))
			{
				throw new AlreadyBoundException($"'{typeof(T)}' is already bound to this kernel.");
			}
			this.bindings.Add(typeof(T), b);
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
					throw; // Todo: don't know what to do with this yet
				}
			}
			else
				throw new ArgumentException("Argument must not be an abstract class type");
		}

		private Binding GetBindingByInterface(Type i)
		{
			return bindings.FirstOrDefault(b => b.Value.InterfaceType.FullName == i.FullName).Value;
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
