﻿using System;
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
			BindingKernel kernel = new BindingKernel(new TestFizzBuzzBindings());
			IFizzBuzzSolutionStrategy solution = (IFizzBuzzSolutionStrategy)Program.Kernel.Get<IFizzBuzzSolutionStrategy>();
			solution.Run();
		}
	}
}
