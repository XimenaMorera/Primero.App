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
    public class CrearTecnicoModel : PageModel
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
        public IActionResult OnPostCrearTecnico()
        {
            if(_repo.AddTecnico(tecnico)!=null)
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