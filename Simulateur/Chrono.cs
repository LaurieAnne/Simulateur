using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Chrono
    {
        private int m_seconde; //Secondes actuelle
        private int m_minute; //Minutes acutelle
        private int m_heure; //Heures actuelle
        private int m_minutesSaut; //Saut à effectuer dans un avancement

        public Chrono(int p_minutesSaut) //Constructeur
        {
            m_minutesSaut = p_minutesSaut;
            m_seconde = 0;
            m_minute = 0;
            m_heure = 0;
        }

        public Chrono() //Constructeur
        {
            m_minutesSaut = 10;
            m_seconde = 0;
            m_minute = 0;
            m_heure = 0;
        }

        public void avancerTemps() //Avancer le temps du saut déterminé
        {
            m_minute = m_minute + m_minutesSaut;
            ajusterTemps();
        }

        public void ajusterTemps()
        {
            if (m_minute >= 60)
            {
                m_heure += m_minute / 60;
                m_minute = m_minute % 60;
            }
        }

        public void changerSauts(int p_minutesSaut) //Changer la cadence
        {
            m_minutesSaut = p_minutesSaut;
        }

        public override string ToString()
        {
            string heures;
            string minutes;
            string secondes;
            string heurefinale = "";

            heures = m_heure.ToString();
            heurefinale += heures + ":";
            minutes = m_minute.ToString();
            heurefinale += minutes + ":";
            secondes = m_seconde.ToString();
            heurefinale += secondes;

            return heurefinale;
        }

        public int Minutes
        {
            get { return m_minute; }
        }
        public int Heures
        {
            get { return m_heure; }
        }
        public int Saut
        {
            get { return m_minutesSaut; }
        }

    }
}
