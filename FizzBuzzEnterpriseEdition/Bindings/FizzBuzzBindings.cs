using FizzBuzzEnterpriseEdition.Repository.Factories;
using FizzBuzzEnterpriseEdition.Repository.Interfaces;
using FizzBuzzEnterpriseEdition.Repository.Models;

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
