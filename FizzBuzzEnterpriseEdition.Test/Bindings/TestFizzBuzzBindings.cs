using FizzBuzzEnterpriseEdition.Bindings;
using FizzBuzzEnterpriseEdition.Factories;
using FizzBuzzEnterpriseEdition.Interfaces;
using FizzBuzzEnterpriseEdition.Interfaces.Factories;
using FizzBuzzEnterpriseEdition.Interfaces.Providers;
using FizzBuzzEnterpriseEdition.Interfaces.Strategies;
using FizzBuzzEnterpriseEdition.Models;
using FizzBuzzEnterpriseEdition.Providers;
using FizzBuzzEnterpriseEdition.Strategies;
using FizzBuzzEnterpriseEdition.Test.Models;
using FizzBuzzEnterpriseEdition.Test.Strategies;

namespace FizzBuzzEnterpriseEdition.Test.Bindings
{
	public class TestFizzBuzzBindings : IKernelBindings
	{
		public void Init(BindingKernel kernel)
		{
			kernel.Bind<IFizzBuzzSolutionStrategy>().To<TestFizzBuzzSolutionStrategy>();

			kernel.Bind<IPrinter>().To<MemoryPrinter>();

			kernel.Bind<ILoop>().To<Loop>();
			kernel.Bind<ILoopControlProvider<int>>().To<IntegerLoopControlProvider>();

			kernel.Bind<IStringStringReturnerFactory>().To<StringStringReturnerFactory>();
			kernel.Bind<IIntegerStringReturnerFactory>().To<IntegerStringReturnerFactory>();

			kernel.Bind<IEvenlyDivisibleStrategy<int>>().To<IntegerEvenlyDivisibleStrategy>();
		}
	}
}
