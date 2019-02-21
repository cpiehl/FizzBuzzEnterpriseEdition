using FizzBuzzEnterpriseEdition.Repository.Interfaces;

namespace FizzBuzzEnterpriseEdition.Repository.Models
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
