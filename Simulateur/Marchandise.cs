﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Marchandise : ClientTransport
    {
        public Marchandise(PosCarte p_pos, PosCarte p_posDest, int p_nbClients) : base(p_pos, p_posDest, p_nbClients) //Constructeur
        {

        }
    }
}
