using FizzBuzzEnterpriseEdition.Interfaces;
using System;

namespace FizzBuzzEnterpriseEdition.Models
{
	public class ConsolePrinter : IPrinter
	{
		public Action<string> Print { get; set; } 
		public Action<string> PrintLine { get; set; }

		public ConsolePrinter()
		{
			Print = new Action<string>((text) => Console.Write(text));
			PrintLine = new Action<string>((text) => Console.WriteLine(text));
		}
	}
}
