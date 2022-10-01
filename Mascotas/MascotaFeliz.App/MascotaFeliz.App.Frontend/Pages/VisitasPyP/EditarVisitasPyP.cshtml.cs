using System.Globalization;
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
    public class EditarVisitasPyPModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioHistoria _repoHistoria;
        private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        private readonly IRepositorioVeterinario _repoVeterinario;
        [BindProperty]
        public Mascota mascota { get; set; }
        public Historia historia { get; set; }
        public VisitaPyP visitaPyP { get; set; }
        public Veterinario veterinario { get; set; }
        public IEnumerable<Veterinario> listaVeterinarios {get; set;}

        public EditarVisitasPyPModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();
        }

        public IActionResult OnGet(int? visitaId, int mascotaId)
        {
            mascota = _repoMascota.GetMascota(mascotaId);
            foreach (Veterinario v in listaVeterinarios){
                Console.WriteLine(v.Nombres);
            }

            if (visitaId.HasValue){
                visitaPyP = _repoVisitaPyP.GetVisitaPyP(visitaId.Value);
            }
            else{
                visitaPyP = new VisitaPyP();
            }
            
            if (visitaPyP == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();      
        }
        public IActionResult OnPost(VisitaPyP visitaPyP, int mascotaId)
        {
            
            mascota = _repoMascota.GetMascota(mascotaId);
            if(mascota.Historia == null){
                historia = new Historia();
                historia.fechaInicial = visitaPyP.FechaVisita;
                historia = _repoHistoria.AddHistoria(historia);
                _repoMascota.AsignarHistoria(mascota.Id, historia.Id);
                mascota = _repoMascota.UpdateMascota(mascota);
            }

            if (ModelState.IsValid){
                historia = _repoHistoria.GetHistoria(mascota.Historia.Id);      
                
                if (visitaPyP.Id > 0)
                {
                    visitaPyP.Historia = historia;
                    visitaPyP = _repoVisitaPyP.UpdateVisitaPyP(visitaPyP);
                    _repoVisitaPyP.AsignarHistoria(visitaPyP.Id, historia.Id);
                }
                else
                {
                    visitaPyP = _repoVisitaPyP.AddVisitaPyP(visitaPyP);
                    _repoVisitaPyP.AsignarHistoria(visitaPyP.Id, historia.Id);
                }
                return Page();
            }
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();
            return Page();
        }
    }
}
