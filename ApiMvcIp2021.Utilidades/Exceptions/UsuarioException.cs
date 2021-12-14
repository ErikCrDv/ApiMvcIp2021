using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Utilidades.Exceptions
{
	public class UsuarioException : Exception
	{
		public UsuarioException(string message) : base(message)
		{
		}
	}
}
