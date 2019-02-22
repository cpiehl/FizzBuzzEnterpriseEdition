﻿using FizzBuzzEnterpriseEdition.Interfaces;

namespace FizzBuzzEnterpriseEdition.Models
{
	public class BuzzStringReturner : IStringStringReturner
	{
		public BuzzStringReturner() { }

		public string GetString()
		{
			return Constants.Strings.BUZZ;
		}
	}
}