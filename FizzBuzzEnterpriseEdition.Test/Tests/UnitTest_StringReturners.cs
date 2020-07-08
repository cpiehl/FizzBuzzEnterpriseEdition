using System;
using FizzBuzzEnterpriseEdition.Bindings;
using FizzBuzzEnterpriseEdition.Interfaces.Factories;
using FizzBuzzEnterpriseEdition.Interfaces.StringReturners;
using FizzBuzzEnterpriseEdition.Test.Bindings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzEnterpriseEdition.Test.Tests
{
	[TestClass]
	public class UnitTest_StringReturners
	{
		[TestMethod]
		public void Test_FizzStringReturner()
		{
			BindingKernel kernel = new BindingKernel(new TestFizzBuzzBindings());

			IStringStringReturnerFactory stringStringReturnerFactory = (IStringStringReturnerFactory)kernel.Get<IStringStringReturnerFactory>();
			IStringStringReturner fizzStringReturner = stringStringReturnerFactory.Create(Constants.Strings.FIZZ);

			Assert.AreEqual(fizzStringReturner.GetString(), Constants.Strings.FIZZ);
		}

		[TestMethod]
		public void Test_BuzzStringReturner()
		{
			BindingKernel kernel = new BindingKernel(new TestFizzBuzzBindings());

			IStringStringReturnerFactory stringStringReturnerFactory = (IStringStringReturnerFactory)kernel.Get<IStringStringReturnerFactory>();
			IStringStringReturner buzzStringReturner = stringStringReturnerFactory.Create(Constants.Strings.BUZZ);

			Assert.AreEqual(buzzStringReturner.GetString(), Constants.Strings.BUZZ);
		}
	}
}
