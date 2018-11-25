using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class Client
    {
        protected int m_PosX;
        protected int m_PosY;
        protected PosCarte m_Position;

        public Client() //Constructeur
        {

        }

        public int PositionX
        {
            get { return m_PosX; }
        }

        public int PositionY
        {
            get { return m_PosY; }
        }

        public PosCarte Position
        {
            get { return m_Position; }
        }

        /*public override string ToString() //ToString
        {
            string client;
            string coord = m_pos.ToString();
            client = m_Nom + " (" + coord + ")";
            return client;
        }*/
    }
}
