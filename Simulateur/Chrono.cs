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
        public delegate void NouvelleHeureDelegate(); //Délégué
        public event NouvelleHeureDelegate NouvelleHeure; //Event basé sur délégué
        public delegate void Nouveau4HeuresDelegate(); //Délégué
        public event Nouveau4HeuresDelegate Nouveau4Heures; //Event basé sur délégué
        private int m_nbHeures; //Nombre d'heures qui ont changées depuis le dernier reset

        public Chrono(int p_minutesSaut) //Constructeur
        {
            m_minutesSaut = p_minutesSaut;
            m_seconde = 0;
            m_minute = 0;
            m_heure = 0;
            m_nbHeures = 0;
        }

        public Chrono() //Constructeur
        {
            m_minutesSaut = 1;
            m_seconde = 0;
            m_minute = 0;
            m_heure = 0;
            m_nbHeures = 0;
        }

        public void avancerTemps() //Avancer le temps du saut déterminé
        {
            int heurePrec = m_heure; //Heure précédente

            m_minute = m_minute + m_minutesSaut;
            ajusterTemps();

            int nbHeures = nombreHeures(heurePrec); //Nombre d'heures passées
            m_nbHeures += nbHeures; //Nombre d'heures accumulées

            if (nbHeures > 0) //Chaque heure pour les clients
            {
                for (int i = 0; i < nbHeures; i++) //Pour chaque heure passée
                {
                    onNouvelleHeure();
                }
            }

            if (m_nbHeures >= 4) //Regarder maintenant pour les autres clients
            {
                int nbFois = m_nbHeures / 4; //Nombre de fois qu'on déclenchera l'évènement
                m_nbHeures = m_nbHeures % 4; //Affecter le reste aux heures accumulées

                for (int i = 0; i < nbFois; i++) //Pour chaque 4 heures passées
                {
                    onNouveau4Heures();
                }
            }
        }

        protected virtual void onNouvelleHeure() //Soulever l'évènement pour les clients
        {
            NouvelleHeure();           
        }

        protected virtual void onNouveau4Heures() //Soulever l'évènement pour les clients normaux
        {
            Nouveau4Heures();
        }

        public int nombreHeures(int p_heurePrec) //Calculer le nombre d'heures sautées
        {
            int heureActuelle = m_heure; //Heure actuelle
            int nbHeures = 0; //Nombre d'heures passées

            if (heureActuelle > p_heurePrec)
            {
                nbHeures = heureActuelle - p_heurePrec;
            }
            else if (p_heurePrec > heureActuelle) //On a dépassé 23h, nouvelle journée
            {
                nbHeures = (heureActuelle + 24) - p_heurePrec;
            }

            return nbHeures;
        }

        public void ajusterTemps() //Ajuster le temps
        {
            if ((m_minute >= 60))
            {
                m_heure += m_minute / 60;
                m_minute = m_minute % 60;

                if (m_heure > 23)
                {
                    m_heure = m_heure - 24;
                }
            }
        }

        public void changerSauts(int p_minutesSaut) //Changer la cadence
        {
            m_minutesSaut = p_minutesSaut;
        }

        public override string ToString() //Retourner le temps en chaine
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

        public int Secondes
        {
            get { return m_seconde;  }
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
