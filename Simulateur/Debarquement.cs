using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Debarquement : Etat //Etat de type Debarquement
    {
        protected int m_nbClients; //Le nombre de clients (passagers ou marchandises) dans l'avion

        /**Constructeur
         * p_nbClients: le nombre de clients à bord
         * p_temps: le temps avant le prochain Etat
         * p_vehicule: référence au véhicule qui contient l'état
         */
        public Debarquement(int p_nbClients, int p_temps, Vehicule p_vehicule) : base(p_temps, p_vehicule) //Constructeur
        {
            m_nbClients = p_nbClients;
        }


        /**Accesseurs
         */
        public int NbClients
        {
            get { return m_nbClients; }
        }

        public override string ToString()
        {
            return "Debarquement";
        }
    }
}
