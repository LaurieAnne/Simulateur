using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class Vol : Etat
    {
        Aeroport m_aeDepart; //La coordonnée de départ
        PosCarte m_posActuelle; //La coordonnée actuelle

        public Vol(Aeroport p_aeDepart, PosCarte p_posActuelle, int p_temps) : base(p_temps) //Constructeur
        {
            m_aeDepart = p_aeDepart;
            m_posActuelle = p_posActuelle;
        }
    }
}
