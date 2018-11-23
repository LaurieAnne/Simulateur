using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class Vol : Etat
    {
        PosCarte m_destination; //La coordonnée de destination
        PosCarte m_depart; //La coordonnée de départ
        PosCarte m_posActuelle; //La coordonnée actuelle

        public Vol(PosCarte p_destination, PosCarte p_depart, PosCarte p_posActuelle, int p_temps) : base(p_temps) //Constructeur
        {
            m_destination = p_destination;
            m_depart = p_depart;
            m_posActuelle = p_posActuelle;
        }
    }
}
