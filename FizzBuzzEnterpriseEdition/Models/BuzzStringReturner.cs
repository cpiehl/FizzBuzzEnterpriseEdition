
namespace FizzBuzzEnterpriseEdition.Models
{
	public class BuzzStringReturner : Interfaces.StringReturners.IStringStringReturner
	{
		public BuzzStringReturner() { }

		public string GetString()
		{
			return Constants.Strings.BUZZ;
		}
	}
}
