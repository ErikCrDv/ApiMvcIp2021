using ApiMvcIp2021.Data.AppDbContext;
using ApiMvcIp2021.Data.Data.Interfaces;
using ApiMvcIp2021.Models.Models;
using ApiMvcIp2021.Models.ViewModels;
using ApiMvcIp2021.Utilidades.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Repositorio
{
	public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
	{
		private readonly ApplicationDbContext _applicationDbContext;

		public ClienteRepositorio(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public void Actualizar(ClienteViewModel clienteViewModel)
		{
			if (ExisteRFC(clienteViewModel.RFC))
			{
				throw new ClienteException("Ya hay un cliente registrado con el RFC ingresado.");
			}

			Cliente cliente = _applicationDbContext.Clientes.Find(clienteViewModel.ClienteId);
			if (cliente == null)
			{
				throw new ClienteException("No se encontro el cliente.");
			}

			cliente.Nombre = clienteViewModel.Nombre;
			cliente.RFC = clienteViewModel.RFC;
			cliente.CP = clienteViewModel.CP;
			cliente.Estado = clienteViewModel.Estado;
			cliente.Municipio = clienteViewModel.Municipio;
			cliente.Ciudad = clienteViewModel.Ciudad;
			cliente.Colonia = clienteViewModel.Colonia;
			cliente.Direcccion = clienteViewModel.Direcccion;
			cliente.Email = clienteViewModel.Email;
			cliente.Telefono = clienteViewModel.Telefono;

			_applicationDbContext.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_applicationDbContext.SaveChanges();
		}

		public void Crear(ClienteViewModel clienteViewModel)
		{
			if (ExisteRFC(clienteViewModel.RFC))
			{
				throw new ClienteException("Ya hay un cliente registrado con el RFC ingresado.");
			}

			Cliente cliente = new Cliente()
			{
				Nombre = clienteViewModel.Nombre,
				RFC = clienteViewModel.RFC,
				CP = clienteViewModel.CP,
				Estado = clienteViewModel.Estado,
				Municipio = clienteViewModel.Municipio,
				Ciudad = clienteViewModel.Ciudad,
				Colonia = clienteViewModel.Colonia,
				Direcccion = clienteViewModel.Direcccion,
				Email = clienteViewModel.Email,
				Telefono = clienteViewModel.Telefono
			};

			_applicationDbContext.Add(cliente);
			_applicationDbContext.SaveChanges();
		}

		public bool ExisteRFC(string RFC)
		{
			if (_applicationDbContext.Clientes.Where(u => u.RFC.Equals(RFC)).Count() > 0)
			{
				return true;
			};
			return false;
		}

		public ListadoPaginadoViewModel<ClienteViewModel> Listado(ListadoRequest listadoRequest)
		{
			string filtro = string.IsNullOrEmpty(listadoRequest.filter) ? "" : listadoRequest.filter;

			var query = _applicationDbContext.Clientes
							.Where(o => o.Nombre.Contains(filtro))
							// || o.Contrasena.ToString().Contains(filtro))
							.Select(or => new ClienteViewModel
							{
								ClienteId = or.ClienteId,
								Nombre = or.Nombre,
								RFC = or.RFC,
								CP = or.CP,
								Estado = or.Estado,
								Municipio = or.Municipio,
								Ciudad = or.Ciudad,
								Colonia = or.Colonia,
								Direcccion = or.Direcccion,
								Email = or.Email,
								Telefono = or.Telefono
							});

			Func<ClienteViewModel, Object> campoOrdenamiento = campo => campo.Nombre;
			switch (listadoRequest.sortBy)
			{
				case "Nombre":
					campoOrdenamiento = campo => campo.Nombre;
					break;
				case "RFC":
					campoOrdenamiento = campo => campo.RFC;
					break;
				default:
					campoOrdenamiento = campo => campo.Nombre;
					break;
			}

			PaginacionRepositorio<ClienteViewModel> paginacionRepository = new PaginacionRepositorio<ClienteViewModel>();
			ListadoPaginadoViewModel<ClienteViewModel> listadoClientes = paginacionRepository.ejecutarConsultaPaginada(query, listadoRequest, campoOrdenamiento);
			return listadoClientes;
		}

		public ClienteViewModel ObtenerPorId(string clienteId)
		{
			Cliente cliente = _applicationDbContext.Clientes.Find(clienteId);
			if (cliente == null)
			{
				throw new ClienteException("No se econtro el cliente");
			}
			return toClienteViewModel(cliente);
		}

		private ClienteViewModel toClienteViewModel(Cliente cliente)
		{

			ClienteViewModel clienteViewModel = new ClienteViewModel()
			{
				ClienteId = cliente.ClienteId,
				Nombre = cliente.Nombre,
				RFC = cliente.RFC,
				CP = cliente.CP,
				Estado = cliente.Estado,
				Municipio = cliente.Municipio,
				Ciudad = cliente.Ciudad,
				Colonia = cliente.Colonia,
				Direcccion = cliente.Direcccion,
				Email = cliente.Email,
				Telefono = cliente.Telefono
			};
			return clienteViewModel;
		}

		//public void Actualizar(Cliente cliente)
		//{
		//	_applicationDbContext.Update(cliente);
		//}
	}
}
