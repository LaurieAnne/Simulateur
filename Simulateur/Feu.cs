using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Feu : Client
    {
        protected PosCarte m_posDestination;

        public Feu(Aeroport p_aeDepart, PosCarte p_posDestination) : base(p_aeDepart) //Constructeur
        {
            m_posDestination = p_posDestination;
        }

        public PosCarte PositionDestination
        {
            get { return m_posDestination; }
        }

        public override string ToString()
        {
            return "Feu";
        }
    }
}
