using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Maintenance : Etat //Etat de type maintenance
    {
        /**Constructeur
         * p_temps: le temps avant le prochain Etat
         * p_vehicule: référence au véhicule qui contient l'état
         */
        public Maintenance(int p_temps, Vehicule p_vehicule) : base(p_temps, p_vehicule) //Constructeur
        {
        }

        public override string ToString()
        {
            return "Maintenance";
        }
    }
}
