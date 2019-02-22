
namespace FizzBuzzEnterpriseEdition.Interfaces.Factories
{
	public interface IStringStringReturnerFactory
	{
		StringReturners.IStringStringReturner Create(string ReturnerString);
	}
}
