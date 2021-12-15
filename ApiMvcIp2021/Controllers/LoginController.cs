using ApiMvcIp2021.Data.Services.Auth;
using ApiMvcIp2021.Utilidades.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMvcIp2021.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ISesionService _sesionService;
		public LoginController(ISesionService sesionService)
		{
			_sesionService = sesionService;
		}

		[HttpGet]
		[Route("token")]
		public ActionResult<DatosSesion> InicioSesion(IniciarSesionRequest iniciarSesionRequest)
		{
			try
			{
				return _sesionService.IniciarSesion(iniciarSesionRequest);
			}
			catch (SesionException ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}
	}
}
