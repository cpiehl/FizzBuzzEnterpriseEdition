using System.Text;
using FizzBuzzEnterpriseEdition.Bindings;
using FizzBuzzEnterpriseEdition.Interfaces;
using FizzBuzzEnterpriseEdition.Test.Bindings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzEnterpriseEdition.Test.Tests
{
	[TestClass]
	public class UnitTest_Loop
	{
		[TestMethod]
		public void Test_Loop()
		{
			BindingKernel kernel = new BindingKernel(new TestFizzBuzzBindings());

			StringBuilder stringBuilderTest = new StringBuilder();
			StringBuilder stringBuilderExpected = new StringBuilder();

			IPrinter printer = (IPrinter)kernel.Get<IPrinter>(new System.Collections.Generic.Dictionary<string, object>
			{
				{ "stringBuilder", stringBuilderTest },
			});

			ILoop loop = (ILoop)kernel.Get<ILoop>(new System.Collections.Generic.Dictionary<string, object>
			{
				{ "printer", printer },
			});

			loop.Run();

			for (int i = Constants.Integers.START; i <= Constants.Integers.END; i += Constants.Integers.STEP)
			{
				bool mod3 = i % 3 == 0;
				bool mod5 = i % 5 == 0;

				if (mod3 && mod5)
				{
					stringBuilderExpected.AppendLine(Constants.Strings.FIZZ + Constants.Strings.BUZZ);
				}
				else if (mod3)
				{
					stringBuilderExpected.AppendLine(Constants.Strings.FIZZ);
				}
				else if (mod5)
				{
					stringBuilderExpected.AppendLine(Constants.Strings.BUZZ);
				}
				else
				{
					stringBuilderExpected.AppendLine(i.ToString());
				}
			}

			string testString = stringBuilderTest.ToString();
			string expectedString = stringBuilderExpected.ToString();

			Assert.AreEqual(testString, expectedString);
		}
	}
}
