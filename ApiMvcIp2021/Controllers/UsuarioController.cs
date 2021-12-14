using ApiMvcIp2021.Data.Data.Interfaces;
using ApiMvcIp2021.Models.Models;
using ApiMvcIp2021.Models.ViewModels;
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
	public class UsuarioController : ControllerBase
	{
		private readonly IUnidadTrabajo _unidadTrabajo;

		public UsuarioController(IUnidadTrabajo unidadTrabajo)
		{
			_unidadTrabajo = unidadTrabajo;
		}

		[HttpGet]
		[Route("por-id")]
		public ActionResult<UsuarioViewModel> PorId(string idUsuario)
		{
			try
			{
				return _unidadTrabajo.Usuario.ObtenerPorId(idUsuario);
			}
			catch (UsuarioException ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

		[HttpGet]
		[Route("por-correo")]
		public ActionResult<UsuarioViewModel> PorCorreo(string correo)
		{
			try
			{
				return _unidadTrabajo.Usuario.ObtenerPorCorreo(correo);
			}
			catch (UsuarioException ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
			
		}

		[HttpPost]
		[Route("registrar")]
		public ActionResult CrearUsuario(UsuarioViewModel usuarioViewModel)
		{
			try
			{
				_unidadTrabajo.Usuario.Crear(usuarioViewModel);
				return new OkResult();
			}
			catch (UsuarioException ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

		[HttpPut]
		[Route("actualizar")]
		public ActionResult Actualizar(UsuarioViewModel usuarioViewModel)
		{
			try
			{
				_unidadTrabajo.Usuario.Actualizar(usuarioViewModel);
				return new OkResult();
			}
			catch (UsuarioException ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

		[HttpPut]
		[Route("actualizar-contrasena")]
		public ActionResult ActualizarContrasena(string usuarioId, string contrasena)
		{
			try
			{
				_unidadTrabajo.Usuario.ActualizarContrasena(usuarioId, contrasena);
				return new OkResult();
			}
			catch (UsuarioException ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

		[HttpGet]
		[Route("lista")]
		public ActionResult<ListadoPaginadoViewModel<UsuarioViewModel>> Listado(ListadoRequest listadoRequest)
		{
			try
			{
				return _unidadTrabajo.Usuario.Listado(listadoRequest);
			}
			catch (UsuarioException ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

	}
}
