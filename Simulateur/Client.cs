using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class Client
    {
        protected Aeroport m_aeDepart; //L'Aéroport de départ

        public Client(Aeroport p_aeDepart) //Constructeur
        {
            m_aeDepart = p_aeDepart;
        }

        public Aeroport AeroportDepart
        {
            get { return m_aeDepart; }
        }
    }
}
