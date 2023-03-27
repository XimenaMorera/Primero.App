using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Primero.App.Dominio;
using Primero.App.Persistencia;
using Microsoft.EntityFrameworkCore;
namespace MyApp.Namespace
{
    public class CrearEstacionModel : PageModel
    {
        [BindProperty]
        public Estacion estacion{get;set;}
        [BindProperty]
        public Tecnico tecnico{get;set;}
        [BindProperty]
        public Coordinador coordinador{get;set;}
        public string msj{get;set;}
        public string msj2{get;set;}
        public string idTecnico{get;set;}
        public string idCoordinador{get;set;}
        public static IRepositorioEstacion _repo1=new RepositorioEstacion(new Primero.App.Persistencia.AppContext());
        public static IRepositorioTecnico _repo2=new RepositorioTecnico(new Primero.App.Persistencia.AppContext());
        public static IRepositorioCoordinador _repo3=new RepositorioCoordinador(new Primero.App.Persistencia.AppContext());
        public static IRepositorioAdministrador _repo=new RepositorioAdministrador(new Primero.App.Persistencia.AppContext());
        public void OnGet()
        {
           idTecnico="Hola Tecnico y Coordinador";
           idCoordinador="Ingrese la Informacion";
           msj="Bienvenidos";
           msj2="";
        }
        public void OnPost()
        {

        }
        public void OnPostCrearEstacion()
        {
            estacion=_repo1.AddEstacion(estacion);
            
        }

        public void OnPostAsignarPersonal()
        {
            var T=_repo2.GetTecnicoxCed(tecnico.Cedula);
            var C=_repo3.GetCoordinadorxCed(coordinador.Cedula);
            if(_repo1.AsignarTecnico(estacion.Codigo,T)!=null)
            {
                idTecnico=""+T.Id;
                msj="Asignacion tecnico Exitosa";
            }
            else
            {
                msj="Error asignacion tecnico";
            }
          
            if(_repo1.AsignarCoordinador(estacion.Codigo,C)!=null)
            {
                idCoordinador=""+C.Id;
                msj2="Asignacion Coordinador Exitosa";
            }
              else
            {
                msj2="Error asignacion Coordinador";
            }

        }
    }
}