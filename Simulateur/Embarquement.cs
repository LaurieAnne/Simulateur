using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Embarquement : Etat
    {
        List<Client> m_clients; //La liste des clients
        PosCarte m_destination; //La coordonnée de destination
        PosCarte m_depart; //La coordonnée de départ

        public Embarquement(int p_temps, Vehicule p_vehicule) : base(p_temps, p_vehicule) //Constructeur
        {
        }

        public int NbClients
        {
            get {return m_clients.Count; }
        }

        public override string ToString()
        {
            return "Embarquement";
        }
    }
}
