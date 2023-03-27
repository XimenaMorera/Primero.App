using System;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public interface IRepositorioAdministrador
    {
        Administrador AddAdministrador(Administrador administrador);
        Administrador UpdateAdministrador(Administrador administrador);
        void DeleteAdministradorxId(int id);
        Administrador GetAdministradorxId(int id);
        Administrador GetAdministradorxCedPass(string cedula,int password);

        
    }
}