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

        public AllerRetour(PosCarte p_destination, PosCarte p_depart, PosCarte p_posActuelle, int p_compteur, int p_temps) : base(p_destination, p_depart, p_posActuelle, p_temps) //Constructeur
        {
            m_compteur = p_compteur;
        }

        public AllerRetour(PosCarte p_destination, PosCarte p_depart, PosCarte p_posActuelle, int p_temps) : base(p_destination, p_depart, p_posActuelle, p_temps) //Constructeur par défaut
        {
            m_compteur = 1; //Si non spécifié 1 aller retour seulement
        }

        public override void Avance(int p_val)
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
