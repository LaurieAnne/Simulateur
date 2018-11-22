using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class AvionCiterne : Vehicule
    {
        int m_tempsChargement; //Temps de chargement
        int m_tempsLargage; //Temps de largage

        public AvionCiterne(string p_nom, int p_KMH, int p_tempsMain, int p_tempsCharg, int p_tempsLarg) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, ConsoleColor.Yellow)
        {
            m_tempsChargement = p_tempsCharg;
            m_tempsLargage = p_tempsLarg;
        }

        public AvionCiterne() : base()
        {

        }

        public int Chargement
        {
            get { return m_tempsChargement; }
            set { m_tempsChargement = value; }
        }

        public int Largage
        {
            get { return m_tempsLargage; }
            set { m_tempsLargage = value; }
        }

        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Pompier)";
            return vehicule;
        }
    }
}
