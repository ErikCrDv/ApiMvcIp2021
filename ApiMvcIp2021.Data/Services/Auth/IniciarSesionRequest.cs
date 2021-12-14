using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Services.Auth
{
	public class IniciarSesionRequest
	{
		public string Usuario { get; set; }
		public string Clave { get; set; }
	}
}
