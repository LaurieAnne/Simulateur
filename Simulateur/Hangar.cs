using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Hangar : Etat //Etat de type Hangar
    {
        /**Constructeur
         * p_temps: le temps avant le prochain Etat
         * p_vehicule: référence au véhicule qui contient l'état
         */
        public Hangar(int p_temps, Vehicule p_vehicule) : base(p_temps, p_vehicule)
        {
        }

        /**Avance le temps avant le prochain Etat
         * p_val: le temps écoulé
         */
        public override void Avance(int p_val)
        {
            //Fait rien on attend
            if (m_vehicule.Client() != null)
                onEtatFini();
        }

        public override string ToString()
        {
            return "Hangar";
        }
    }
}
