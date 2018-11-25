using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Feu : Client
    {
        private int m_intensite;

        public Feu() : base() //Constructeur
        {
            //Taille de l'image 900 par 528
            int[] Taille = new int[2];
            Taille[0] = 900;
            Taille[1] = 528;

            //Nombre random entre 20 et la taille de l'image - 20
            Random rnd = new Random();
            m_PosX = rnd.Next(20, Taille[0] - 20);
            m_PosY = rnd.Next(20, Taille[1] - 20);

            //La position sur la carte
            m_Position = new PosCarte(m_PosX, m_PosY, Taille);

            //Intensité du feu
            m_intensite = rnd.Next(1, 3);
        }

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
