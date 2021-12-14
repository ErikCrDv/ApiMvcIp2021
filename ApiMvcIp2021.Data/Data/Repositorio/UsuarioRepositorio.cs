using ApiMvcIp2021.Data.AppDbContext;
using ApiMvcIp2021.Data.Data.Interfaces;
using ApiMvcIp2021.Models.Enum;
using ApiMvcIp2021.Models.Models;
using ApiMvcIp2021.Models.ViewModels;
using ApiMvcIp2021.Utilidades.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Repositorio
{
	public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
	{
		private readonly ApplicationDbContext _applicationDbContext;

		public UsuarioRepositorio(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public void Actualizar(UsuarioViewModel usuarioViewModel)
		{
			if (ExisteCorreo(usuarioViewModel.Correo, usuarioViewModel.UsuarioId))
			{
				throw new UsuarioException("Ya existe un usuario con el correo ingresado en la base de datos.");
			}

			if (ExisteUsuario(usuarioViewModel.NombreUsuario, usuarioViewModel.UsuarioId))
			{
				throw new UsuarioException("Ya existe el usuario en la base de datos.");
			}
			Usuario usuario = _applicationDbContext.Usuarios.Find(usuarioViewModel.UsuarioId);
			if (usuario == null)
			{
				throw new UsuarioException("No se encontro el usuario.");
			}

			usuario.Correo = usuarioViewModel.Correo;
			usuario.NombreUsuario = usuarioViewModel.NombreUsuario;

			_applicationDbContext.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_applicationDbContext.SaveChanges();
		}

		public void ActualizarContrasena(string usuarioId, string contrasena)
		{
			Usuario usuario = _applicationDbContext.Usuarios.Find(usuarioId);
			if (usuario == null)
			{
				throw new UsuarioException("No se encontro el usuario.");
			}

			usuario.Contrasena = Utilidades.Utilidades.Utilidades.EncryptString(contrasena);

			_applicationDbContext.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_applicationDbContext.SaveChanges();
		}

		public void CambiarEstatus(string usuarioId, EstadoUsuarioEnum estatusUsuariosEnum)
		{
			Usuario usuario = _applicationDbContext.Usuarios.Find(usuarioId);
			if (usuario == null)
			{
				throw new UsuarioException("No se encontro el usuario.");
			}

			usuario.Estatus = estatusUsuariosEnum;

			_applicationDbContext.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_applicationDbContext.SaveChanges();
		}

		public void Crear(UsuarioViewModel usuarioViewModel)
		{
			if (ExisteCorreo(usuarioViewModel.Correo))
			{
				throw new UsuarioException("Ya existe un usuario con el correo ingresado en la base de datos.");
			}

			if (ExisteUsuario(usuarioViewModel.NombreUsuario))
			{
				throw new UsuarioException("Ya existe el usuario en la base de datos.");
			}

			Usuario usuario = new Usuario()
			{
				Contrasena = Utilidades.Utilidades.Utilidades.EncryptString(usuarioViewModel.Contrasena),
				Correo = usuarioViewModel.Correo,
				Estatus = EstadoUsuarioEnum.ACTIVO,
				NombreUsuario = usuarioViewModel.NombreUsuario
			};

			_applicationDbContext.Add(usuario);
			_applicationDbContext.SaveChanges();
		}

		public bool ExisteCorreo(string correo)
		{
			if (_applicationDbContext.Usuarios.Where(u => u.Correo.Equals(correo)).Count() > 0)
			{
				return true;
			};
			return false;
		}

		public bool ExisteCorreo(string correo, string usuarioId)
		{
			if (_applicationDbContext.Usuarios.Where(u => u.Correo.Equals(correo) && !u.UsuarioId.Equals(usuarioId)).Count() > 0)
			{
				return true;
			};
			return false;
		}

		public bool ExisteUsuario(string usuario)
		{
			if (_applicationDbContext.Usuarios.Where(u => u.NombreUsuario.Equals(usuario)).Count() > 0)
			{
				return true;
			};
			return false;
		}

		public bool ExisteUsuario(string usuario, string usuarioId)
		{
			if (_applicationDbContext.Usuarios.Where(u => u.NombreUsuario.Equals(usuario) && !u.UsuarioId.Equals(usuarioId)).Count() > 0)
			{
				return true;
			};
			return false;
		}

		public ListadoPaginadoViewModel<UsuarioViewModel> Listado(ListadoRequest listadoRequest)
		{
			string filtro = string.IsNullOrEmpty(listadoRequest.filter) ? "" : listadoRequest.filter;

			var query = _applicationDbContext.Usuarios
							.Where(o => o.NombreUsuario.Contains(filtro))
							// || o.Contrasena.ToString().Contains(filtro))
							.Select(or => new UsuarioViewModel
							{
								UsuarioId = or.UsuarioId,
								NombreUsuario = or.NombreUsuario,
								Correo = or.Correo,
								Estatus = or.Estatus,
								UltimoInicioSesion = or.UltimoInicioSesion
							});

			Func<UsuarioViewModel, Object> campoOrdenamiento = campo => campo.NombreUsuario;
			switch (listadoRequest.sortBy)
			{
				case "nombreUsuario":
					campoOrdenamiento = campo => campo.NombreUsuario;
					break;
				case "correo":
					campoOrdenamiento = campo => campo.Correo;
					break;
				default:
					campoOrdenamiento = campo => campo.NombreUsuario;
					break;
			}

			PaginacionRepositorio<UsuarioViewModel> paginacionRepository = new PaginacionRepositorio<UsuarioViewModel>();
			ListadoPaginadoViewModel<UsuarioViewModel> listadoUsuarios = paginacionRepository.ejecutarConsultaPaginada(query, listadoRequest, campoOrdenamiento);
			return listadoUsuarios;
		}

		public UsuarioViewModel ObtenerPorCorreo(string correo)
		{
			Usuario usuario = _applicationDbContext.Usuarios.Where(u => u.Correo.Equals(correo)).FirstOrDefault();
			if (usuario == null)
			{
				throw new UsuarioException("No se econtro del usuario");
			}
			return toUsuarioViewModel(usuario);
		}

		public UsuarioViewModel ObtenerPorId(string idUsuario)
		{
			Usuario usuario = _applicationDbContext.Usuarios.Find(idUsuario);
			if (usuario == null)
			{
				throw new UsuarioException("No se econtro del usuario");
			}
			return toUsuarioViewModel(usuario);
		}

		private UsuarioViewModel toUsuarioViewModel(Usuario usuario)
		{

			UsuarioViewModel usuarioViewModel = new UsuarioViewModel()
			{
				Correo = usuario.Correo,
				Estatus = usuario.Estatus,
				NombreUsuario = usuario.NombreUsuario,
				UltimoInicioSesion = usuario.UltimoInicioSesion,
				UsuarioId = usuario.UsuarioId

			};
			return usuarioViewModel;
		}

		//public void Actualizar(string id, Usuario usuario)
		//{
		//	Usuario usuarioDb = _applicationDbContext.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
		//	if(usuarioDb != null)
		//	{
		//		usuarioDb.NombreUsuario = usuario.NombreUsuario;
		//		usuarioDb.Password = usuario.Password;
		//		usuarioDb.NombreCompleto = usuario.NombreCompleto;
		//		usuarioDb.grantCliente = usuario.grantCliente;
		//		usuarioDb.grantPago = usuario.grantPago;
		//		usuarioDb.grantLicencia = usuario.grantLicencia;
		//		usuarioDb.grantPredial = usuario.grantPredial;
		//		usuarioDb.grantReporte = usuario.grantReporte;
		//		usuarioDb.grantPolizas = usuario.grantPolizas;
		//		usuarioDb.grantCuenta = usuario.grantCuenta;
		//		usuarioDb.grantConcepto = usuario.grantConcepto;
		//		usuarioDb.grantConsulta = usuario.grantConsulta;
		//		usuarioDb.grantAdmin = usuario.grantAdmin;
		//		usuarioDb.grantVerificacion = usuario.grantVerificacion;
		//		usuarioDb.grantEditarPredial = usuario.grantPredial;
		//		usuarioDb.grantCancelarRecibo = usuario.grantCancelarRecibo;
		//		usuarioDb.grantReportePago = usuario.grantReportePago;
		//		usuarioDb.grantReporteVerificacion = usuario.grantReporteVerificacion;
		//	}
		//}
	}
}
