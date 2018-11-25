using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class Vol : Etat
    {
        protected PosCarte m_posDepart; //La coordonnée de départ
        protected PosCarte m_posActuelle; //La coordonnée actuelle
        protected PosCarte m_posDestination; //La coordonnée de destination

        public Vol(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, Vehicule p_vehicule) : base(p_temps, p_vehicule) //Constructeur
        {
            m_posDepart = p_posDepart;
            m_posActuelle = p_posActuelle;
            m_posDestination = p_posDestination;
        }

        public PosCarte PositionActuelle
        {
            get { return m_posActuelle; }
            set { m_posActuelle = value; }
        }

        public override string obtenirPosVehicule() //Obtenir les stats de pos véhicule
        {
            return m_posDepart.X + "," + m_posDepart.Y + "," + m_posActuelle.X + "," + m_posActuelle.Y;
        }
    }
}
