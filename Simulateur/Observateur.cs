﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Observateur : Client //Client de type Observateur
    {
        /**Constructeur
         * p_rnd: seed Random
         */
        public Observateur(Random p_rnd) : base() 
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
        }

        public override string ToString()
        {
            return "Observation";
        }
    }
}
