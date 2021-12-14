using ApiMvcIp2021.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiMvcIp2021.Models.ViewModels
{
	public class UsuarioViewModel
	{
        public string UsuarioId { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        public string NombreUsuario { get; set; }
        
        [Required(ErrorMessage = "El correo es requerido.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido.")]
        public string Correo { get; set; }
        
        [Required(ErrorMessage = "La contraseña requerido.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres.", MinimumLength = 8)]
        [Display(Name = "Contraseña")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Las contraseñas deben tener al menos 8 caracteres y contener 3 de 4 de los siguientes: mayúsculas (A-Z), minúsculas (a-z), número (0-9) y caracteres especiales (por ejemplo, !@#$%^&*).")]
        public string Contrasena { get; set; }
        
        public DateTime UltimoInicioSesion { get; set; }
        public EstadoUsuarioEnum Estatus { get; set; }

        public string EstatusDescripcion
        {
            get { return Utilidades.Utilidades.Utilidades.GetDescriptionEnum<EstadoUsuarioEnum>(Estatus); }
        }
    }
}
