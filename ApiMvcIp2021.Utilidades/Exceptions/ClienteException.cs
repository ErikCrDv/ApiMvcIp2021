using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Utilidades.Exceptions
{
	public class ClienteException : Exception
	{
		public ClienteException(string message) : base(message)
		{
		}
	}
}
