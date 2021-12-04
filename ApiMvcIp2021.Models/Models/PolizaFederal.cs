using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Models.Models
{
	public class PolizaFederal
	{
		public DateTime Fecha { get; set; }
		public string Cuentas { get; set; }
		public string NomCuentas { get; set; }
		public double Importe { get; set; }
		public double Banco { get; set; }
		public double Caja { get; set; }
	}
}
