using ApiMvcIp2021.Data.AppDbContext;
using ApiMvcIp2021.Data.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Repositorio
{
	public class UnidadTrabajo : IUnidadTrabajo
	{

		private readonly ApplicationDbContext _applicationDbContext;
		public IUsuarioRepositorio Usuario { get; private set; }
		public IClienteRepositorio Cliente { get; private set; }


		public UnidadTrabajo(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
			Usuario = new UsuarioRepositorio(_applicationDbContext);
			Cliente = new ClienteRepositorio(_applicationDbContext);
		}

		public void Guardar()
		{
			_applicationDbContext.SaveChanges();
		}

		public void Dispose()
		{
			_applicationDbContext.Dispose();
		}
	}
}
