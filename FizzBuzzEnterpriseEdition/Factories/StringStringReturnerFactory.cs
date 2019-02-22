using FizzBuzzEnterpriseEdition.Interfaces.Factories;
using FizzBuzzEnterpriseEdition.Interfaces.StringReturners;
using FizzBuzzEnterpriseEdition.Models;
using System;

namespace FizzBuzzEnterpriseEdition.Factories
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
