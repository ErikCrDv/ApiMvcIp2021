using ApiMvcIp2021.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Services.Auth
{
	public interface ISesionService
	{
		public DatosSesion IniciarSesion(IniciarSesionRequest iniciarSesionRequest);
		public DatosSesion ObtenerDatosSesion(Usuario usuario);
	}
}
