using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Marchandise : ClientTransport
    {
        public Marchandise(Random p_rnd) : base() //Constructeur
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
            //TrouverDestination(m_PosX, m_PosY);
        }

        public Marchandise(PosCarte p_PosDepart, PosCarte p_PosDestination, int p_nbClients, int p_PosX, int p_PosY) : base() //Constructeur séparer
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
        }

        public Marchandise separerMarchandise(int nbClients)
        {
            this.NbClients = this.NbClients - nbClients;
            return new Marchandise(this.Position, this.Destination, nbClients, this.m_PosX, this.m_PosY);
        }

        private void TrouverDestination(int p_PosX, int p_PosY)
        {
            //Taille de l'image 900 par 528
            int[] Taille = new int[2];
            Taille[0] = 900;
            Taille[1] = 528;

            Random rnd = new Random();
            //Position destination
            //Nombre random entre 20 et la taille de l'image - 20
            m_PosXDest = rnd.Next(20, Taille[0] - 20);
            m_PosYDest = rnd.Next(20, Taille[1] - 20);

            /*Si les coordonnées en X et en Y de la destination et de la position de départ ne sont pas les même 
              crée la position de la destination, 
              sinon cherche une autre destination.
            */
            if ( (m_PosXDest != m_PosX) || (m_PosYDest != m_PosY) )
            {
                m_posDest = new PosCarte(m_PosXDest, m_PosYDest, Taille);
            }
            else
            {
                TrouverDestination(p_PosX, p_PosY);
            }
        }

        public override string ToString()
        {
            return "Marchandises";
        }
    }
}
