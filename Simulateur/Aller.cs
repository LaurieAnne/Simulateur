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
        Aeroport m_aeDestination; //La coordonnée de destination

        public Aller(Aeroport p_aeDepart, PosCarte p_posActuelle, int p_nbClients, int p_temps, Aeroport p_aeDestination) : base(p_aeDepart, p_posActuelle, p_temps) //Constructeur
        {
            m_aeDestination = p_aeDestination;
            m_nbClients = p_nbClients;
        }


        public int NbClients
        {
            get { return m_nbClients; }
        }

        public override void Avance(int p_val, PosCarte p_depart, PosCarte p_destination)
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
