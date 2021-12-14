using ApiMvcIp2021.Models.Enum;
using ApiMvcIp2021.Models.Models;
using ApiMvcIp2021.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.Data.Interfaces
{
	public interface IUsuarioRepositorio : IRepositorio<Usuario>
	{
        public void Crear(UsuarioViewModel usuarioViewModel);
        public void Actualizar(UsuarioViewModel usuarioViewModel);
        public void ActualizarContrasena(string usuarioId, string contrasena);
        public void CambiarEstatus(string usuarioId, EstadoUsuarioEnum estatusUsuariosEnum);
        public UsuarioViewModel ObtenerPorId(string idUsuario);
        public UsuarioViewModel ObtenerPorCorreo(string correo);
        public ListadoPaginadoViewModel<UsuarioViewModel> Listado(ListadoRequest listadoRequest);
        public bool ExisteCorreo(string correo);
        public bool ExisteCorreo(string correo, string usuarioId);
        public bool ExisteUsuario(string usuario);
        public bool ExisteUsuario(string usuario, string usuarioId);

        //void Actualizar(string id, Usuario usuario);
    }
}
