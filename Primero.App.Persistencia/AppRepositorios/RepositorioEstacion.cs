using System;
using System.Linq;
using Primero.App.Dominio;
using Primero.App.Persistencia;
using Microsoft.EntityFrameworkCore;
namespace Primero.App.Persistencia
{
    public class RepositorioEstacion: IRepositorioEstacion
    {
        private readonly AppContext _appContext;
        public RepositorioEstacion(AppContext appContext)
        {
            _appContext=appContext;
        }

        Estacion IRepositorioEstacion.AddEstacion(Estacion estacion)
        {
            var estacionAdicionada=_appContext.Estaciones.Add(estacion);
            _appContext.SaveChanges();
            return estacionAdicionada.Entity;
        }

        Estacion IRepositorioEstacion.UpdateEstacion(Estacion estacion)
        {
            var estacionEncontrada=_appContext.Estaciones.FirstOrDefault(p=> p.Codigo==estacion.Codigo);
            if(estacionEncontrada!=null)
            {
                estacionEncontrada.Codigo=estacion.Codigo;
                estacionEncontrada.Latitud=estacion.Latitud;
                estacionEncontrada.Longitud=estacion.Longitud;
                estacionEncontrada.Municipio=estacion.Municipio;
                estacionEncontrada.Departamento=estacion.Departamento;
                estacionEncontrada.FechaMontaje=estacion.FechaMontaje;
                estacionEncontrada.TecnicoMantenimiento=estacion.TecnicoMantenimiento;
                estacionEncontrada.PersonalMonitoreo=estacion.PersonalMonitoreo;
                _appContext.SaveChanges();
            }
            return estacionEncontrada;
        }

        Estacion IRepositorioEstacion.GetEstacion(string codigoEstacion)
        {
          var estacionEncontrada=_appContext.Estaciones.FirstOrDefault(p=> p.Codigo==codigoEstacion);
          return estacionEncontrada;  
        }

        void IRepositorioEstacion.DeleteEstacionxId(int id)
        {
           var estacionEncontrada=_appContext.Estaciones.FirstOrDefault(p=> p.Id==id); 
           if(estacionEncontrada!=null)
           {
            _appContext.Estaciones.Remove(estacionEncontrada);
            _appContext.SaveChanges();
           }
        }

        void IRepositorioEstacion.DeleteEstacion(string codigoEstacion)
        {
           var estacionEncontrada=_appContext.Estaciones.FirstOrDefault(p=> p.Codigo==codigoEstacion);
           if(estacionEncontrada!=null)
           {
            _appContext.Estaciones.Remove(estacionEncontrada);
            _appContext.SaveChanges();
           }
        }

        Tecnico IRepositorioEstacion.AsignarTecnico(string codigoEstacion,Tecnico tecnico)
        {
            var estacionEncontrada=_appContext.Estaciones.FirstOrDefault(p=> p.Codigo==codigoEstacion);
            if(estacionEncontrada!=null)
            {
                estacionEncontrada.TecnicoMantenimiento=tecnico;
                _appContext.SaveChanges();
                return tecnico;
            }
            else
            {
                return null;
            }
        }

        Coordinador IRepositorioEstacion.AsignarCoordinador(string codigoEstacion,Coordinador coordinador)
        {
            var estacionEncontrada=_appContext.Estaciones.FirstOrDefault(p=> p.Codigo==codigoEstacion);
            if(estacionEncontrada!=null)
            {
                estacionEncontrada.PersonalMonitoreo=coordinador;
                _appContext.SaveChanges();
                return coordinador;
            }
            else
            {
                return null;
            }
        }
       

     Reporte IRepositorioEstacion.AsignarReporte(string codigoEstacion,Reporte reporte)
        {
            var estacionEncontrada=_appContext.Estaciones.FirstOrDefault(p=> p.Codigo==codigoEstacion);
            if(estacionEncontrada!=null)
            {
                estacionEncontrada.Reporte=reporte;
                _appContext.SaveChanges();
                return reporte;
            }
            else
            {   
                return null;
            }
        }
        DatoMeteorologico IRepositorioEstacion.AsignarDato(string codigoEstacion,DatoMeteorologico dato)
        {
            var estacionEncontrada=_appContext.Estaciones.FirstOrDefault(p=> p.Codigo==codigoEstacion);
            if(estacionEncontrada!=null)
            {
                estacionEncontrada.Dato=dato;
                _appContext.SaveChanges();
                return dato;
            }
            else
            {
                return null;
            } 
        }
    }
}