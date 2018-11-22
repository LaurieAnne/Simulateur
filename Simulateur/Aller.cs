using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Aller : Vol
    {
        int m_nbClients; //Le nombre de clients (passagers ou marchandises) dans l'avion

        public Aller(PosCarte p_destination, PosCarte p_depart, PosCarte p_posActuelle, int p_nbClients, int p_temps) : base(p_destination, p_depart, p_posActuelle, p_temps) //Constructeur
        {
            m_nbClients = p_nbClients;
        }

        public int NbClients
        {
            get { return m_nbClients; }
        }

        public override void Avance(int p_val)
        {
            //Changer la position sur la carte
            //Diminuer le temps
            m_temps -= p_val;
            if (m_temps <= 0)
            {
                onEtatFini();
            }
        }

        public override string ToString()
        {
            return "Aller";
        }
    }
}
