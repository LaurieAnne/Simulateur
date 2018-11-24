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

        public AllerRetour(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps) : base(p_posDepart, p_posActuelle, p_posDestination, p_temps) //Constructeur
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
                PositionActuelle.changerPosition(m_posDepart, m_posDestination, m_vehicule.KMH, p_val);
                //Retourner au point de départ
                if (PositionActuelle == m_posDestination)
                    aller = !aller;
            }
            //Si sur le retour
            else
            {
                PositionActuelle.changerPosition(m_posDestination, m_posDepart, m_vehicule.KMH, p_val);
                if (PositionActuelle == m_posDepart) //Aller retour complété
                {
                    if (m_compteur > 0)
                    {
                        aller = !aller;
                        m_compteur--;
                    }
                }
            }

            //Avertir les abonnées que l'Etat est terminé
            if (m_compteur <= 0)
            {
                onEtatFini();
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
