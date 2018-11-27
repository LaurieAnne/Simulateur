using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class PosCarte
    {
        private int m_x; //Pos X
        private int m_y; //Pos Y
        private int[] m_taille; //Taille l'image

        public PosCarte(int p_x, int p_y, int[] p_taille) //Constructeur
        {
            m_x = p_x;
            m_y = p_y;
            m_taille = p_taille;
        }

        public PosCarte()
        {

        }

        public int X
        {
            get { return m_x; }
            set { m_x = value; }
        }

        public int Y
        {
            get { return m_y; }
            set { m_y = value; }
        }

        public int[] Taille
        {
            get { return m_taille; }
            set { m_taille = value; }
        }

        private char[] obtenirCadran() //Obtenir le cadran du point
        {
            char[] cadran = new char[2]; //Cadran
            int tailleX = m_taille[0]; //Longueur
            int tailleY = m_taille[1]; //Hauteur

            if (m_y <= tailleY / 2)
            {
                cadran[0] = 'N';
            }
            else
            {
                cadran[0] = 'S';
            }

            if (m_x <= (tailleX / 2))
            {
                cadran[1] = 'O';
            }
            else
            {
                cadran[1] = 'E';
            }

            return cadran;
        }

        private int obtenirLat(char p_cadran) //Obtenir les degrés nord sud
        {
            int tailleY = m_taille[1]; //Hauteur
            int taille = tailleY / 2; //Taille du cadran
            int lat; //Degrés

            lat = Math.Abs((m_y - taille) * 90 / taille);

            return lat;
        }

        private int obtenirLongi(char p_cadran) //Obtenir les degrés ouest est
        {
            int tailleX = m_taille[0]; //Longueur
            int taille = tailleX / 2; //Taille du cadran
            int longi; //Degrés

            longi = Math.Abs((m_x - taille) * 180 / taille);

            return longi;
        }

        public override string ToString() //ToString
        {
            char[] cadran = obtenirCadran();
            int lat = obtenirLat(cadran[0]);
            int longi = obtenirLongi(cadran[1]);
            string coord = lat + "°" + cadran[0] + " " + longi + "°" + cadran[1];
            return coord;
        }

        public void changerPosition(PosCarte p_depart, PosCarte p_destination, int p_vitesse, int p_temps) //Changer la position selon la vitesse et le temps
        {
            int distance = p_vitesse * (p_temps / 10); //Le % de complété
            int distancex = p_destination.X - p_depart.X; //La distance en x entre le depart et la destination
            int distancey = p_destination.Y - p_depart.Y; //La distance en y entre le depart et la destination
            char directionx = (p_depart.X > p_destination.X) ? 'g' : 'd'; //Direction Gauche Droite
            char directiony = (p_depart.Y > p_destination.Y) ? 'h' : 'b'; //Direction Haut Bas


            double a = (double)distancey / (double)distancex;
            double b = (p_depart.Y - (a * p_depart.X));


            //Direction droite
            if (directionx == 'd')
            {
                double value = (distance * distancex) / 100;

                if (value >= 1 || value <= -1)
                    this.m_x += (distance * distancex) / 100;
                else
                    this.m_x++;

                if (this.m_x >= p_destination.X)
                    this.m_x = p_destination.X;
            }
            //Direction gauche
            else
            {
                this.m_x += (distance * distancex) / 100;
                double value = (distance * distancex) / 100;

                if (value >= 1 || value <= -1)
                    this.m_x += (distance * distancex) / 100;
                else
                    this.m_x--;

                if (this.m_x <= p_destination.X)
                    this.m_x = p_destination.X;
            }
            //Direction haut
            if (directiony == 'h')
            {
                this.m_y = (int)(a * m_x + b);//this.m_y += (distance * distancey) / 100;

                if (this.m_y <= p_destination.Y)
                    this.m_y = p_destination.Y;
            }
            //Direction bas
            else
            {
                this.m_y = (int)(a * m_x + b);//this.m_y += (distance * distancey) / 100;

                if (this.m_y >= p_destination.Y)
                    this.m_y = p_destination.Y;
            }
        }

        public static int Distance(PosCarte p_depart, PosCarte p_destination)
        {
            int distance;
            int distancex;
            int distancey;

            distancex = p_depart.X - p_destination.X;
            distancey = p_depart.Y - p_destination.Y;

            //Pythagore
            distance = Math.Abs((int)Math.Sqrt( (distancex * distancex) + (distancey * distancey) ));

            return distance;
        }

        public string Coords() //ToString
        {
            string coords;
            coords = m_x.ToString();
            coords += "," + m_y.ToString();
            return coords;
        }

    }
}
