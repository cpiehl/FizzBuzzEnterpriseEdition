using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzEnterpriseEdition.Bindings;
using FizzBuzzEnterpriseEdition.Repository.Interfaces;

namespace FizzBuzzEnterpriseEdition
{
	public class Program
	{
		static void Main(string[] args)
		{
			BindingKernel kernel = new BindingKernel(new FizzBuzzBindings());
			Loop(kernel);

			Console.ReadKey();
		}

		public static void Loop(BindingKernel kernel)
		{
			IPrinter printer = (IPrinter)kernel.Get<IPrinter>();
			IStringStringReturnerFactory stringStringReturnerFactory = (IStringStringReturnerFactory)kernel.Get<IStringStringReturnerFactory>();
			IIntegerStringReturnerFactory integerStringReturnerFactory = (IIntegerStringReturnerFactory)kernel.Get<IIntegerStringReturnerFactory>();

			for (int i = 1; i <= 100; i++)
			{
				bool mod3 = i % 3 == 0;
				bool mod5 = i % 5 == 0;

				if (mod3 && mod5)
				{
					IStringStringReturner fizzStringReturner = stringStringReturnerFactory.Create(Repository.Constants.Strings.FIZZ);
					IStringStringReturner buzzStringReturner = stringStringReturnerFactory.Create(Repository.Constants.Strings.BUZZ);
					printer.Print(fizzStringReturner.GetString());
					printer.PrintLine(buzzStringReturner.GetString());
				}
				else if (mod3)
				{
					IStringStringReturner fizzStringReturner = stringStringReturnerFactory.Create(Repository.Constants.Strings.FIZZ);
					printer.PrintLine(fizzStringReturner.GetString());
				}
				else if (mod5)
				{
					IStringStringReturner buzzStringReturner = stringStringReturnerFactory.Create(Repository.Constants.Strings.BUZZ);
					printer.PrintLine(buzzStringReturner.GetString());
				}
				else
				{
					Console.WriteLine(i);
				}
			}
		}
	}
}
