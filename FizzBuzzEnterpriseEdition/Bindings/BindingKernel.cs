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

		/// <summary>
		/// Default. Bind all IKernelBindings found in executing assembly.
		/// </summary>
		public BindingKernel() : this(Assembly.GetExecutingAssembly()) { }

		/// <summary>
		/// Bind this single IKernelBindings to kernel.
		/// </summary>
		/// <param name="kernelBinding">IKernelBindings to bind to kernel.</param>
		public BindingKernel(IKernelBindings kernelBinding) : this(new List<IKernelBindings> { kernelBinding }) { }

		/// <summary>
		/// Bind all bindings in list of IKernelBindings.
		/// </summary>
		/// <param name="kernelBindings">List of IKernelBindings to bind to kernel.</param>
		public BindingKernel(IEnumerable<IKernelBindings> kernelBindings)
		{
			BindBindingsList(kernelBindings.Select(b => b.GetType()));
		}

		/// <summary>
		/// Bind all types configured in all objects implementing IKernelBindings found in Assembly to this BindingKernel.
		/// </summary>
		/// <param name="assembly">Assembly to search for IKernelBindings implementations.</param>
		public BindingKernel(Assembly assembly)
		{
			BindBindingsList(FindDerivedTypes(assembly, typeof(IKernelBindings)));
		}

		/// <summary>
		/// Bind all types configured in all objects implementing IKernelBindings found in input list to this BindingKernel.
		/// </summary>
		/// <param name="bindings">List of Types implementing IKernelBindings.</param>
		private void BindBindingsList(IEnumerable<Type> bindings)
		{
			foreach (Type binding in bindings)
			{
				((IKernelBindings)this.Get(binding)).Init(this);
			}
		}

		/// <summary>
		/// Start binding interface type T to this BindingKernel. Finish binding with Binding.To().
		/// </summary>
		/// <typeparam name="T">Interface Type to start binding.</typeparam>
		/// <returns>Binding object to be used with Binding.To()</returns>
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

		/// <summary>
		/// Create and return an instance of type T.
		/// </summary>
		/// <typeparam name="T">Type to create.</typeparam>
		/// <returns>New instance of type T.</returns>
		public object Get<T>()
		{
			return Get(typeof(T));
		}

		/// <summary>
		/// Create and return an instance of type t.
		/// </summary>
		/// <param name="t">Type to create.</param>
		/// <returns>New instance of type t.</returns>
		private object Get(Type t)
		{
			if (t.IsInterface)
			{
				return this.Get(GetBindingByInterface(t).ImplementationType);
			}
			else if (t.IsClass)
			{
				ConstructorInfo defaultConstructorInfo = null;
				ConstructorInfo[] constructors = t.GetConstructors();
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

		/// <summary>
		/// Get Binding object that was bound to interface type.
		/// </summary>
		/// <param name="i">Interface type to search for.</param>
		/// <returns>Binding object that was bound to interface type.</returns>
		private Binding GetBindingByInterface(Type i)
		{
			return bindings.ContainsKey(i) ? bindings[i] : null;
		}

		/// <summary>
		/// Find all types derived from base type found in assembly.
		/// </summary>
		/// <param name="assembly">Assembly to search in.</param>
		/// <param name="baseType">Base Type to search for.</param>
		/// <returns>List of Types derived from base type found in assembly.</returns>
		private static IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
		{
			return assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t));
		}
	}
}
