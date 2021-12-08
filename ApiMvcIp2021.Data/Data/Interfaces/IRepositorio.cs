using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Interfaces
{
	public interface IRepositorio<T> where T : class
	{
		T ObtenerById(string Id);
		IEnumerable<T> ObtenerTodos();
		void Agregar(T entidad);
	}
}
