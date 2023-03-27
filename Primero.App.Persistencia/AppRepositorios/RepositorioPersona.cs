using System;
using System.Linq;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public class RepositorioPersona:IRepositorioPersona
    {
        private readonly AppContext _appContext;
        public RepositorioPersona(AppContext appContext)
        {
            _appContext=appContext;
        }

        Persona IRepositorioPersona.AddPersona(Persona persona)
        {
            var personaAgregado=_appContext.Personas.Add(persona);
            _appContext.SaveChanges();
            return personaAgregado.Entity;
        }

        Persona IRepositorioPersona.UpdatePersona(Persona persona)
        {
            var personaEncontrado=_appContext.Personas.FirstOrDefault(p=> p.Id==persona.Id);
            if(personaEncontrado!=null)
            {
                personaEncontrado.Cedula=persona.Cedula;
                personaEncontrado.Nombre=persona.Nombre;
                personaEncontrado.Apellido=persona.Apellido;
                personaEncontrado.Telefono=persona.Telefono;
                
            }
            return personaEncontrado;
        }

        void IRepositorioPersona.DeletePersonaxId(int id)
        {
            var personaEncontrado=_appContext.Personas.FirstOrDefault(p=> p.Id==id);
            if(personaEncontrado!=null)
            {
                _appContext.Personas.Remove(personaEncontrado);
                _appContext.SaveChanges();
            }
        }

        Persona IRepositorioPersona.GetPersonaxId(int id)
        {
            var personaEncontrado=_appContext.Personas.FirstOrDefault(p=> p.Id==id); 
            return personaEncontrado;
        }
    }
}
