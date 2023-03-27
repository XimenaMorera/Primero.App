using System;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public interface IRepositorioReporte
    {
        Reporte AddReporte(Reporte reporte);
        void DeleteReportexId(int id);
        Reporte GetReportexId(int id);
        Reporte UpdateReporte(Reporte reporte);
        
    }
}