using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzEnterpriseEdition.Models
{
	public class IntegerStringReturner : Interfaces.IIntegerStringReturner
	{
		public string GetString(int value)
		{
			return value.ToString();
		}
	}
}
