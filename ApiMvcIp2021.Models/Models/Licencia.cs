using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Models.Models
{
	public class Licencia
	{
		public string RazonSocial { get; set; }
		public string Establecimiento  { get; set; }
		public string Domicilio { get; set; }
		public string Colonia { get; set; }
		public string Poblacion { get; set; }
		public string CP { get; set; }
		public DateTime Fecha { get; set; }
		public string Folio { get; set; }
		public double Importe { get; set; }
		public string RFC { get; set; }
		public string Telefono { get; set; }
		
		public string Giro { get; set; }
		public string Ramo { get; set; }
		public string CodeBar { get; set; }



		public string ClienteId { get; set; }
		public string ReciboPago { get; set; }
		

	}
}
