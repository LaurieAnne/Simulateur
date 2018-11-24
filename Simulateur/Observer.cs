using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Observer : Vol
    {
        protected string statut; //Variable contrôle d'aller retour

        public Observer(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, Vehicule p_vehicule) : base(p_posDepart,  p_posActuelle, p_posDestination, p_temps, p_vehicule) //Constructeur
        {
            statut = "aller";
        }

        public override void Avance(int p_val)
        {
            //Si sur l'aller
            if (statut == "aller")
            {
                //Ajuster la position actuelle de l'avion
                PositionActuelle.changerPosition(m_posDepart, m_posDestination, m_vehicule.KMH, p_val);
                
                //Retourner au point de départ
                if (PositionActuelle == m_posDestination)
                    statut = "retour";//Remplacer par tourner <---
            }
            else if (statut == "tourner")
            {
                //PositionActuelle.Tourner();
                if (PositionActuelle == m_posDestination)
                    statut = "retour";
            }
            //Si sur le retour
            else if (statut == "retour")
            {
                PositionActuelle.changerPosition(m_posDestination, m_posDepart, m_vehicule.KMH, p_val);
                if (PositionActuelle == m_posDepart) //Aller retour complété
                {
                    onEtatFini();
                }
            }
        }

        public override string ToString()
        {
            return "Observation";
        }
    }
}
