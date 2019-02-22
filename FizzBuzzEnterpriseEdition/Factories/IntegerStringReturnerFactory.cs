using FizzBuzzEnterpriseEdition.Interfaces.Factories;
using FizzBuzzEnterpriseEdition.Interfaces.StringReturners;
using FizzBuzzEnterpriseEdition.Models;
using System;

namespace FizzBuzzEnterpriseEdition.Factories
{
	public class IntegerStringReturnerFactory : IIntegerStringReturnerFactory
	{
		public IIntegerStringReturner Create()
		{
			return (IIntegerStringReturner)Activator.CreateInstance(typeof(IntegerStringReturner));
		}
	}
}
