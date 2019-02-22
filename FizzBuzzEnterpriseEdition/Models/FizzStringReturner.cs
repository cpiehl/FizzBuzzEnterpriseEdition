using FizzBuzzEnterpriseEdition.Interfaces;

namespace FizzBuzzEnterpriseEdition.Models
{
	public class FizzStringReturner : IStringStringReturner
	{
		public FizzStringReturner() { }

		public string GetString()
		{
			return Constants.Strings.FIZZ;
		}
	}
}
