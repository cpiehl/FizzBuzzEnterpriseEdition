using FizzBuzzEnterpriseEdition.Interfaces;
using FizzBuzzEnterpriseEdition.Interfaces.Strategies;
using System;

namespace FizzBuzzEnterpriseEdition.Test.Strategies
{
	class TestFizzBuzzSolutionStrategy : IFizzBuzzSolutionStrategy
	{
		private ILoop loop;

		public TestFizzBuzzSolutionStrategy(ILoop loop)
		{
			this.loop = loop;
		}

		public void Run()
		{
			loop.Run();
		}
	}
}
