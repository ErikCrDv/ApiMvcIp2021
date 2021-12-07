using ApiMvcIp2021.Data.AppDbContext;
using ApiMvcIp2021.Data.Data.Interfaces;
using ApiMvcIp2021.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Repositorio
{
	public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
	{
		private readonly ApplicationDbContext _applicationDbContext;

		public UsuarioRepositorio(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
	}
}
