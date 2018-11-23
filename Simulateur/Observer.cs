using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Observer : Vol
    {
        PosCarte m_posDestination; //La coordonnée de destination

        public Observer(Aeroport p_aeDepart, PosCarte p_posActuelle, int p_temps, PosCarte p_posDestination) : base(p_aeDepart,  p_posActuelle, p_temps) //Constructeur
        {
            m_posDestination = p_posDestination;
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
            return "Observation";
        }
    }
}
