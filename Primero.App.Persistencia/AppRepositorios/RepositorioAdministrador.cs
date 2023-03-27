using System;
using System.Linq;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public class RepositorioAdministrador:IRepositorioAdministrador
    {
        private readonly AppContext _appContext;
        public RepositorioAdministrador(AppContext appContext)
        {
            _appContext=appContext;
        }

        Administrador IRepositorioAdministrador.AddAdministrador(Administrador administrador)
        {
            var administradorAgregado=_appContext.Administradores.Add(administrador);
            _appContext.SaveChanges();
            return administradorAgregado.Entity;
        }

        Administrador IRepositorioAdministrador.UpdateAdministrador(Administrador administrador)
        {
            var administradorEncontrado=_appContext.Administradores.FirstOrDefault(p=> p.Id==administrador.Id);
            if(administradorEncontrado!=null)
            {
                administradorEncontrado.Nombre=administrador.Nombre;
                administradorEncontrado.Apellido=administrador.Apellido;
                administradorEncontrado.Telefono=administrador.Telefono;
                administradorEncontrado.Password=administrador.Password;
                administradorEncontrado.Roll=administrador.Roll;
            }
            return administradorEncontrado;
        }

        void IRepositorioAdministrador.DeleteAdministradorxId(int id)
        {
            var administradorEncontrado=_appContext.Administradores.FirstOrDefault(p=> p.Id==id);
            if(administradorEncontrado!=null)
            {
                _appContext.Administradores.Remove(administradorEncontrado);
                _appContext.SaveChanges();
            }
        }

        Administrador IRepositorioAdministrador.GetAdministradorxId(int id)
        {
            var administradorEncontrado=_appContext.Administradores.FirstOrDefault(p=> p.Id==id); 
            return administradorEncontrado;
        }

        Administrador IRepositorioAdministrador.GetAdministradorxCedPass(string cedula,int password)
        {
            var administradorEncontrado=_appContext.Administradores.FirstOrDefault(p=> p.Cedula==cedula);  
            if(administradorEncontrado!=null)
            {
                if(administradorEncontrado.Password==password)
                {
                    return administradorEncontrado;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }    
        }
    }
}