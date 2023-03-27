using System;
using System.Linq;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public class RepositorioCoordinador:IRepositorioCoordinador
    {
        private readonly AppContext _appContext;
        public RepositorioCoordinador(AppContext appContext)
        {
            _appContext=appContext;
        }

        Coordinador IRepositorioCoordinador.AddCoordinador(Coordinador coordinador)
        {
            var coordinadorAgregado=_appContext.Coordinadores.Add(coordinador);
            _appContext.SaveChanges();
            return coordinadorAgregado.Entity;
        }

        Coordinador IRepositorioCoordinador.UpdateCoordinador(Coordinador coordinador)
        {
            var coordinadorEncontrado=_appContext.Coordinadores.FirstOrDefault(p=> p.Id==coordinador.Id);
            if(coordinadorEncontrado!=null)
            {
                coordinadorEncontrado.Nombre=coordinador.Nombre;
                coordinadorEncontrado.Apellido=coordinador.Apellido;
                coordinadorEncontrado.Telefono=coordinador.Telefono;
                coordinadorEncontrado.Password=coordinador.Password;
                coordinadorEncontrado.Roll=coordinador.Roll;
            }
            return coordinadorEncontrado;
        }

        void IRepositorioCoordinador.DeleteCoordinadorxId(int id)
        {
            var coordinadorEncontrado=_appContext.Coordinadores.FirstOrDefault(p=> p.Id==id);
            if(coordinadorEncontrado!=null)
            {
                _appContext.Coordinadores.Remove(coordinadorEncontrado);
                _appContext.SaveChanges();
            }
        }

        Coordinador IRepositorioCoordinador.GetCoordinadorxId(int id)
        {
            var coordinadorEncontrado=_appContext.Coordinadores.FirstOrDefault(p=> p.Id==id); 
            return coordinadorEncontrado;
        }

        Coordinador IRepositorioCoordinador.GetCoordinadorxCed(string cedula)
        {
            var coordinadorEncontrado=_appContext.Coordinadores.FirstOrDefault(p=> p.Cedula==cedula); 
            return coordinadorEncontrado;
        }

        Coordinador IRepositorioCoordinador.GetCoordinadorxCedPass(string cedula,int password)
        {
            var coordinadorEncontrado=_appContext.Coordinadores.FirstOrDefault(p=> p.Cedula==cedula);
            if(coordinadorEncontrado!=null)
            {
                if(coordinadorEncontrado.Password==password)
                {
                    return coordinadorEncontrado;
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
