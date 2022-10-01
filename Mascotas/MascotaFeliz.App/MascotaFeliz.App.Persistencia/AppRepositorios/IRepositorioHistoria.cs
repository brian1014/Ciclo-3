using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioHistoria
    {
        Historia AddHistoria(Historia historia);
        Historia GetHistoria(int idHistoria);
        //VisitaPyP UpdateHistoria(int idHistoria, VisitaPyP visitaPyP);
        IEnumerable<VisitaPyP> GetAllVisitas(int idHistoria);
        //VisitaPyP AsignarVisitaPyP(int idHistoria, int idVisitaPyP);
    }
}