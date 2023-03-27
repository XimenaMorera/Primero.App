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
    public class TecnicoModel : PageModel
    {
        [BindProperty]
        public Tecnico tecnico{get;set;}
        public static IRepositorioTecnico _repo=new RepositorioTecnico(new Primero.App.Persistencia.AppContext());
        public void OnGet()
        {
        }
        public void OnPost()
        {

        }
        public IActionResult OnPostLoginTecnico()
        {
            string pagina="Tecnico";
            if(_repo.GetTecnicoxCed(tecnico.Cedula)!=null)
            {
                if(_repo.GetTecnicoxCed(tecnico.Cedula).TarjetaProfesional==tecnico.TarjetaProfesional)
                {
                    pagina="CrearReporte";
                }
            }
            return RedirectToPage(pagina);
        }
    }
}
