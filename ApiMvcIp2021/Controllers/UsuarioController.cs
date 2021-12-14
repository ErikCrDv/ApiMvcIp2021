using ApiMvcIp2021.Data.Data.Interfaces;
using ApiMvcIp2021.Models.Models;
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
	public class UsuarioController : ControllerBase
	{
		private readonly IUnidadTrabajo _unidadTrabajo;

		public UsuarioController(IUnidadTrabajo unidadTrabajo)
		{
			_unidadTrabajo = unidadTrabajo;
		}

	}
}
