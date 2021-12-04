using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Models.Models
{
	public class Pago
	{
		public string NombreCliente { get; set; }
		public int Recibo { get; set; }
		public string Descripcion { get; set; }
		public double Importe { get; set; }
		public DateTime Fecha { get; set; }
		public DateTime Hora { get; set; }
		public string Estado { get; set; }
		public string TipoPago { get; set; }
		public bool Factura { get; set; }

		public string Tipo { get; set; }
		public string EstadoFederal { get; set; }
		public double Subimporte { get; set; }
		public string NoCuenta { get; set; }
		public string CodeBar { get; set; }
		public string FolioPago { get; set; }



		public string ClienteId { get; set; }
		public string NoCategoria { get; set; }
		public string NoCuentaContable { get; set; }

		public string UserId { get; set; }
	}
}
