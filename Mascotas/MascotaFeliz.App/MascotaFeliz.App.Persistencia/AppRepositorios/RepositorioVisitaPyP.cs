using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia

{
    public class RepositorioVisitaPyP: IRepositorioVisitaPyP
    {
        /// <summary>
        /// Referencia al contexto de Historia
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioVisitaPyP(AppContext appContext)
        {
            _appContext = appContext;
        }

        
         public VisitaPyP AddVisitaPyP(VisitaPyP visitaPyP)
        {
            var visitaAdicionado = _appContext.VisitasPyP.Add(visitaPyP);
            _appContext.SaveChanges();
            return visitaAdicionado.Entity;
        }

        public VisitaPyP GetVisitaPyP(int idVisitaPyP)
        {
            return _appContext.VisitasPyP.FirstOrDefault(v => v.Id == idVisitaPyP);
        }

        public Historia AsignarHistoria(int idVisitaPyP, int idHistoria)
        {
            var visitaPyPEncontrada = _appContext.VisitasPyP.FirstOrDefault(v => v.Id == idVisitaPyP);
            if (visitaPyPEncontrada != null){
                var historiaEncontrada = _appContext.Historias.FirstOrDefault(h => h.Id == idHistoria);
                if (historiaEncontrada != null)
                {
                visitaPyPEncontrada.Historia = historiaEncontrada;
                _appContext.SaveChanges();
                }
                return historiaEncontrada;
            }
            return null;            
        }

        public VisitaPyP UpdateVisitaPyP(VisitaPyP visitaPyP)
        {
            var visitaPyPEncontrada = _appContext.VisitasPyP.FirstOrDefault(v => v.Id == visitaPyP.Id);
            if (visitaPyPEncontrada != null)
            {
                visitaPyPEncontrada.FechaVisita = visitaPyP.FechaVisita;
                visitaPyPEncontrada.Temperatura = visitaPyP.Temperatura;
                visitaPyPEncontrada.Peso = visitaPyP.Peso;
                visitaPyPEncontrada.VeterinarioId = visitaPyP.VeterinarioId;
                visitaPyPEncontrada.FrecuenciaRespiratoria = visitaPyP.FrecuenciaRespiratoria;
                visitaPyPEncontrada.FrecuenciaCardiaca = visitaPyP.FrecuenciaCardiaca;
                visitaPyPEncontrada.EstadoAnimo = visitaPyP.EstadoAnimo;
                visitaPyPEncontrada.Recomendaciones = visitaPyP.Recomendaciones;
                _appContext.SaveChanges();
            }
            return visitaPyPEncontrada;
        }

        /*public Veterinario AsignarVeterinario(int idVisitaPyP, int idVeterinario)
        {
            Console.WriteLine(idVisitaPyP);
            var visitaPyPEncontrada = _appContext.VisitasPyP.FirstOrDefault(v => v.Id == idVisitaPyP);
            if (visitaPyPEncontrada != null){
                var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v => v.Id == idVeterinario);
                Console.WriteLine(veterinarioEncontrado.Id);
                 if (veterinarioEncontrado != null)
                {
                visitaPyPEncontrada.Veterinario = veterinarioEncontrado;
                _appContext.SaveChanges();
                }
                return veterinarioEncontrado;
            }
            return null;            
        }*/
    }
}