using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class Vol : Etat //Etat de l'avion: En Vol (Model)
    {
        protected PosCarte m_posDepart; //La coordonnée de départ
        protected PosCarte m_posActuelle; //La coordonnée actuelle
        protected PosCarte m_posDestination; //La coordonnée de destination

        /**Constructeur d'un Etat de vol
         * p_posDepart: la position de départ
         * p_posActuelle: la position actuelle
         * p_posDestination: la position de destination
         * p_temps: le temps restant au vol
         * p_vehicule: référence au véhicule
         */
        public Vol(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, Vehicule p_vehicule) : base(p_temps, p_vehicule)
        {
            m_posDepart = p_posDepart;
            m_posActuelle = p_posActuelle;
            m_posDestination = p_posDestination;
        }


        /**Accesseurs
         */
        public PosCarte PositionActuelle //Obtenir la position actuelle
        {
            get { return m_posActuelle; }
            set { m_posActuelle = value; }
        } 
        public override PosCarte DestinationFinale()//Obtenir la destination finale
        {
            return m_posDestination;
        } 
        public override string obtenirPosVehicule() //Obtenir les stats de pos véhicule
        {
            return m_posDepart.X + "," + m_posDepart.Y + "," + m_posActuelle.X + "," + m_posActuelle.Y;
        }
    }
}
