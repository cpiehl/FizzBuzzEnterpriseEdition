using FizzBuzzEnterpriseEdition.Interfaces;
using System;
using System.Text;

namespace FizzBuzzEnterpriseEdition.Test.Models
{
	public class MemoryPrinter : IPrinter
	{
		private readonly StringBuilder stringBuilder;

		public Action<string> Print { get; set; } 
		public Action<string> PrintLine { get; set; }

		public MemoryPrinter(
			StringBuilder stringBuilder
			)
		{
			this.stringBuilder = stringBuilder;

			Print = new Action<string>((text) => this.stringBuilder.Append(text));
			PrintLine = new Action<string>((text) => this.stringBuilder.AppendLine(text));
		}
	}
}
