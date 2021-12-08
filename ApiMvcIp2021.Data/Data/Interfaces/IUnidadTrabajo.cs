using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Interfaces
{
	public interface IUnidadTrabajo : IDisposable
	{
		IUsuarioRepositorio Usuario { get; }
		IClienteRepositorio Cliente { get;  }
		void Guardar();
	}
}
