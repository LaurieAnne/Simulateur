using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Debarquement : Etat
    {
        int m_nbClients; //Le nombre de clients (passagers ou marchandises) dans l'avion

        public Debarquement(int p_nbClients, int p_temps) : base(p_temps) //Constructeur
        {
            m_nbClients = p_nbClients;
        }

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
