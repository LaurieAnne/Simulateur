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
            if (p_val > m_temps)
            {
                m_surplus = p_val - m_temps;
                onEtatFini();
            }
            else
            {
                //Si sur l'aller
                if (statut == "aller")
                {
                    //Ajuster la position actuelle de l'avion
                    m_posActuelle.changerPosition(m_posDepart, m_posDestination, m_vehicule.KMH, p_val);

                    //Retourner au point de départ
                    string posActuelle = m_posActuelle.Coords();
                    string posDestination = m_posDestination.Coords();
                    if (posActuelle == posDestination)
                    {
                        statut = "retour"; //Remplacer par tourner <---
                        m_vehicule.ResetClient();
                    }
                }
                else if (statut == "tourner")
                {
                    //PositionActuelle.Tourner();
                    //Retourner au point de départ
                    string posActuelle = m_posActuelle.Coords();
                    string posDestination = m_posDestination.Coords();

                    if (posActuelle == posDestination)
                        statut = "retour";
                }
                //Si sur le retour
                else if (statut == "retour")
                {
                    m_posActuelle.changerPosition(m_posDestination, m_posDepart, m_vehicule.KMH, p_val);

                    //Retourner au point à la destination
                    string posActuelle = m_posActuelle.Coords();
                    string posDepart = m_posDepart.Coords();
                    if (posActuelle == posDepart) //Aller retour complété
                    {
                        onEtatFini();
                    }
                }
            }
        }

        public override string ToString()
        {
            return "Observation";
        }
    }
}
