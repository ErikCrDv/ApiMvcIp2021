using ApiMvcIp2021.Data.AppDbContext;
using ApiMvcIp2021.Data.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Repositorio
{
	public class Repositorio<T> : IRepositorio<T> where T : class
	{
		private readonly ApplicationDbContext _applicationDbContext;
		internal DbSet<T> _dbSet;

		public Repositorio(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
			_dbSet = _applicationDbContext.Set<T>();
		}

		public void Agregar(T entidad)
		{
			_dbSet.Add(entidad);
		}
	}
}
