using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVeterinario
    {       
        Veterinario AddVeterinario(Veterinario veterinario);
        IEnumerable<Veterinario> GetAllVeterinarios();
        Veterinario GetVeterinario(int idVeterinario);
        Veterinario UpdateVeterinario(Veterinario veterinario);
        void DeleteVeterinario(int idVeterinario);
        IEnumerable<Veterinario> GetVeterinariosPorFiltro(string filtro);
    }
}