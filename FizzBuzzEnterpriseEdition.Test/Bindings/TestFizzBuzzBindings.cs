using FizzBuzzEnterpriseEdition.Bindings;
using FizzBuzzEnterpriseEdition.Repository.Factories;
using FizzBuzzEnterpriseEdition.Repository.Interfaces;
using FizzBuzzEnterpriseEdition.Repository.Models;
using FizzBuzzEnterpriseEdition.Test.Repository.Models;

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
