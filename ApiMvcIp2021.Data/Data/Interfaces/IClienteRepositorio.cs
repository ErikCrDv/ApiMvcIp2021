using ApiMvcIp2021.Models.Models;
using ApiMvcIp2021.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Interfaces
{
	public interface IClienteRepositorio : IRepositorio<Cliente>
	{
        public void Crear(ClienteViewModel clienteViewModel);
        public void Actualizar(ClienteViewModel clienteViewModel);
        public ClienteViewModel ObtenerPorId(string clienteId);
        public ListadoPaginadoViewModel<ClienteViewModel> Listado(ListadoRequest listadoRequest);
        public bool ExisteRFC(string RFC);

        // void Actualizar(Cliente cliente);
    }
}
