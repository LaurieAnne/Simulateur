using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public delegate void DelegateEtatFini(object sender);

    public abstract class Etat
    {
        protected int m_temps; //Temp de l'Etat
        protected int m_surplus; //Temps de surplus
        public event DelegateEtatFini eventEtatFini;
        protected Vehicule m_vehicule; //Associé à quel véhicule

        public Etat(int p_temps, Vehicule p_vehicule) //Constructeur
        {
            m_temps = p_temps;
            m_vehicule = p_vehicule;
            m_surplus = 0;
        }

        public void onEtatFini()
        {
            if (eventEtatFini != null)
                eventEtatFini(this);
        }

        public virtual void Avance(int p_temps)
        {
            int m_surplus = 0; //Temps de surplus après modification

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

        public virtual string obtenirPosVehicule() //Obtenir les stats de pos véhicule
        {
            return "";
        }
    }
}
