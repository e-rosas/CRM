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
        //Variable que se le asignara el tipo de disponibilidad de red.
        public bool Disponibilidad;
        public bool DisponibilidadInternet;
        //Estado default: False
        //Constructor inicializa evento si hay un cambio en la red e internet.
        public Red()
        {
            NetworkChange.NetworkAvailabilityChanged += new
            NetworkAvailabilityChangedEventHandler(CambioDisponibilidad);
            HayConexion();
        }

        //Recorre la lista de observador Actualizar para verificar disponibilidad
        public void NotificarObservadores()
        {
            foreach(Observador o in observadores)
            {
                o.Actualizar(Disponibilidad , DisponibilidadInternet);
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
        
        //Asignacion de estado de la red cuando detecta un cambio del evento
        private void CambioDisponibilidad(object sender, NetworkAvailabilityEventArgs e)
        {
            //Disponibilidad = e.IsAvailable;
            HayConexion();
            //NotificarObservadores();
                      
        }

        //Set Estado , Si el estado cambia y se le asigna valor me notifica a mi Observador ...
        public void HayConexion()
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry(Properties.Settings.Default.Servidor);
                Disponibilidad = true;
            }
            catch
            {
                Disponibilidad = false;
            }


            try
            {
                IPHostEntry host = Dns.GetHostEntry("www.google.com");
                DisponibilidadInternet = true;
            }
            catch
            {
                DisponibilidadInternet = false;
            }

            NotificarObservadores();
        }


    }
}
