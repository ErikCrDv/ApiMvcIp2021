using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Models.ViewModels
{
	public class ListadoRequest
	{
        /// <summary>
        /// Campo por el cual se debe ordenar la lista.
        /// </summary>
        public string sortBy { get; set; }

        /// <summary>
        /// Boleando que indica si el ordenamiento debe ser descentente.
        /// </summary>
        public Boolean sortDesc { get; set; }

        /// <summary>
        /// Indica cuantos registros se deben traer por pagina.
        /// </summary>
        public Int32 perPage { get; set; }

        /// <summary>
        /// Indica el numero de pagina que se va  a mostrar de la consulta.
        /// </summary>
        public Int32 currentPage { get; set; }

        /// <summary>
        /// Filtro que se va a aplicar en la consulta.
        /// </summary>
        public string filter { get; set; }

        /// <summary>
        /// Usuario que esta realizando la consulta.
        /// </summary>
        public string idUsuario { get; set; }

        /// <summary>
        /// Campo de solo lectura que nos regresa cuando registros se deben saltar
        /// al momento de paginar a partir de numero de pagina y total de registros
        /// que se deben mostrar por pagina.
        /// </summary>
        public Int32 skipRow
        {
            get { return perPage * (currentPage - 1); }
        }

    }
}
