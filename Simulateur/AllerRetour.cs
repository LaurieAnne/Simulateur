using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class AllerRetour : Vol
    {
        int m_compteur; //Le nombre d'aller retour à effectuer
        PosCarte m_posDestination; //La coordonnée de destination

        public AllerRetour(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, int p_compteur) : base(p_posDepart, p_posActuelle, p_posDestination, p_temps) //Constructeur
        {
            m_posDestination = p_posDestination;
            m_compteur = p_compteur;
        }

        public AllerRetour(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps) : base(p_posDepart, p_posActuelle, p_posDestination, p_temps) //Constructeur
        {
            m_posDestination = p_posDestination;
            m_compteur = 1; //Si non spécifié 1 aller retour seulement
        }

        public override void Avance(int p_val, PosCarte p_depart, PosCarte p_destination)
        {
            //Changer la position sur la carte
            //Diminuer le temps
            m_temps -= p_val;
            m_compteur -= m_compteur;
            if (m_temps <= 0 && m_compteur <= 0)
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
