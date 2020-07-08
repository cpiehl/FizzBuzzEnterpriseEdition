
using FizzBuzzEnterpriseEdition.Interfaces.Factories;

namespace FizzBuzzEnterpriseEdition.Interfaces
{
	public interface ILoop
	{
		int Index { get; }
		void Run();
		void Step();
		void Reset();
	}
}
