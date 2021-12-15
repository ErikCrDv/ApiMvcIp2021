using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiMvcIp2021.Models.ViewModels
{
	public class ClienteViewModel
	{
		public string ClienteId { get; set; }

		[Required(ErrorMessage = "El nombre es requerido.")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "El RFC es requerido.")]
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
