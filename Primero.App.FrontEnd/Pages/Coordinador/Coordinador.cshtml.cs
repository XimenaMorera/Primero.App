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
    public class CoordinadorModel : PageModel
    {
        [BindProperty]
        public Coordinador coordinador{get;set;}

        public static IRepositorioCoordinador _repo=new RepositorioCoordinador(new Primero.App.Persistencia.AppContext());
        public void OnGet()
        {
        }
        public void OnPost()
        {

        }
        public IActionResult OnPostValidacion()
        {
            string pagina="";
            if(_repo.GetCoordinadorxCedPass(coordinador.Cedula,coordinador.Password)!=null)
            {
                pagina="ConsCoord";
            }
            else
            {
                pagina="Coordinador";
            }
            return RedirectToPage(pagina); 
        }
    }
}
