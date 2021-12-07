using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Interfaces
{
	public interface IRepositorio<T> where T : class
	{
		void Agregar(T entidad);
	}
}
