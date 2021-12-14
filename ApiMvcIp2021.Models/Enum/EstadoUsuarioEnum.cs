using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ApiMvcIp2021.Models.Enum
{
	public enum EstadoUsuarioEnum
	{
		[Description("Activo")]
		ACTIVO,

		[Description("Bloqueado")]
		BLOQUEADO
	}
}
