using ApiMvcIp2021.Data.AppDbContext;
using ApiMvcIp2021.Models.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ApiMvcIp2021.Utilidades.Exceptions;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ApiMvcIp2021.Data.Services.Auth
{
	public class SesionService : ISesionService
	{
		private readonly ApplicationDbContext _applicationDbContext;
		private readonly IConfiguration _configuration;

		public SesionService(ApplicationDbContext applicationDbContext, IConfiguration configuration)
		{
			_applicationDbContext = applicationDbContext;
			_configuration = configuration;
		}

		public DatosSesion IniciarSesion(IniciarSesionRequest iniciarSesionRequest)
		{
			string clave = Utilidades.Utilidades.Utilidades.EncryptString(iniciarSesionRequest.Clave);
			Usuario usuario = _applicationDbContext.Usuarios
				.Where(u => u.NombreUsuario.Equals(iniciarSesionRequest.Usuario) && u.Contrasena.Equals(clave))
				.FirstOrDefault();
			
			if(usuario == null)
			{
				throw new SesionException("Credenciales Incorrectas");
			}
			else
			{
				return ObtenerDatosSesion(usuario);
			}

		}

		public DatosSesion ObtenerDatosSesion(Usuario usuario)
		{
			var secretKey = _configuration.GetValue<String>("SecretKey");
			var key = Encoding.ASCII.GetBytes(secretKey);
			var tiempoSesion = _configuration.GetValue<int>("MinutosTiempoSesion");
			var ambienteActual = _configuration.GetValue<string>("Ambiente");


			ClaimsIdentity claims = new ClaimsIdentity();
			claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.NombreUsuario));
			claims.AddClaim(new Claim(ClaimTypes.Email, usuario.Correo));
			claims.AddClaim(new Claim(ClaimTypes.Sid, usuario.UsuarioId));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = claims,
				Expires = DateTime.UtcNow.AddMinutes(tiempoSesion),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var createdToken = tokenHandler.CreateToken(tokenDescriptor);

			DatosSesion datosSesionViewModel = new DatosSesion()
			{
				Token = tokenHandler.WriteToken(createdToken),
				Nombre = usuario.NombreUsuario,
				UltimoInicioSesion = usuario.UltimoInicioSesion.ToLongDateString()
			};
			return datosSesionViewModel;
		}
	}
}
