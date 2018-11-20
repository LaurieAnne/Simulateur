using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class AvionPassagers : AvionTransport
    {
        public AvionPassagers(string p_nom, int p_KMH, int p_tempsMain, int p_tempsEmb, int p_tempsDeb) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, p_tempsEmb, p_tempsDeb, ConsoleColor.Green)
        {

        }

        public AvionPassagers() : base()
        {

        }

        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Passagers)";
            return vehicule;
        }
    }
}
