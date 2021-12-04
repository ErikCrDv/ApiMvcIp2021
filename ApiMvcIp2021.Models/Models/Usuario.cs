﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Models.Models
{
	public class Usuario
	{
		public string UsuarioId { get; set; }
		public string NombreUsuario { get; set; }
		public string Password { get; set; }
		public string NombreCompleto { get; set; }

		public bool grantCliente { get; set; }
		public bool grantPago { get; set; }
		public bool grantLicencia { get; set; }
		public bool grantPredial { get; set; }
		public bool grantReporte { get; set; }
		public bool grantPolizas { get; set; }
		public bool grantCuenta { get; set; }
		public bool grantConcepto { get; set; }
		public bool grantConsulta { get; set; }

		public bool grantAdmin { get; set; }
		public bool grantVerificacion { get; set; }
		public bool grantEditarPredial { get; set; }
		public bool grantCancelarRecibo { get; set; }

		public string grantReportePago { get; set; }
		public string grantReporteVerificacion { get; set; }
	}
}
