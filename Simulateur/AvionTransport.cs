using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class AvionTransport : Vehicule
    {
        protected int m_tempsEmbarquement; //Temps d'embarquement
        protected int m_tempsDebarquement; //Temps de débarquement

        public AvionTransport(string p_nom, int p_KMH, int p_tempsMain, int p_tempsEmb, int p_tempsDeb, ConsoleColor p_couleur) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, p_couleur)
        {
            m_tempsEmbarquement = p_tempsEmb;
            m_tempsDebarquement = p_tempsDeb;
        }

        public AvionTransport() : base()
        {

        }

        public int Embarquement
        {
            get { return m_tempsEmbarquement; }
            set { m_tempsEmbarquement = value; }
        }

        public int Debarquement
        {
            get { return m_tempsDebarquement; }
            set { m_tempsDebarquement = value; }
        }
    }
}
