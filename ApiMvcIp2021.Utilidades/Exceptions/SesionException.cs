using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Utilidades.Exceptions
{
	public class SesionException : Exception
	{
		public SesionException(string message) : base(message)
		{
		}
	}
}
