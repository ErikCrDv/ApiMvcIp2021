using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Models.Models
{
	public class Poliza
	{
		public DateTime Fecha { get; set; }
		public string Cuenta { get; set; }
		public double ImpCuenta { get; set; }

		public double PU { get; set; }
		public double PR { get; set; }
		public double VR { get; set; }
		public double NA { get; set; }
		public double RP { get; set; }
		public double RU { get; set; }
		public double RR { get; set; }
		public double AUTO { get; set; }
		public double RECA { get; set; }
		public double MULT { get; set; }
		public double DESCU { get; set; }
		public double CEDCAT { get; set; }
		public double CP { get; set; }
		public double RP2 { get; set; }
		public double DEBE { get; set; }
		public double HABER { get; set; }
		public int RRO1 { get; set; }
		public int RRO2 { get; set; }
		public int RRC1 { get; set; }
		public int RRC2 { get; set; }
		public int RRC3 { get; set; }
		public int RRC4 { get; set; }
		public int RCC1 { get; set; }
		public int RCC2 { get; set; }
		public int RRF1 { get; set; }
		public int RRF2 { get; set; }
		public string Elaboro { get; set; }
	}
}
