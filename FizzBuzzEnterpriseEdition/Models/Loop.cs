
using FizzBuzzEnterpriseEdition.Interfaces;
using FizzBuzzEnterpriseEdition.Interfaces.Factories;
using FizzBuzzEnterpriseEdition.Interfaces.Strategies;
using FizzBuzzEnterpriseEdition.Interfaces.StringReturners;

namespace FizzBuzzEnterpriseEdition.Models
{
	public class Loop : ILoop
	{
		public int Index { get; private set; }

		private IPrinter printer;
		private IStringStringReturnerFactory stringStringReturnerFactory;
		private IIntegerStringReturnerFactory integerStringReturnerFactory;
		private IEvenlyDivisibleStrategy<int> evenlyDivisibleStrategy;

		public Loop(
			IPrinter printer,
			IStringStringReturnerFactory stringStringReturnerFactory,
			IIntegerStringReturnerFactory integerStringReturnerFactory,
			IEvenlyDivisibleStrategy<int> evenlyDivisibleStrategy
			)
		{
			this.printer = printer;
			this.stringStringReturnerFactory = stringStringReturnerFactory;
			this.integerStringReturnerFactory = integerStringReturnerFactory;
			this.evenlyDivisibleStrategy = evenlyDivisibleStrategy;

			this.Reset();
		}

		public void Run()
		{
			while (this.Index <= Constants.Integers.END)
			{
				Step();
			}
		}

		public void Step()
		{
			bool testFizz = evenlyDivisibleStrategy.Test(this.Index, Constants.Integers.FIZZ_DIVISOR);
			bool testBuzz = evenlyDivisibleStrategy.Test(this.Index, Constants.Integers.BUZZ_DIVISOR);

			if (testFizz && testBuzz)
			{
				IStringStringReturner fizzStringReturner = stringStringReturnerFactory.Create(Constants.Strings.FIZZ);
				IStringStringReturner buzzStringReturner = stringStringReturnerFactory.Create(Constants.Strings.BUZZ);
				printer.Print(fizzStringReturner.GetString());
				printer.PrintLine(buzzStringReturner.GetString());
			}
			else if (testFizz)
			{
				IStringStringReturner fizzStringReturner = stringStringReturnerFactory.Create(Constants.Strings.FIZZ);
				printer.PrintLine(fizzStringReturner.GetString());
			}
			else if (testBuzz)
			{
				IStringStringReturner buzzStringReturner = stringStringReturnerFactory.Create(Constants.Strings.BUZZ);
				printer.PrintLine(buzzStringReturner.GetString());
			}
			else
			{
				IIntegerStringReturner integerStringReturner = integerStringReturnerFactory.Create();
				printer.PrintLine(integerStringReturner.GetString(this.Index));
			}

			this.Index += Constants.Integers.INCREMENT;
		}

		public void Reset()
		{
			this.Index = Constants.Integers.START;
		}
	}
}
