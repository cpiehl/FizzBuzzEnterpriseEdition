
namespace FizzBuzzEnterpriseEdition.Models
{
	public class IntegerStringReturner : Interfaces.StringReturners.IIntegerStringReturner
	{
		public string GetString(int value)
		{
			return value.ToString();
		}
	}
}
