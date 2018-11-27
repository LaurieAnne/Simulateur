using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class AllerRetour : Vol
    {
        protected int m_compteur; //Le nombre d'aller retour à effectuer
        protected PosCarte m_posDestination; //La coordonnée de destination
        protected bool aller; //Variable contrôle d'aller retour

        public AllerRetour(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, int p_compteur, Vehicule p_vehicule) : base(p_posDepart, p_posActuelle, p_posDestination, p_temps, p_vehicule) //Constructeur
        {
            m_posDestination = p_posDestination;
            m_compteur = p_compteur;
            aller = true;
        }

        public AllerRetour(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, Vehicule p_vehicule) : base(p_posDepart, p_posActuelle, p_posDestination, p_temps, p_vehicule) //Constructeur
        {
            m_posDestination = p_posDestination;
            m_compteur = 1; //Si non spécifié 1 aller retour seulement
        }

        public override void Avance(int p_val)
        {
            //Si sur l'aller
            if (aller)
            {
                //Ajuster la position actuelle de l'avion
                m_posActuelle.changerPosition(m_posDepart, m_posDestination, m_vehicule.KMH, p_val);

                //Retourner au point de départ
                string posActuelle = m_posActuelle.Coords();
                string posDestination = m_posDestination.Coords();

                if (posActuelle == posDestination)
                {
                    aller = !aller;
                    m_compteur--;
                    if (m_compteur == 0)
                        m_vehicule.ResetClient();
                }
            }
            //Si sur le retour
            else
            {
                m_posActuelle.changerPosition(m_posDestination, m_posDepart, m_vehicule.KMH, p_val);

                //Retourner au point à la destination
                string posActuelle = m_posActuelle.Coords();
                string posDepart = m_posDepart.Coords();

                if (posActuelle == posDepart) //Aller retour complété
                {
                    if (m_compteur > 0)
                        aller = !aller;
                    else
                        onEtatFini();
                }
            }
        }

        public int Compte
        {
            get {return m_compteur; }
        }

        public override string ToString()
        {
            return "AllerRetour";
        }
    }
}
