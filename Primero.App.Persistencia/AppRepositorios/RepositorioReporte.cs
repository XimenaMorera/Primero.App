using System;
using System.Linq;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public class RepositorioReporte:IRepositorioReporte
    {
        private readonly AppContext _appContext;
        public RepositorioReporte(AppContext appContext)
        {
            _appContext=appContext;
        }

        Reporte IRepositorioReporte.AddReporte(Reporte reporte)
        {
            var reporteAgregado=_appContext.Reportes.Add(reporte);
            _appContext.SaveChanges();
            return reporteAgregado.Entity;
        }

        Reporte IRepositorioReporte.UpdateReporte(Reporte reporte)
        {
            var reporteEncontrado=_appContext.Reportes.FirstOrDefault(p=> p.Id==reporte.Id);
            if(reporteEncontrado!=null)
            {
                reporteEncontrado.Descripcion=reporte.Descripcion;
                
            }
            return reporteEncontrado;
        }

        void IRepositorioReporte.DeleteReportexId(int id)
        {
            var reporteEncontrado=_appContext.Reportes.FirstOrDefault(p=> p.Id==id);
            if(reporteEncontrado!=null)
            {
                _appContext.Reportes.Remove(reporteEncontrado);
                _appContext.SaveChanges();
            }
        }

        Reporte IRepositorioReporte.GetReportexId(int id)
        {
            var reporteEncontrado=_appContext.Reportes.FirstOrDefault(p=> p.Id==id); 
            return reporteEncontrado;
        }
    }
}
