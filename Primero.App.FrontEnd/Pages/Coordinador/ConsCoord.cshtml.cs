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
    
    public class ConsCoordModel : PageModel
    {
        [BindProperty]
        public Estacion estacion{get;set;}

        public string nombreT{get;set;}
        public string apellidoT{get;set;}
        public string telefonoT{get;set;}
        public string descripcionR{get;set;}
        public string msj{get;set;}
        public string codigoE{get;set;}
        public float latitudE{get;set;}
        public float longitudE{get;set;}
        public string municipioE{get;set;}
        public string departamentoE{get;set;}
        public float valorD{get;set;}
        public string tipoD{get;set;}

        public static IRepositorioEstacion _repo=new RepositorioEstacion(new Primero.App.Persistencia.AppContext());
        public static IRepositorioDatoMeteorologico _repo2=new RepositorioDatoMeteorologico(new Primero.App.Persistencia.AppContext());
        
        public void OnGet()
        {
            codigoE="codigo estación consultar";  
            latitudE=0; 
            longitudE=0;
            municipioE="municipio estacion consultar";
            departamentoE="depratamento estacion consultar";
        }

        public void OnPost()
        {

        }
        public void OnPostConsEsta()
        {
            estacion=_repo.GetEstacion(estacion.Codigo);
            if(estacion!=null)
            {
              codigoE=estacion.Codigo;  
              latitudE=estacion.Latitud; 
              longitudE=estacion.Longitud;
              municipioE=estacion.Municipio;
              departamentoE=estacion.Departamento;
             /* nombreT=estacion.TecnicoMantenimiento.Nombre;
              apellidoT=estacion.TecnicoMantenimiento.Apellido;
              telefonoT=estacion.TecnicoMantenimiento.Telefono;*/
              descripcionR=estacion.Reporte.Descripcion;
            }
            else
            {
              codigoE="";  
              latitudE=0; 
              longitudE=0;
              municipioE="";
              departamentoE=""; 
            }
            
        }
        public void OnPostLectDato()
        {
          tipoD="Radiacion";
          Random rnd = new Random();
          valorD= rnd.Next(50);
          
           //valorD=12.5F;
           int ntd=rnd.Next(4);
           if(ntd==1)
           {
            tipoD="Temperatura";
           }
           if(ntd==2)
           {
            tipoD="humedad";
           }
           if(ntd==3)
           {
            tipoD="presion";
           }
           var D=new DatoMeteorologico
           {
            FechaHora="22/09/2022:6.44",
            Valor=valorD,
            Tipo=tipoD
           };
           if(_repo2.AddDatoMeteorologico(D)!=null)
           {
             if(_repo.AsignarDato(estacion.Codigo,D)!=null)
             {
              msj="asignación de dato correcta";
             }
             else
             {
              msj="problemas asignación dato";
             }
           }
        }
    }
}