using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Marchandise : ClientTransport //ClientTransport de type Marchandise
    {
        /**Constructeur
         * p_rnd: seed random
         * p_ListePosAeroport: La liste des positions des aéroport
         */
        public Marchandise(Random p_rnd, List<PosCarte> p_ListePosAeroport) : base(p_rnd, p_ListePosAeroport)
        {
        }

        /**Constructeur lors de la séparation de deux clients
         * p_PosDepart: la position de départ
         * p_PosDestination: la position de destination 
         * p_nbClients: le nombre de client
         * p_PosX: la position X du client
         * p_PosY: la position Y du client
         * p_PosXDest: la position X de la destination
         * p_PosYDest: la position Y de la destination
         * p_posDest: la position de la destination
         */
        public Marchandise(PosCarte p_PosDepart, PosCarte p_PosDestination, int p_nbClients, int p_PosX, int p_PosY, int p_PosXDest, int p_PosYDest, PosCarte p_posDest) : base(p_PosDepart, p_PosDestination, p_nbClients, p_PosX, p_PosY, p_PosXDest, p_PosYDest, p_posDest)
        {
        }

        public Marchandise() : base(){}

        /**Séparer un client en deux client
         * p_nbClients: le nombre de clients à enlever
         */
        public override Marchandise separerClientMarchandise(int nbClients)
        {
            this.NbClients = this.NbClients - nbClients;
            return new Marchandise(this.PositionDepart, this.Destination, nbClients, this.m_PosX, this.m_PosY, this.m_PosXDest, this.m_PosYDest, this.m_posDest);
        }

        public static Marchandise operator +(Marchandise client1, Marchandise client2)
        {
            Marchandise client = new Marchandise();
            client.m_nbClients = client1.m_nbClients + client2.m_nbClients;

            return client;
        }

        public override string ToString()
        {
            return "Marchandises";
        }
    }
}
