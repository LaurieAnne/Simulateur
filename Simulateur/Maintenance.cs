using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Maintenance : Etat
    {

        public Maintenance(int p_temps) : base(p_temps) //Constructeur
        {
        }

        public override string ToString()
        {
            return "Maintenance";
        }
    }
}
