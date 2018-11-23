using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Secours : Client
    {
        protected PosCarte m_posDestination;

        public Secours(Aeroport p_aeDepart, PosCarte p_posDestination) : base(p_aeDepart) //Constructeur
        {
            m_posDestination = p_posDestination;
        }

        public PosCarte PositionDestination
        {
            get { return m_posDestination; }
        }

        public override string ToString()
        {
            return "Secours";
        }

    }
}
