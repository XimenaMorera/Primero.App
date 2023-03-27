using System;
using System.Linq;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public class RepositorioTecnico:IRepositorioTecnico
    {
        private readonly AppContext _appContext;
        public RepositorioTecnico(AppContext appContext)
        {
            _appContext=appContext;
        }

        Tecnico IRepositorioTecnico.AddTecnico(Tecnico tecnico)
        {
            var tecnicoAgregado=_appContext.Tecnicos.Add(tecnico);
            _appContext.SaveChanges();
            return tecnicoAgregado.Entity;
        }

        Tecnico IRepositorioTecnico.UpdateTecnico(Tecnico tecnico)
        {
            var tecnicoEncontrado=_appContext.Tecnicos.FirstOrDefault(p=> p.Id==tecnico.Id);
            if(tecnicoEncontrado!=null)
            {
                tecnicoEncontrado.Nombre=tecnico.Nombre;
                tecnicoEncontrado.Apellido=tecnico.Apellido;
                tecnicoEncontrado.Telefono=tecnico.Telefono;
                tecnicoEncontrado.TarjetaProfesional=tecnico.TarjetaProfesional;
            }
            return tecnicoEncontrado;
        }

        void IRepositorioTecnico.DeleteTecnicoxId(int id)
        {
            var tecnicoEncontrado=_appContext.Tecnicos.FirstOrDefault(p=> p.Id==id);
            if(tecnicoEncontrado!=null)
            {
                _appContext.Tecnicos.Remove(tecnicoEncontrado);
                _appContext.SaveChanges();
            }
        }

        Tecnico IRepositorioTecnico.GetTecnicoxId(int id)
        {
            var tecnicoEncontrado=_appContext.Tecnicos.FirstOrDefault(p=> p.Id==id); 
            return tecnicoEncontrado;
        }

        Tecnico IRepositorioTecnico.GetTecnicoxCed(string cedula)
        {
           var tecnicoEncontrado=_appContext.Tecnicos.FirstOrDefault(p=> p.Cedula==cedula); 
            return tecnicoEncontrado; 
        }
    }
}
