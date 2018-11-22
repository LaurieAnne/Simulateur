using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Chrono
    {
        private int m_seconde; //Seconde actuelle
        private int m_minute; //Minute acutelle
        private int m_heure; //Heure actuelle
        private int m_minutesSaut; //Saut à effectuer dans un avancement

        public Chrono(int p_minutesSaut) //Constructeur
        {
            m_minutesSaut = p_minutesSaut;
            m_seconde = 0;
            m_minute = 0;
            m_heure = 0;
        }

        public void avancerTemps() //Avancer le temps du saut déterminé
        {

        }

        public void changerSauts(int p_minutesSaut) //Changer la cadence
        {
            m_minutesSaut = p_minutesSaut;
        }


    }
}
