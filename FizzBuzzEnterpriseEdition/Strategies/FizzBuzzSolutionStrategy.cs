using System;
using FizzBuzzEnterpriseEdition.Interfaces;
using FizzBuzzEnterpriseEdition.Interfaces.Strategies;

namespace FizzBuzzEnterpriseEdition.Strategies
{
	public class FizzBuzzSolutionStrategy : IFizzBuzzSolutionStrategy
	{
		private ILoop loop;

		public FizzBuzzSolutionStrategy(ILoop loop)
		{
			this.loop = loop;
		}

		public void Run()
		{
			loop.Run();

			Console.ReadKey();
		}

		
	}
}
