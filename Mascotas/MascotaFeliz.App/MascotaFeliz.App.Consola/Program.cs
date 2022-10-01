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
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddDueno();            
            var updateDueno = new Dueno
            {
                Id = 1,
                Nombres = "Juan",
                Apellidos = "Sin Miedo",
                Direccion = "Bajo un Puente",
                Telefono = "124598657",
                Correo = "juansinmiedo@gmail.com"
            };
            var updateMascota = new Mascota
            {
                Id = 1,
                Nombre = "Bruno",
                Color = "Negro",
                Especie = "Perro",
                Raza = "Chihuahua",
                
            };
            var updateVeterinario = new Veterinario
            {
                Id = 7,
                Nombres = "Orlando",
                Apellidos = "Mesa",
                Direccion = "Calle 88 # 47-21",
                Telefono = "3115984217",
                TarjetaProfesional = "BY250-174860"
                
            };
            //UpdateDueno(updateDueno);
            //BuscarDueno(1);
            //ListarDuenos();
            //DeleteDueno(9);
            //AddVeterinario();
            //UpdateVeterinario(updateVeterinario);
            //BuscarVeterinario(7);
            //ListarVeterinarios();
            //DeleteVeterinario(8);
            //AddMascota();
            //UpdateMascota(updateMascota);
            //BuscarMascota(1);
            //ListarMascotas();
            //DeleteMascota(3);
            AddHistoria();
            
        }
        //MÉTODOS DUEÑO
        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                //Cedula = "1212",
                Nombres = "Carlos",
                Apellidos = "Bastidas",
                Direccion = "Bajo un carro",
                Telefono = "12459833",
                Correo = "carlosbastidas@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }
        
        private static void UpdateDueno(Dueno dueno)
        {
        
            _repoDueno.UpdateDueno(dueno);
            
        }

        private static void BuscarDueno(int idDueno)
        {
           var dueno = _repoDueno.GetDueno(idDueno);
           Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo);
        }

         private static void ListarDuenos()
        {
            var duenos = _repoDueno.GetAllDuenos();
            foreach (Dueno d in duenos)
            {
                Console.WriteLine(d.Nombres + " " + d.Apellidos + " " + d.Direccion + " " + d.Telefono + " " + d.Correo);
            }
                       
        }

        private static void DeleteDueno(int idDueno)
        {
            _repoDueno.DeleteDueno(idDueno);
        }

        // MÉTODOS VETERINARIO
        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                //Cedula = "1212",
                Nombres = "Franco",
                Apellidos = "Carrasquilla",
                Direccion = "Calle 88 # 47-21",
                Telefono = "3115984217",
                TarjetaProfesional = "BY250-174859"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void UpdateVeterinario(Veterinario veterinario)
        {
        
            _repoVeterinario.UpdateVeterinario(veterinario);
            
        }
        
        private static void BuscarVeterinario(int idVeterinario)
        {
           var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
           Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos + " " + veterinario.Direccion + " " + veterinario.Telefono + " " + veterinario.TarjetaProfesional);
        }

         private static void ListarVeterinarios()
        {
            var veterinarios = _repoVeterinario.GetAllVeterinarios();
            foreach (Veterinario v in veterinarios)
            {
                Console.WriteLine(v.Nombres + " " + v.Apellidos + " " + v.Direccion + " " + v.Telefono + " " + v.TarjetaProfesional);
            }
                       
        }

        private static void DeleteVeterinario(int idVeterinario)
        {
            _repoVeterinario.DeleteVeterinario(idVeterinario);
        }
        

        // MÉTODOS MASCOTAS
        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                Nombre = "Agata",
                Color = "Blanco",
                Especie = "Gata",
                Raza = "Criolla"
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void UpdateMascota(Mascota mascota)
        {
            _repoMascota.UpdateMascota(mascota);
        }
        
        private static void BuscarMascota(int idMascota)
        {
           var mascota = _repoMascota.GetMascota(idMascota);
           Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza + mascota.Dueno);
        }

        private static void ListarMascotas()
        {
            var mascotas = _repoMascota.GetAllMascotas();
            foreach (Mascota m in mascotas)
            {
                Console.WriteLine(m.Nombre + " " + m.Color + " " + m.Especie + " " + m.Raza);
            }
                         
        }

        private static void DeleteMascota(int idMascota)
        {
            _repoMascota.DeleteMascota(idMascota);
        }

        private static void AddHistoria()
        {
            var historia = new Historia
            {
                fechaInicial = new DateTime(2022, 05, 18)
            };
            _repoHistoria.AddHistoria(historia);
            Console.WriteLine(historia.fechaInicial + " " + historia.Id);
        }

        /*private static void AsignarVisitaPyP(int idHistoria)
        {
            var historia = _repoHistoria.GetHistoria(idHistoria);
            if (historia != null)
            {
                if (historia.VisitasPyP != null)
                {
                    historia.VisitasPyP.Add(new VisitaPyP { FechaVisita = new DateTime(2020, 01, 01), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", CedulaVeterinario = "123", Recomendaciones = "Dieta extrema"});
                }
                else
                {
                    historia.VisitasPyP = new List<VisitaPyP>{
                        new VisitaPyP{FechaVisita = new DateTime(2020, 01, 01), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", CedulaVeterinario = "123", Recomendaciones = "Dieta extrema" }
                    };
                }
                _repoHistoria.UpdateHistoria(historia);
            }
        } */   
    }
}
      
        


