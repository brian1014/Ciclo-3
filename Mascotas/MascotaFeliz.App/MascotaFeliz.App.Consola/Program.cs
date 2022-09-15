using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddDueno();
            //AddVeterinario();
            //AddMascota();
            //BuscarMascota(2);
            //BuscarDueno();
            //BuscarVeterinario();
            //ListarMascotas();
            //ListarDuenos();
            //ListarVeterinarios();
            //DeleteDueno();
            //DeleteMascota();
            //DeleteVeterinario();
            
            
        }
        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                //Cedula = "1212",
                Nombres = "Juan",
                Apellidos = "Sin Miedo",
                Direccion = "Bajo un puente",
                Telefono = "1234567891",
                Correo = "juansinmiedo@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }
        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                //Cedula = "1212",
                Nombres = "Carlos",
                Apellidos = "Rodriguez",
                Direccion = "Calle 27 # 46-90",
                Telefono = "3115987412",
                TarjetaProfesional = "CN250-174859"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }
        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                Nombre = "Candy",
                Color = "Blanco",
                Especie = "Perro",
                Raza = "Criolla"
            };
            _repoMascota.AddMascota(mascota);
        }
        
        private static void BuscarMascota(int idMascota)
        {
           var mascota = _repoMascota.GetMascota(idMascota);
           Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza);
        }
        
        private static void BuscarDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo);
        }

        private static void BuscarVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos + " " + veterinario.Direccion + " " + veterinario.Telefono + " " + veterinario.TarjetaProfesional);
        }
        
        
        
        private static void ListarMascotas()
        {
            var mascotas = _repoMascota.GetAllMascotas();
            foreach (Mascota m in mascotas)
            {
                Console.WriteLine(m.Nombre + " " + m.Color + " " + m.Especie + " " + m.Raza);
            }
                         
        }
        
        private static void ListarDuenos()
        {
            var duenos = _repoDueno.GetAllDuenos();
            foreach (Dueno p in duenos)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos + " " + p.Direccion + " " + p.Telefono + " " + p.Correo);
            }

        }

        private static void ListarVeterianos()
        {
            var veterinario = _repoVeterinario.GetAllVeterinarios();

            foreach (Veterinario p in veterinario)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos + " " + p.Direccion + " " + p.Telefono + " " + p.TarjetaProfesional + " " + p.TarjetaProfesional);
            }

        }
        
        private static void  DeleteDueno()
        {
          _repoDueno.DeleteDueno(2);  //Poner el ID de la BD
            Console.WriteLine( "Dueño borrado");
        }

        private static void  DeleteMascota()
        {
          _repoMascota.DeleteMascota(1);  //Poner el ID de lB
            Console.WriteLine( "mascota borrado");
        }

        
        private static void  DeleteVeterinario()
        {
          _repoVeterinario.DeleteVeterinario(1);  //Poner el ID de la BD
            Console.WriteLine( "Veterinario borrado");
        }
        
    }
}
      
        


