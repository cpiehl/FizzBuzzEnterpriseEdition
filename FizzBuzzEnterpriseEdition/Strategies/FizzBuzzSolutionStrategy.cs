using System;
using FizzBuzzEnterpriseEdition.Interfaces;
using FizzBuzzEnterpriseEdition.Interfaces.Factories;
using FizzBuzzEnterpriseEdition.Interfaces.Strategies;
using FizzBuzzEnterpriseEdition.Interfaces.StringReturners;

namespace FizzBuzzEnterpriseEdition.Strategies
{
	public class FizzBuzzSolutionStrategy : IFizzBuzzSolutionStrategy
	{
		public void Run()
		{
			Loop();

			Console.ReadKey();
		}

		public void Loop()
		{
			IPrinter printer = (IPrinter)Program.Kernel.Get<IPrinter>();
			IStringStringReturnerFactory stringStringReturnerFactory = (IStringStringReturnerFactory)Program.Kernel.Get<IStringStringReturnerFactory>();
			IIntegerStringReturnerFactory integerStringReturnerFactory = (IIntegerStringReturnerFactory)Program.Kernel.Get<IIntegerStringReturnerFactory>();

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
