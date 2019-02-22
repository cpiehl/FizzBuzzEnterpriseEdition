using FizzBuzzEnterpriseEdition.Factories;
using FizzBuzzEnterpriseEdition.Interfaces;
using FizzBuzzEnterpriseEdition.Models;

namespace FizzBuzzEnterpriseEdition.Bindings
{
	public class FizzBuzzBindings : IKernelBindings
	{
		public void Init(BindingKernel kernel)
		{
			kernel.Bind<IPrinter>().To<ConsolePrinter>();

			kernel.Bind<IStringStringReturner>().To<FizzStringReturner>();
			kernel.Bind<IIntegerStringReturner>().To<IntegerStringReturner>();

			kernel.Bind<IStringStringReturnerFactory>().To<StringStringReturnerFactory>();
			kernel.Bind<IIntegerStringReturnerFactory>().To<IntegerStringReturnerFactory>();
		}
	}
}
