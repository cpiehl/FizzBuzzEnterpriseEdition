using FizzBuzzEnterpriseEdition.Interfaces;
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
