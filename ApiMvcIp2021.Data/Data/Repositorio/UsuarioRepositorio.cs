using ApiMvcIp2021.Data.AppDbContext;
using ApiMvcIp2021.Data.Data.Interfaces;
using ApiMvcIp2021.Models.Models;
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

		public void Actualizar(string id, Usuario usuario)
		{
			Usuario usuarioDb = _applicationDbContext.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
			if(usuarioDb != null)
			{
				usuarioDb.NombreUsuario = usuario.NombreUsuario;
				usuarioDb.Password = usuario.Password;
				usuarioDb.NombreCompleto = usuario.NombreCompleto;
				usuarioDb.grantCliente = usuario.grantCliente;
				usuarioDb.grantPago = usuario.grantPago;
				usuarioDb.grantLicencia = usuario.grantLicencia;
				usuarioDb.grantPredial = usuario.grantPredial;
				usuarioDb.grantReporte = usuario.grantReporte;
				usuarioDb.grantPolizas = usuario.grantPolizas;
				usuarioDb.grantCuenta = usuario.grantCuenta;
				usuarioDb.grantConcepto = usuario.grantConcepto;
				usuarioDb.grantConsulta = usuario.grantConsulta;
				usuarioDb.grantAdmin = usuario.grantAdmin;
				usuarioDb.grantVerificacion = usuario.grantVerificacion;
				usuarioDb.grantEditarPredial = usuario.grantPredial;
				usuarioDb.grantCancelarRecibo = usuario.grantCancelarRecibo;
				usuarioDb.grantReportePago = usuario.grantReportePago;
				usuarioDb.grantReporteVerificacion = usuario.grantReporteVerificacion;
			}
		}
	}
}
