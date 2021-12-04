using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Models.Models
{
	public class Verificacion
	{
		public string VerificacionId { get; set; }
		public string Observacion { get; set; }
		public DateTime FechaRegistro { get; set; }
		public DateTime FechaLimite { get; set; }
		public string Estado { get; set; }
		public string NoVerificacion { get; set; }
		public DateTime FechaDePago { get; set; }
		public string FolioDePago { get; set; }
		public string UsuarioCaja { get; set; }



		public string ClienteId { get; set; }
		public string UsuarioId { get; set; }
	}
}
