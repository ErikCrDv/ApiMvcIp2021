using ApiMvcIp2021.Data.AppDbContext;
using ApiMvcIp2021.Data.Data.Interfaces;
using ApiMvcIp2021.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Repositorio
{
	public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
	{
		private readonly ApplicationDbContext _applicationDbContext;

		public ClienteRepositorio(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public void Actualizar(Cliente cliente)
		{
			_applicationDbContext.Update(cliente);
		}
	}
}
