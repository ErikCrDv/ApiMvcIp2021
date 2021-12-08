using ApiMvcIp2021.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Interfaces
{
	public interface IClienteRepositorio : IRepositorio<Cliente>
	{
		void Actualizar(Cliente cliente);
	}
}
