using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Passager : ClientTransport
    {
        public Passager(Random p_rnd, Scenario p_scenario) : base(p_scenario) //Constructeur
        {
            //Taille de l'image 900 par 528
            int[] Taille = new int[2];
            Taille[0] = 900;
            Taille[1] = 528;

            //Nombre random entre 20 et la taille de l'image - 20
            m_PosX = p_rnd.Next(20, Taille[0] - 20);
            m_PosY = p_rnd.Next(20, Taille[1] - 20);

            //La position sur la carte
            m_Position = new PosCarte(m_PosX, m_PosY, Taille);

            //Random pour nombre de clients
            m_nbClients = p_rnd.Next(20, 100);

            //Position actuelle
            m_pos = m_Position;

            //Position destination
            TrouverDestination();

            //Le scénario actuel
            m_scenario = p_scenario;
        }

        public Passager(Scenario p_scenario) : base (p_scenario)
        {
            //Le scénario actuel
            m_scenario = p_scenario;
        }

        public Passager(PosCarte p_PosDepart, PosCarte p_PosDestination, int p_nbClients, int p_PosX, int p_PosY, int p_PosXDest, int p_PosYDest, PosCarte p_posDest, Scenario p_scenario) : base(p_scenario) //Constructeur séparer
        {
            //Nombre de clients
            m_nbClients = p_nbClients;

            //Position de départ
            m_Position = p_PosDepart;

            //Position de destination
            m_posDest = p_PosDestination;

            //Position actuelle
            m_pos = m_Position;

            //Coordonnées en x et y du client
            m_PosX = p_PosX;
            m_PosY = p_PosY;

            //Coordonnées en x et y de la destination du client
            m_PosXDest = p_PosXDest;
            m_PosYDest = p_PosYDest;

            //Postion de la destination
            m_posDest = p_posDest;

            //Le scénario actuel
            m_scenario = p_scenario;
        }

        public override ClientTransport separerClient(int p_nbClients)
        {
            this.NbClients = this.NbClients - p_nbClients;
            return new Passager(this.Position, this.Destination, p_nbClients, this.m_PosX, this.m_PosY, this.m_PosXDest, this.m_PosYDest, this.m_posDest, this.m_scenario);
        }

        private void TrouverDestination()
        {
            //Taille de l'image 900 par 528
            int[] Taille = new int[2];
            Taille[0] = 900;
            Taille[1] = 528;

            List<Aeroport> ListeAeroport = m_scenario.ListeAeroports;

            Random rnd = new Random();
            //Position destination
            //Nombre random entre 0 et le nombre d'éléments dans les liste X et Y
            int Aeroport1ind = rnd.Next(0, ListeAeroport.Count);
            /*
                Si les coordonnées en X et en Y de la destination sont pour la même aéroport
                crée la position sur la carte qui relie à l'aéroport
            */
            if ( (ListeAeroport[Aeroport1ind].Pos.X == m_Position.X) && ((ListeAeroport[Aeroport1ind].Pos.Y == m_Position.Y)) )
            {
                TrouverDestination();
            }
            else
            {
                int PosX = ListeAeroport[Aeroport1ind].Pos.X;
                int PosY = ListeAeroport[Aeroport1ind].Pos.Y;
                m_posDest = new PosCarte(PosX, PosY, Taille);

                m_PosXDest = PosX;
                m_PosYDest = PosY;
            }
        }

        public override string ToString()
        {
            return "Passagers";
        }
    }
}
