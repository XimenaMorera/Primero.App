using System;
using Primero.App.Dominio;
using Primero.App.Persistencia;
namespace Primero.App.Consola
{
    class Program
    {
         private static IRepositorioTecnico _repo4=new RepositorioTecnico(new Primero.App.Persistencia.AppContext());
        
         private static IRepositorioEstacion _repo3=new RepositorioEstacion(new Primero.App.Persistencia.AppContext());
        private static IRepositorioPersona _repo2=new RepositorioPersona(new Primero.App.Persistencia.AppContext());
        private static IRepositorioAdministrador _repo=new RepositorioAdministrador(new Primero.App.Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("inicio pruebas");
            Console.WriteLine("inicio insertar registro");
            Insertar();
            //AgregarPersonalEstacion();
            Console.WriteLine("fin insertar registro");
            /*Console.WriteLine("inicio consultar registro");
            Consultar();
            Console.WriteLine("fin insertar registro");
            Console.WriteLine("inicio borrar registro");
            Borrar();
            Console.WriteLine("fin borrar registro");*/
            Console.WriteLine("fin pruebas");
        }

        private static void Insertar()
        {
            //var p=new Persona
            var p=new Administrador
            {
                Cedula="654321",
                Nombre="Administrador2",
                Apellido="Prueba2",
                Telefono="654321",
                Password=654321,
                Roll="Tecnico"
                
            };
           // _repo.AddPersona(p);
           _repo.AddAdministrador(p);
        }

        

       /* private static void Consultar()
        {
            var r=_repo.GetTecnicoxId(2);
            Console.WriteLine("registro consultado:cc"+r.Cedula+" nombre:"+r.Nombre+" "+r.Apellido+" telefeno:"+r.Telefono);
        }

        private static void Borrar()
        {
            _repo2.DeletePersonaxId(1);
        }*/

      /*  private static void AgregarPersonalEstacion()
        {
            var tecnico=new Tecnico
             {
                Cedula="111111",
                Nombre="Tecnico",
                Apellido="Prueba",
                Telefono="34",
                TarjetaProfesional="ensayo"
            };
            _repo4.AddTecnico(tecnico);
            Console.WriteLine("tecnico adicionado");
            Console.WriteLine("consulta de tecnico");
            var T=_repo4.GetTecnicoxCed("111111");
            Console.WriteLine("asignacion a la estacion");
            if(_repo3.AsignarTecnico("vg_1098",T)!=null)
            {
                Console.WriteLine("asignacion exitosa");
            }
            else
            {
                Console.WriteLine("problemas de asignación");
            }

        }*/
    }
}
