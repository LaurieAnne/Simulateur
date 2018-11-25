using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Hangar : Etat
    {
        public Hangar(int p_temps, Vehicule p_vehicule) : base(p_temps, p_vehicule) //Constructeur
        {
        }

        public override void Avance(int p_val)
        {
            //Fait rien on attend
            //onEtatFini();
        }

        public override string ToString()
        {
            return "Hangar";
        }
    }
}
