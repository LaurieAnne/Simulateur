using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public delegate void DelegateEtatFini(object sender); //Delegué pour changement d'Etat.

    public abstract class Etat //Etat d'un véhicule
    {
        protected int m_temps; //Temp de l'Etat
        protected int m_surplus; //Temps de surplus
        public event DelegateEtatFini eventEtatFini; //Delegué pour changement d'Etat.
        protected Vehicule m_vehicule; //Associé à quel véhicule

        /**Constructeur
         * p_temps: le temps avant le prochain Etat
         * p_vehicule: référence au véhicule qui contient l'état
         */
        public Etat(int p_temps, Vehicule p_vehicule)
        {
            m_temps = p_temps;
            m_vehicule = p_vehicule;
            m_surplus = 0;
        }

        /**L'Event Etat Fini
         */
        public void onEtatFini()
        {
            if (eventEtatFini != null)
                eventEtatFini(this);
        }

        /**Avance le temps avant le prochain Etat
         * p_temps: le temps écoulé
         */
        public virtual void Avance(int p_temps)
        {
            int m_surplus = 0;

            //Ajuster le temps avant le prochain État selon le temps écoulé
            if (p_temps > m_temps)
            {
                m_surplus = p_temps - m_temps;
                onEtatFini();
            }
            else
            {
                m_temps -= p_temps;

                if (m_temps <= 0)
                {
                    m_surplus = p_temps - m_temps;
                    onEtatFini();
                }
            }
        }

        /** Accesseurs
         */
        public int Temps
        {
            get {return m_temps;}
        }
        public int Surplus
        {
            get { return m_surplus; }
            set { m_surplus = value; }
        }
        public virtual PosCarte DestinationFinale()
        {
            PosCarte poscarte = new PosCarte();
            return poscarte;
        }

        public virtual string obtenirPosVehicule() //Obtenir les stats de pos véhicule
        {
            return "";
        }
    }
}
