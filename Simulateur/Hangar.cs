using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Hangar : Etat
    {
        public Hangar(int p_temps) : base(p_temps) //Constructeur
        {
        }

        public override void Avance(int p_val)
        {
            onEtatFini();
        }

        public override string ToString()
        {
            return "Hangar";
        }
    }
}
