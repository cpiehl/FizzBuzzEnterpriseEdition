using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzEnterpriseEdition.Interfaces.Strategies
{
	public interface IEvenlyDivisibleStrategy<T>
	{
		bool Test(T a, T b);
	}
}
