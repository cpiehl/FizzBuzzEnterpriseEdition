using System;
using FizzBuzzEnterpriseEdition.Bindings;
using FizzBuzzEnterpriseEdition.Interfaces;
using FizzBuzzEnterpriseEdition.Interfaces.Factories;
using FizzBuzzEnterpriseEdition.Interfaces.StringReturners;

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

			for (int i = Constants.Integers.START; i <= Constants.Integers.END; i += Constants.Integers.INCREMENT)
			{
				bool mod3 = i % Constants.Integers.FIZZ_DIVISOR == 0;
				bool mod5 = i % Constants.Integers.BUZZ_DIVISOR == 0;

				if (mod3 && mod5)
				{
					IStringStringReturner fizzStringReturner = stringStringReturnerFactory.Create(Constants.Strings.FIZZ);
					IStringStringReturner buzzStringReturner = stringStringReturnerFactory.Create(Constants.Strings.BUZZ);
					printer.Print(fizzStringReturner.GetString());
					printer.PrintLine(buzzStringReturner.GetString());
				}
				else if (mod3)
				{
					IStringStringReturner fizzStringReturner = stringStringReturnerFactory.Create(Constants.Strings.FIZZ);
					printer.PrintLine(fizzStringReturner.GetString());
				}
				else if (mod5)
				{
					IStringStringReturner buzzStringReturner = stringStringReturnerFactory.Create(Constants.Strings.BUZZ);
					printer.PrintLine(buzzStringReturner.GetString());
				}
				else
				{
					IIntegerStringReturner integerStringReturner = integerStringReturnerFactory.Create();
					printer.PrintLine(integerStringReturner.GetString(i));
				}
			}
		}
	}
}
