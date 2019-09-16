using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace CRM
{
    public class Red : Subject
    {
        private List<Observador> observadores = new List<Observador>();
        public bool Disponibilidad;
        public Red()
        {
            NetworkChange.NetworkAvailabilityChanged += new
            NetworkAvailabilityChangedEventHandler(CambioDisponibilidad);
        }

        public void NotificarObservadores()
        {
            foreach(Observador o in observadores)
            {
                o.Actualizar();
            }
        }

        public void RegistrarObservador(Observador o)
        {
            observadores.Add(o);
        }

        public void RemoverObservador(Observador o)
        {
            if (observadores.Contains(o))
            {
                observadores.Remove(o);
            }
        }

        private void CambioDisponibilidad(object sender, NetworkAvailabilityEventArgs e)
        {
            Disponibilidad = e.IsAvailable;
            NotificarObservadores();
                      
        }
    }
}
