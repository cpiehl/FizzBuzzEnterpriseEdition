using FizzBuzzEnterpriseEdition.Bindings;
using FizzBuzzEnterpriseEdition.Interfaces.Strategies;

namespace FizzBuzzEnterpriseEdition
{
	public class Program
	{
		public static BindingKernel Kernel;

		static void Main(string[] args)
		{
			Program.Kernel = new BindingKernel(new FizzBuzzBindings());

			IFizzBuzzSolutionStrategy solution = (IFizzBuzzSolutionStrategy)Program.Kernel.Get<IFizzBuzzSolutionStrategy>();
			solution.Run();
		}
	}
}
