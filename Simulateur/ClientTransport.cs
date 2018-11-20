using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class ClientTransport : Client
    {
        protected int m_nbClients; //Le nombre de clients dans l'objet
        protected PosCarte m_posDest; //L'emplacement où il veut se rendre

        public ClientTransport(PosCarte p_pos, PosCarte p_posDest, int p_nbClients) : base(p_pos) //Constructeur
        {
            m_nbClients = p_nbClients;
            m_posDest = p_posDest;
        }
    }
}
