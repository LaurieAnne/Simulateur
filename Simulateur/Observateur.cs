using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Observateur : Client
    {
        public Observateur(PosCarte p_pos) : base(p_pos) //Constructeur
        {

        }

        public override string ToString()
        {
            return "Observation";
        }
    }
}
