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
    public class AdminModel : PageModel
    {
        [BindProperty]
        public Administrador administrador{get;set;}

        public static IRepositorioAdministrador _repo=new RepositorioAdministrador(new Primero.App.Persistencia.AppContext());
        public void OnGet()
        {
        }
        public void OnPost()
        {

        }
        public IActionResult OnPostEnlace()
        {
            string Pagina;
            Pagina="Admin";
            //despues de la validacion va a desplegar los enlaces pertinentes
           if( _repo.GetAdministradorxCedPass(administrador.Cedula,administrador.Password)!=null)
           {
            if(_repo.GetAdministradorxCedPass(administrador.Cedula,administrador.Password).Roll=="Tecnico")
            {
                Pagina="CrearEstacion";
                //return RedirectToPage("CrearEstacion");
            }
            if(_repo.GetAdministradorxCedPass(administrador.Cedula,administrador.Password).Roll=="Rh")
            {
                Pagina="CrearTecnico";
                //return RedirectToPage("CrearTecnico");
            }
           }
           else
           {
                Pagina="Admin";
             //return Page();
           }
            return  RedirectToPage(Pagina);
            
        }
    }
}
