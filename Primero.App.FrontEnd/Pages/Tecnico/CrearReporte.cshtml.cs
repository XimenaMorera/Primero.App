using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Primero.App.Dominio;
using Primero.App.Persistencia;

namespace MyApp.Namespace
{
    public class CrearReporteModel : PageModel
    {
        [BindProperty]
        public Reporte reporte{get;set;}
        [BindProperty]
        public Estacion estacion{get;set;}
        public static IRepositorioReporte _repo=new RepositorioReporte(new Primero.App.Persistencia.AppContext());
        public static IRepositorioEstacion _repo2=new RepositorioEstacion(new Primero.App.Persistencia.AppContext());
        public void OnGet()
        {
        }
        public void OnPost()
        {

        }
        public IActionResult OnPostCrearReporte()
        {
            string pagina="CrearReporte";
            var R=_repo.AddReporte(reporte);
            if(R!=null)
            {
                if(_repo2.AsignarReporte(estacion.Codigo,R)!=null)
                {
                pagina="Tecnico";
                }
            }
            return RedirectToPage(pagina);
        }
    }
}