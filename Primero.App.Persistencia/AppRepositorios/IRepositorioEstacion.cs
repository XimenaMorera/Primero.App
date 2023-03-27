using System;
using Primero.App.Dominio;

namespace Primero.App.Persistencia
{
    public interface IRepositorioEstacion
    {
        Estacion AddEstacion(Estacion estacion);
        Estacion UpdateEstacion(Estacion estacion);
        void DeleteEstacionxId(int id);
        void DeleteEstacion(string codigoEstacion);
        Estacion GetEstacion(string codigoEstacion);
        Tecnico AsignarTecnico(string codigoEstacion,Tecnico tecnico);
        Coordinador AsignarCoordinador(string codigoEstacion,Coordinador coordinador);
        Reporte AsignarReporte(string codigoEstacion,Reporte reporte);
        DatoMeteorologico AsignarDato(string codigoEstacion,DatoMeteorologico dato);
    }
}