using System;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public interface IRepositorioCoordinador
    {
        Coordinador AddCoordinador(Coordinador coordinador);
        void DeleteCoordinadorxId(int id);
        Coordinador GetCoordinadorxId(int id);
        Coordinador UpdateCoordinador(Coordinador coordinador);
        Coordinador GetCoordinadorxCed(string cedula);
        Coordinador GetCoordinadorxCedPass(string cedula,int password);
        
    }
}