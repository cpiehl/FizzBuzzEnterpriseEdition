
using FizzBuzzEnterpriseEdition.Interfaces.Factories;

namespace FizzBuzzEnterpriseEdition.Interfaces
{
	public interface ILoop
	{
		/// <summary>
		/// Current Loop index.
		/// </summary>
		int Index { get; }

		/// <summary>
		/// Run from current Index to the end.
		/// </summary>
		void Run();

		/// <summary>
		/// Perform one step of the loop.
		/// </summary>
		void Step();

		/// <summary>
		/// Reset loop to start.
		/// </summary>
		void Reset();
	}
}
