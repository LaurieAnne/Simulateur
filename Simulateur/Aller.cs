using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Aller : Vol
    {
        protected int m_nbClients; //Le nombre de clients (passagers ou marchandises) dans l'avion

        public Aller(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_nbClients, int p_temps, Vehicule p_vehicule) : base(p_posDepart, p_posActuelle, p_posDestination, p_temps, p_vehicule) //Constructeur
        {
            m_nbClients = p_nbClients;
        }


        public int NbClients
        {
            get { return m_nbClients; }
        }

        public override void Avance(int p_val)
        {
            if (p_val > m_temps)
            {
                m_surplus = p_val - m_temps;
                onEtatFini();
            }
            else { 
                //Ajuster la position actuelle de l'avion
                m_posActuelle.changerPosition(m_posDepart, m_posDestination, m_vehicule.KMH, p_val);

                string posActuelle = m_posActuelle.Coords();
                string posDestination = m_posDestination.Coords();

                if (posActuelle == posDestination)
                {
                    onEtatFini();//Avertir les abonnées que l'Etat est terminé
                }
            }
        }

        public override string ToString()
        {
            return "Aller";
        }
    }
}
