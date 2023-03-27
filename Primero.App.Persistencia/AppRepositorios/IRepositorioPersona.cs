using System;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public interface IRepositorioPersona
    {
        Persona AddPersona(Persona persona);
        Persona UpdatePersona(Persona persona);
        void DeletePersonaxId(int id);
        Persona GetPersonaxId(int id);        
    }
}