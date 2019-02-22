
using FizzBuzzEnterpriseEdition.Interfaces;
using FizzBuzzEnterpriseEdition.Interfaces.Factories;
using FizzBuzzEnterpriseEdition.Interfaces.StringReturners;

namespace FizzBuzzEnterpriseEdition.Models
{
	public class Loop : ILoop
	{
		private IPrinter printer;
		private IStringStringReturnerFactory stringStringReturnerFactory;
		private IIntegerStringReturnerFactory integerStringReturnerFactory;

		public Loop(
			IPrinter printer,
			IStringStringReturnerFactory stringStringReturnerFactory,
			IIntegerStringReturnerFactory integerStringReturnerFactory
			)
		{
			this.printer = printer;
			this.stringStringReturnerFactory = stringStringReturnerFactory;
			this.integerStringReturnerFactory = integerStringReturnerFactory;
		}

		public void Run()
		{
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
