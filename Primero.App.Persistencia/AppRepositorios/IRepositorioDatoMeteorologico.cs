using System;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public interface IRepositorioDatoMeteorologico
    {
        DatoMeteorologico AddDatoMeteorologico(DatoMeteorologico datoMeteorologico);
        DatoMeteorologico GetDatoMeteorologicoxId(int id);        
    }
}