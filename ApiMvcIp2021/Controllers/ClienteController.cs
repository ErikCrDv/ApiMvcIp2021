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
	public class ClienteController : ControllerBase
	{
		private readonly IUnidadTrabajo _unidadTrabajo;

		public ClienteController(IUnidadTrabajo unidadTrabajo)
		{
			_unidadTrabajo = unidadTrabajo;
		}
		[HttpGet]
		public IEnumerable<Cliente> Get()
		{
			return _unidadTrabajo.Cliente.ObtenerTodos();
		}

		[HttpGet("{id}")]
		public Cliente Get(string id)
		{
			return _unidadTrabajo.Cliente.ObtenerById(id);
		}


		[HttpPost]
		public void Post(Cliente cliente)
		{
			_unidadTrabajo.Cliente.Agregar(cliente);
			_unidadTrabajo.Guardar();

		}

		[HttpPut]
		public void Put(Cliente cliente)
		{
			_unidadTrabajo.Cliente.Actualizar(cliente);
			_unidadTrabajo.Guardar();
		}


		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
