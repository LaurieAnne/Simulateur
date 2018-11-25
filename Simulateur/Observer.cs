using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Observer : Vol
    {

        public Observer(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps) : base(p_posDepart,  p_posActuelle, p_posDestination, p_temps) //Constructeur
        {
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
