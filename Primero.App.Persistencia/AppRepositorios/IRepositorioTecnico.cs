using System;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public interface IRepositorioTecnico
    {
        Tecnico AddTecnico(Tecnico tecnico);
        void DeleteTecnicoxId(int id);
        Tecnico GetTecnicoxId(int id);
        Tecnico UpdateTecnico(Tecnico tecnico);
        Tecnico GetTecnicoxCed(string cedula);
    }
}