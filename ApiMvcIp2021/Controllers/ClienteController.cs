using ApiMvcIp2021.Data.Data.Interfaces;
using ApiMvcIp2021.Models.Models;
using ApiMvcIp2021.Models.ViewModels;
using ApiMvcIp2021.Utilidades.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMvcIp2021.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private readonly IUnidadTrabajo _unidadTrabajo;

		public ClienteController(IUnidadTrabajo unidadTrabajo)
		{
			_unidadTrabajo = unidadTrabajo;
		}

		[HttpPost]
		[Route("registro")]
		public ActionResult Crear(ClienteViewModel clienteViewModel)
		{
			try
			{
				_unidadTrabajo.Cliente.Crear(clienteViewModel);
				return new OkResult();
			}
			catch (ClienteException ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

		[HttpPut]
		[Route("actualizar")]
		public ActionResult Actualizar(ClienteViewModel clienteViewModel)
		{
			try
			{
				_unidadTrabajo.Cliente.Actualizar(clienteViewModel);
				return new OkResult();
			}
			catch (ClienteException ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

		[HttpGet]
		[Route("por-id")]
		public ActionResult<ClienteViewModel> ObtenerPorId(string clienteId)
		{
			try
			{
				return _unidadTrabajo.Cliente.ObtenerPorId(clienteId);
			}
			catch (ClienteException ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

		[HttpGet]
		[Route("listado")]
		public ActionResult<ListadoPaginadoViewModel<ClienteViewModel>> Listado(ListadoRequest listadoRequest)
		{
			try
			{
				return _unidadTrabajo.Cliente.Listado(listadoRequest);
			}
			catch (ClienteException ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

	}
}
