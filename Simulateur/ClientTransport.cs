﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class ClientTransport : Client //Client de type ClientTransport
    {
        protected int m_nbClients; //Le nombre de clients dans l'objet
        protected PosCarte m_posDest; //L'emplacement où il veut se rendre
        protected PosCarte m_pos; //Position actuelle
        protected int m_PosXDest; //Position en X de la destination
        protected int m_PosYDest; //Position en Y de la destination

        /**Constructeur
         * p_rnd: seed random
         * p_ListePosAeroport: La liste des positions des aéroport
         */
        public ClientTransport(Random p_rnd, List<PosCarte> p_ListePosAeroport) : base() 
        {
            //Taille de l'image 900 par 528
            int[] Taille = new int[2];
            Taille[0] = 900;
            Taille[1] = 528;

            //Nombre random entre 20 et la taille de l'image - 20
            m_PosX = p_rnd.Next(20, Taille[0] - 20);
            m_PosY = p_rnd.Next(20, Taille[1] - 20);



            //La position sur la carte
            m_PositionDepart = new PosCarte(m_PosX, m_PosY, Taille);

            this.TrouverDestination(p_ListePosAeroport, p_rnd);
            this.TrouverDepart(p_ListePosAeroport, p_rnd);

            //Random pour nombre de clients
            m_nbClients = p_rnd.Next(20, 70);

            //Position actuelle
            m_pos = m_PositionDepart;
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
        public ClientTransport(PosCarte p_PosDepart, PosCarte p_PosDestination, int p_nbClients, int p_PosX, int p_PosY, int p_PosXDest, int p_PosYDest, PosCarte p_posDest) : base()
        {
            //Nombre de clients
            m_nbClients = p_nbClients;

            //Position de départ
            m_PositionDepart = p_PosDepart;

            //Position de destination
            m_posDest = p_PosDestination;

            //Position actuelle
            m_pos = m_PositionDepart;

            //Coordonnées en x et y du client
            m_PosX = p_PosX;
            m_PosY = p_PosY;

            //Coordonnées en x et y de la destination du client
            m_PosXDest = p_PosXDest;
            m_PosYDest = p_PosYDest;

            //Postion de la destination
            m_posDest = p_posDest;
        }

        public ClientTransport(){}

        /**Trouver un aeroport de départ
         * p_ListePosAeroport: Liste des position des aéroport
         * p_rnd: Seed Random
         */
        public void TrouverDepart(List<PosCarte> p_ListePosAeroport, Random p_rnd)
        {
            //Taille de l'image 900 par 528
            int[] Taille = new int[2];
            Taille[0] = 900;
            Taille[1] = 528;

            //Random rnd = new Random();
            Random rnd = p_rnd;
            //Position destination
            //Nombre random entre 0 et le nombre d'éléments dans les liste X et Y
            int Aeroport1ind = rnd.Next(0, p_ListePosAeroport.Count);

            /*
                Si les coordonnées en X et en Y de la destination sont pour la même aéroport
                crée la position sur la carte qui relie à l'aéroport
            */

            int PosX = 0;
            int PosY = 0;

            while ((PosX == 0) && (PosY == 0))
            {
                if ((p_ListePosAeroport[Aeroport1ind].X != m_posDest.X) || (p_ListePosAeroport[Aeroport1ind].Y != m_posDest.Y))
                {
                    PosX = p_ListePosAeroport[Aeroport1ind].X;
                    PosY = p_ListePosAeroport[Aeroport1ind].Y;
                    m_pos = new PosCarte(PosX, PosY, Taille);

                    m_PositionDepart = m_pos;

                    m_PosX = PosX;
                    m_PosY = PosY;
                }
                else
                    Aeroport1ind = rnd.Next(0, p_ListePosAeroport.Count);
            }
        }

        /**Trouver un aeroport de destination
         * p_ListePosAeroport: Liste des position des aéroport
         * p_rnd: Seed Random
         */
        public void TrouverDestination(List<PosCarte> p_ListePosAeroport, Random p_rnd)
        {
            //Taille de l'image 900 par 528
            int[] Taille = new int[2];
            Taille[0] = 900;
            Taille[1] = 528;

            //Random rnd = new Random();
            Random rnd = p_rnd;
            //Position destination
            //Nombre random entre 0 et le nombre d'éléments dans les liste X et Y
            int Aeroport1ind = rnd.Next(0, p_ListePosAeroport.Count);

            /*
                Si les coordonnées en X et en Y de la destination sont pour la même aéroport
                crée la position sur la carte qui relie à l'aéroport
            */

            int PosX = 0;
            int PosY = 0;

            while ((PosX == 0) && (PosY == 0))
            {
                if ((p_ListePosAeroport[Aeroport1ind].X != m_PositionDepart.X) || (p_ListePosAeroport[Aeroport1ind].Y != m_PositionDepart.Y))
                {
                    PosX = p_ListePosAeroport[Aeroport1ind].X;
                    PosY = p_ListePosAeroport[Aeroport1ind].Y;
                    m_posDest = new PosCarte(PosX, PosY, Taille);

                    m_PosXDest = PosX;
                    m_PosYDest = PosY;
                }
                else
                    Aeroport1ind = rnd.Next(0, p_ListePosAeroport.Count);
            }
        }

        /**Accesseurs
         */
        public override string obtenirInfoClient()
        {
            //Renvoi Type,PositionX,PositionY,nbClients
            return this.ToString() + "," + this.PositionX + "," + this.PositionY + "," + this.NbClients.ToString();
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
