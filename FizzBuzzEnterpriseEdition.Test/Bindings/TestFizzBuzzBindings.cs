using FizzBuzzEnterpriseEdition.Bindings;
using FizzBuzzEnterpriseEdition.Factories;
using FizzBuzzEnterpriseEdition.Interfaces;
using FizzBuzzEnterpriseEdition.Models;
using FizzBuzzEnterpriseEdition.Test.Models;

namespace FizzBuzzEnterpriseEdition.Test.Bindings
{
	public class TestFizzBuzzBindings : IKernelBindings
	{
		public void Init(BindingKernel kernel)
		{
			kernel.Bind<IPrinter>().To<MemoryPrinter>();

			kernel.Bind<IStringStringReturner>().To<FizzStringReturner>();
			kernel.Bind<IIntegerStringReturner>().To<IntegerStringReturner>();

			kernel.Bind<IStringStringReturnerFactory>().To<StringStringReturnerFactory>();
			kernel.Bind<IIntegerStringReturnerFactory>().To<IntegerStringReturnerFactory>();
		}
	}
}
