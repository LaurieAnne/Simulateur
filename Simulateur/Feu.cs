﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Feu : Client
    {
        private int m_intensite; //Intensité du feu (nombre d'aller retour)

        /**Constructeur
         * p_rnd: seed Random
         */
        public Feu(Random p_rnd) : base() //Constructeur
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

            //Intensité du feu
            m_intensite = p_rnd.Next(1, 6);
        }

        /**Accesseurs
         */
        public int IntensiteFeu
        {
            get { return m_intensite; }
            set { m_intensite = value; }
        }

        public override string ToString()
        {
            return "Feu";
        }
    }
}
