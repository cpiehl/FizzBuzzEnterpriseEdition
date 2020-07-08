using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzEnterpriseEdition.Interfaces.Strategies;

namespace FizzBuzzEnterpriseEdition.Strategies
{
	public class IntegerEvenlyDivisibleStrategy : IEvenlyDivisibleStrategy<int>
	{
		public bool Test(int a, int b)
		{
			return a % b == 0;
		}
	}
}
