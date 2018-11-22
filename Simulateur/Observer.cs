using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Observer : Vol
    {
        public Observer(PosCarte p_destination, PosCarte p_depart, PosCarte p_posActuelle, int p_temps) : base(p_destination, p_depart, p_posActuelle, p_temps) //Constructeur
        {
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
            return "Observation";
        }
    }
}
