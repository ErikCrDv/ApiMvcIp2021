﻿using ApiMvcIp2021.Data.Data.Interfaces;
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


		[HttpGet]
		public IEnumerable<Usuario> Get()
		{
			return _unidadTrabajo.Usuario.ObtenerTodos();
		}

		[HttpGet("{id}")]
		public Usuario Get(string id)
		{
			return _unidadTrabajo.Usuario.ObtenerById(id);
		}

		[HttpPost]
		public void Post(Usuario usuario)
		{
			_unidadTrabajo.Usuario.Agregar(usuario);
			_unidadTrabajo.Guardar();
		}

		[HttpPut("{id}")]
		public void Put(string id, Usuario usuario)
		{
			_unidadTrabajo.Usuario.Actualizar(id, usuario);
			_unidadTrabajo.Guardar();
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
