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
        protected PosCarte m_PositionDepart;

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

        public PosCarte PositionDepart
        {
            get { return m_PositionDepart; }
        }

        /*public override string ToString() //ToString
        {
            string client;
            string coord = m_pos.ToString();
            client = m_Nom + " (" + coord + ")";
            return client;
        }*/

        public virtual string obtenirInfoClient()
        {
            //Renvoi Type,PositionX,PositionY

            return this.ToString() + "," + this.PositionX + "," + this.PositionY;
        }

        public virtual Passager separerClientPassager(int p_nbClients)
        {
            return new Passager();
        }

        public virtual Marchandise separerClientMarchandise(int p_nbClients)
        {
            return new Marchandise();
        }
    }
}
