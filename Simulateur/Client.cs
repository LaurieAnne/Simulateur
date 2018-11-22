using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class Client
    {
        protected PosCarte m_pos; //Emplacement sur la carte

        public Client(PosCarte p_pos) //Constructeur
        {
            m_pos = p_pos;
        }
    }
}
