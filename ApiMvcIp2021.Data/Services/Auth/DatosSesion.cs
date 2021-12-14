using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Services.Auth
{
	public class DatosSesion
	{
		public string Token { get; set; }
		public string UserId { get; set; }
		public string Nombre { get; set; }
		public string Ambiente { get; set; }
		public string UltimoInicioSesion { get; set; }
	}
}
