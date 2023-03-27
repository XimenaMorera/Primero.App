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
    public class CrearCoordinadorModel : PageModel
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
        public IActionResult OnPostCrearCoordinador()
        {
            if(_repo.AddCoordinador(coordinador)!=null)
            {
                return RedirectToPage("Admin");
            }
            else
            {
                return Page();
            }
        }
    }
}