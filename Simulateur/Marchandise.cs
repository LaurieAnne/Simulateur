﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Marchandise : ClientTransport
    {
        public Marchandise(Random p_rnd) : base(p_rnd) //Constructeur
        {

        }

        public Marchandise(PosCarte p_PosDepart, PosCarte p_PosDestination, int p_nbClients, int p_PosX, int p_PosY, int p_PosXDest, int p_PosYDest, PosCarte p_posDest) : base() //Constructeur séparer
        {

        }

        public Marchandise() : base()
        {

        }

        public override ClientTransport separerClient(int nbClients)
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
