using FizzBuzzEnterpriseEdition.Repository.Interfaces;
using FizzBuzzEnterpriseEdition.Repository.Models;
using System;

namespace FizzBuzzEnterpriseEdition.Repository.Factories
{
	public class IntegerStringReturnerFactory : IIntegerStringReturnerFactory
	{
		public IIntegerStringReturner Create()
		{
			return (IIntegerStringReturner)Activator.CreateInstance(typeof(IntegerStringReturner));
		}
	}
}
