using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Models.ViewModels
{
    /// <summary>
    /// Clase que permite devolver un listado generico para tablas paginadas.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public class ListadoPaginadoViewModel<T>
	{
        /// <summary>
        /// Listado de objetos generico, resultado de una consulta.
        /// </summary>
        public IList<T> Result { get; set; }

        /// <summary>
        /// Total de registros en la base de datos.
        /// </summary>
        public int TotalRegistros { get; set; }
    }
}
