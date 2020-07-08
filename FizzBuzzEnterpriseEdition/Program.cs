using FizzBuzzEnterpriseEdition.Bindings;
using FizzBuzzEnterpriseEdition.Interfaces.Strategies;

namespace FizzBuzzEnterpriseEdition
{
	public class Program
	{
		static void Main(string[] args)
		{
			BindingKernel kernel = new BindingKernel();

			IFizzBuzzSolutionStrategy solution = (IFizzBuzzSolutionStrategy)kernel.Get<IFizzBuzzSolutionStrategy>();
			solution.Run();
		}
	}
}
