
namespace FizzBuzzEnterpriseEdition.Interfaces.Providers
{
	public interface ILoopControlProvider<T>
	{
		T GetStart();
		T GetEnd();
		T GetStep();
	}
}
