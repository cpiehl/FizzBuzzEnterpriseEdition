using FizzBuzzEnterpriseEdition.Repository.Interfaces;
using System;

namespace FizzBuzzEnterpriseEdition.Test.Repository.Models
{
	public class MemoryPrinter : IPrinter
	{
		public Action<string> Print { get; set; } 
		public Action<string> PrintLine { get; set; }

		public MemoryPrinter()
		{
			Print = new Action<string>((text) => Console.Write(text));
			PrintLine = new Action<string>((text) => Console.WriteLine(text));
		}
	}
}
