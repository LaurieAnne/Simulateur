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
        protected Aeroport m_aeDestination; //L'Aéroport de destination

        public ClientTransport(Aeroport p_aeDepart, Aeroport p_aeDestination, int p_nbClients) : base(p_aeDepart) //Constructeur
        {
            m_nbClients = p_nbClients;
            m_aeDestination = p_aeDestination;
        }

        public Aeroport AeroportDestination
        {
            get { return m_aeDestination; }
        }

        public int NbClients
        {
            get { return m_nbClients; }
        }
    }
}
