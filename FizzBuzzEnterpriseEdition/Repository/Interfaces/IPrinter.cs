using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzEnterpriseEdition.Repository.Interfaces
{
	public interface IPrinter
	{
		Action<string> Print { get; set; }
		Action<string> PrintLine { get; set; }
	}
}
