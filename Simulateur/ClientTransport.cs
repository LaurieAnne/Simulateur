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

        /*protected int m_PosXDepart;
        protected int m_PosYDepart;*/

        public ClientTransport(PosCarte p_pos, PosCarte p_posDest) : base() //Constructeur
        {
            m_posDest = p_posDest;
        }

        public int NbClients
        {
            get { return m_nbClients; }
            set { m_nbClients = value; }
        }

        /*public int PositionX
        {
            get { return m_PosXDepart; }
        }

        public int PositionY
        {
            get { return m_PosYDepart; }
        }*/
    }
}
