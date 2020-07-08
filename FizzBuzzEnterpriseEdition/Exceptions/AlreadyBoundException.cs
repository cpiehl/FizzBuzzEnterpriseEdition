using System;
using System.Runtime.Serialization;

namespace FizzBuzzEnterpriseEdition.Exceptions
{
	[Serializable]
	internal class AlreadyBoundException : Exception
	{
		public AlreadyBoundException()
		{
		}

		public AlreadyBoundException(string message) : base(message)
		{
		}

		public AlreadyBoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected AlreadyBoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}