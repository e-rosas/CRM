using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    public interface Subject
    {
        void RegistrarObservador(Observador o);
        void RemoverObservador(Observador o);
        void NotificarObservadores();

    }
}
