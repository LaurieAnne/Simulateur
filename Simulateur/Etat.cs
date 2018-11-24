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
        public event DelegateEtatFini eventEtatFini;

        public Etat(int p_temps) //Constructeur
        {
            m_temps = p_temps;
        }

        public void onEtatFini()
        {
            if (eventEtatFini != null)
                eventEtatFini(this);
        }

        public virtual void Avance(int p_temps, PosCarte p_depart, PosCarte p_destination)
        {
            m_temps -= p_temps;
            if (m_temps <= 0)
            {
                onEtatFini();
            }
        }

        public virtual void Avance(int p_temps)
        {
            m_temps -= p_temps;
            if (m_temps <= 0)
            {
                onEtatFini();
            }
        }

        public int Temps
        {
            get {return m_temps;}
        }
    }
}
