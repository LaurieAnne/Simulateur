using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class Client
    {
        protected int m_PosX; //Position en X
        protected int m_PosY; //Position en Y
        protected PosCarte m_PositionDepart; //Position de départ

        public Client(){}//Constructeur

        /**Séparer un client Passager
         * p_nbClients: la quantité de clients à enlever
         */
        public virtual Passager separerClientPassager(int p_nbClients)
        {
            return new Passager();
        }

        /**Séparer un client Marchandise
         * p_nbClients: la quantité de clients à enlever
         */
        public virtual Marchandise separerClientMarchandise(int p_nbClients)
        {
            return new Marchandise();
        }

        /**Accesseurs
         */
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

        public virtual string obtenirInfoClient()
        {
            //Renvoi Type,PositionX,PositionY
            return this.ToString() + "," + this.PositionX + "," + this.PositionY;
        }
    }
}
