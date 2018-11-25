using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class Vol : Etat
    {
        PosCarte m_posDepart; //La coordonnée de départ
        PosCarte m_posActuelle; //La coordonnée actuelle
        PosCarte m_posDestination; //La coordonnée de destination

        public Vol(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps) : base(p_temps) //Constructeur
        {
            m_posDepart = p_posDepart;
            m_posActuelle = p_posActuelle;
            m_posDestination = p_posDestination;
        }
    }
}
