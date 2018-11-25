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
        protected PosCarte m_pos; //Position acutelle

        protected int m_PosXDest; //Position en X de la destination
        protected int m_PosYDest; //Position en Y de la destination

        public ClientTransport() : base() //Constructeur
        {

        }

        public int NbClients
        {
            get { return m_nbClients; }
            set { m_nbClients = value; }
        }

        public PosCarte Destination
        {
            get { return m_posDest; }
        }

        public PosCarte PositionActuelle
        {
            get { return m_pos; }
        }

        public int PositionXDestination
        {
            get { return m_PosXDest; }
        }

        public int PositionYDestination
        {
            get { return m_PosYDest; }
        }
    }
}
