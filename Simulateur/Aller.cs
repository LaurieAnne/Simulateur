using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Aller : Vol
    {
        protected int m_nbClients; //Le nombre de clients (passagers ou marchandises) dans l'avion

        /**Constructeur
         * p_posDepart: la position de départ
         * p_posActuelle: la position actuelle
         * p_posDestination: la position de destination
         * p_temps: le temps avant le prochain etat
         * p_vehicule: le véhicule qui contient l'etat
         */
        public Aller(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_nbClients, int p_temps, Vehicule p_vehicule) : base(p_posDepart, p_posActuelle, p_posDestination, p_temps, p_vehicule) //Constructeur
        {
            m_nbClients = p_nbClients;
        }

        /**Avance le temps avant le prochain Etat
         * p_val: le temps écoulé
         */
        public override void Avance(int p_val)
        {

            //Si c'est un skip l'Etat entier
            if (p_val > m_temps)
            {
                m_surplus = p_val - m_temps; //Temps de surplus à passer au prochain Etat
                onEtatFini();
            }
            else { 
                m_posActuelle.changerPosition(m_posDepart, m_posDestination, m_vehicule.KMH, p_val);

                string posActuelle = m_posActuelle.Coords();
                string posDestination = m_posDestination.Coords();

                if (posActuelle == posDestination) //Aller retour complété
                {
                    onEtatFini(); //Avertir les abonnées que l'Etat est terminé
                }
            }
        }

        /**Accesseurs
         */
        public int NbClients
        {
            get { return m_nbClients; }
        }

        public override string ToString()
        {
            return "Aller";
        }
    }
}
