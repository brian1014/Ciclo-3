using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListaVisitasPyPModel : PageModel
    {
        private readonly IRepositorioHistoria _repoHistoria;
        private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioVeterinario _repoVeterinario;

        public IEnumerable<VisitaPyP> ListaVisitasPyP {get;set;}
        public Mascota mascota { get; set; }
        public Veterinario veterinario { get; set; }
        public string action;
        public Veterinario veterinarioVisita;
        
        public ListaVisitasPyPModel()
        {
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }

        public void OnGet(int mascotaId)
        {
            mascota = _repoMascota.GetMascota(mascotaId);

            if(mascota.Historia != null){
                action = "Registrar Visita";
                ListaVisitasPyP = _repoHistoria.GetAllVisitas(mascota.Historia.Id);
                foreach (VisitaPyP v in ListaVisitasPyP){
                    veterinarioVisita =_repoVeterinario.GetVeterinario(v.VeterinarioId);
                    v.Veterinario = veterinarioVisita;
                }
            } else{
                action = "Crear Historia";
                ListaVisitasPyP = Enumerable.Empty<VisitaPyP>();
            }
        }
    }
}
