using FizzBuzzEnterpriseEdition.Interfaces.Providers;

namespace FizzBuzzEnterpriseEdition.Providers
{
	public class IntegerLoopControlProvider : ILoopControlProvider<int>
	{
		public int GetStart()
		{
			return Constants.Integers.START;
		}

		public int GetEnd()
		{
			return Constants.Integers.END;
		}

		public int GetStep()
		{
			return Constants.Integers.STEP;
		}
	}
}
