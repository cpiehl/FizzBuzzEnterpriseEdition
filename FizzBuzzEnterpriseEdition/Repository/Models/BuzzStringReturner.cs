using FizzBuzzEnterpriseEdition.Repository.Interfaces;

namespace FizzBuzzEnterpriseEdition.Repository.Models
{
	public class BuzzStringReturner : IStringStringReturner
	{
		public BuzzStringReturner() { }

		public string GetString()
		{
			return Constants.Strings.BUZZ;
		}
	}
}
