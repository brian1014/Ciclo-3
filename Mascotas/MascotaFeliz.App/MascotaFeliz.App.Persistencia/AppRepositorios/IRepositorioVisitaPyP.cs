using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVisitaPyP
    {
        VisitaPyP AddVisitaPyP(VisitaPyP visitaPyP);
        VisitaPyP GetVisitaPyP(int idVisitaPyP);
        Historia AsignarHistoria(int idVisitaPyP, int idHistoria);
        VisitaPyP UpdateVisitaPyP(VisitaPyP visitaPyP);
    }
}