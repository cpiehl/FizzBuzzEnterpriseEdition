using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzEnterpriseEdition.Repository.Interfaces
{
	public interface IIntegerStringReturnerFactory
	{ 
		IIntegerStringReturner Create();
	}
}
