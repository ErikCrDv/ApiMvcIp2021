using ApiMvcIp2021.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Repositorio
{
	public class PaginacionRepositorio<T>
	{
		public PaginacionRepositorio()
		{

		}

        public ListadoPaginadoViewModel<T> ejecutarConsultaPaginada(IQueryable<T> query, ListadoRequest listadoRequest, Func<T, Object> campoOrdenamiento)
        {

            ListadoPaginadoViewModel<T> listadoPaginadoViewModel = new ListadoPaginadoViewModel<T>();
            listadoPaginadoViewModel.TotalRegistros = query.Count();


            if (listadoRequest.sortDesc)
            {
                listadoPaginadoViewModel.Result = query
                     .OrderByDescending(campoOrdenamiento)
                     .Skip(listadoRequest.skipRow)
                     .Take(listadoRequest.perPage).ToList();
            }
            else
            {
                listadoPaginadoViewModel.Result = query
                     .OrderBy(campoOrdenamiento)
                     .Skip(listadoRequest.skipRow)
                     .Take(listadoRequest.perPage).ToList();
            }

            return listadoPaginadoViewModel;

        }

    }
}
