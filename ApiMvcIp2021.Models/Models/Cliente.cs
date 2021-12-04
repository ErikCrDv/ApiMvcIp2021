using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Models.Models
{
	public class Cliente
	{
		public string ClienteId { get; set; }
		public string Nombre { get; set; }
		public string RFC { get; set; }
		public string CP { get; set; }
		public string Estado { get; set; }
		public string Municipio { get; set; }
		public string Ciudad { get; set; }
		public string Colonia { get; set; }
		public string Direcccion { get; set; }
		public string Email { get; set; }
		public string Telefono { get; set; }
	}
}
