using System;
using System.Linq;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public class RepositorioDatoMeteorologico:IRepositorioDatoMeteorologico
    {
        private readonly AppContext _appContext;
        public RepositorioDatoMeteorologico(AppContext appContext)
        {
            _appContext=appContext;
        }

        DatoMeteorologico IRepositorioDatoMeteorologico.AddDatoMeteorologico(DatoMeteorologico datoMeteorologico)
        {
            var datoAgregado=_appContext.DatoMeteorologicos.Add(datoMeteorologico);
            _appContext.SaveChanges();
            return datoAgregado.Entity;
        }

        DatoMeteorologico IRepositorioDatoMeteorologico.GetDatoMeteorologicoxId(int id)
        {
            var datoEncontrado=_appContext.DatoMeteorologicos.FirstOrDefault(p=> p.Id==id);
            return datoEncontrado;
        }
    }
}