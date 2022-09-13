using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioMascota
    {       
        Mascota AddMascota(Mascota mascota);
        IEnumerable<Mascota> GetAllMascotas();
        Mascota GetMascota(int idMascota);
    }
}