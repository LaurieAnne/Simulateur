using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Passager : ClientTransport
    {
        public Passager(Random p_rnd, List<PosCarte> p_ListePosAeroport) : base(p_rnd, p_ListePosAeroport) //Constructeur
        {

        }

        public Passager(PosCarte p_PosDepart, PosCarte p_PosDestination, int p_nbClients, int p_PosX, int p_PosY, int p_PosXDest, int p_PosYDest, PosCarte p_posDest) : base() //Constructeur séparer
        {

        }

        public Passager() : base()
        {

        }

        public override Passager separerClientPassager(int p_nbClients)
        {
            this.NbClients = this.NbClients - p_nbClients;
            return new Passager(this.PositionDepart, this.Destination, p_nbClients, this.m_PosX, this.m_PosY, this.m_PosXDest, this.m_PosYDest, this.m_posDest);
        }

        public static Passager operator +(Passager client1, Passager client2)
        {
            Passager client = new Passager();
            client.m_nbClients = client1.m_nbClients + client2.m_nbClients;

            return client;
        }

        public override string ToString()
        {
            return "Passagers";
        }
    }
}
