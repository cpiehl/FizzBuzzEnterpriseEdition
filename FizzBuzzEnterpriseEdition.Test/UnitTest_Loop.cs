using System;
using System.Reflection;
using FizzBuzzEnterpriseEdition.Bindings;
using FizzBuzzEnterpriseEdition.Interfaces.Strategies;
using FizzBuzzEnterpriseEdition.Test.Bindings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzEnterpriseEdition.Test
{
	[TestClass]
	public class UnitTest_Loop
	{
		[TestMethod]
		public void Test_Loop()
		{
			BindingKernel kernel = new BindingKernel(Assembly.GetExecutingAssembly());
			IFizzBuzzSolutionStrategy solution = (IFizzBuzzSolutionStrategy)kernel.Get<IFizzBuzzSolutionStrategy>();
			solution.Run();
		}
	}
}
