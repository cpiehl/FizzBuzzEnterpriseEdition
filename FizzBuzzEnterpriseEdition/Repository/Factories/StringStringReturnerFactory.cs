using FizzBuzzEnterpriseEdition.Repository.Interfaces;
using FizzBuzzEnterpriseEdition.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzEnterpriseEdition.Repository.Factories
{
	public class StringStringReturnerFactory : IStringStringReturnerFactory
	{
		public IStringStringReturner Create(string ReturnerString)
		{
			switch (ReturnerString)
			{
				case Constants.Strings.FIZZ:
					return (IStringStringReturner)Activator.CreateInstance(typeof(FizzStringReturner));
				case Constants.Strings.BUZZ:
					return (IStringStringReturner)Activator.CreateInstance(typeof(BuzzStringReturner));
				default:
					return null;
			}
		}
	}
}
