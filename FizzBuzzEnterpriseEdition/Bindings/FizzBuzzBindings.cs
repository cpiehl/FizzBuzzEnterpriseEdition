using FizzBuzzEnterpriseEdition.Factories;
using FizzBuzzEnterpriseEdition.Interfaces;
using FizzBuzzEnterpriseEdition.Interfaces.Factories;
using FizzBuzzEnterpriseEdition.Interfaces.Strategies;
using FizzBuzzEnterpriseEdition.Interfaces.StringReturners;
using FizzBuzzEnterpriseEdition.Models;
using FizzBuzzEnterpriseEdition.Strategies;

namespace FizzBuzzEnterpriseEdition.Bindings
{
	public class FizzBuzzBindings : IKernelBindings
	{
		public void Init(BindingKernel kernel)
		{
			kernel.Bind<IFizzBuzzSolutionStrategy>().To<FizzBuzzSolutionStrategy>();

			kernel.Bind<IPrinter>().To<ConsolePrinter>();

			kernel.Bind<ILoop>().To<Loop>();

			kernel.Bind<IStringStringReturner>().To<FizzStringReturner>();
			kernel.Bind<IIntegerStringReturner>().To<IntegerStringReturner>();

			kernel.Bind<IStringStringReturnerFactory>().To<StringStringReturnerFactory>();
			kernel.Bind<IIntegerStringReturnerFactory>().To<IntegerStringReturnerFactory>();

			kernel.Bind<IEvenlyDivisibleStrategy<int>>().To<IntegerEvenlyDivisibleStrategy>();
		}
	}
}
