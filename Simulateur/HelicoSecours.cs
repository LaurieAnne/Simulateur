using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class HelicoSecours : Vehicule
    {
        public HelicoSecours(string p_nom, int p_KMH, int p_tempsMain) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, ConsoleColor.Red)
        {

        }

        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Secours), KM/H: " + m_KMH + ", Maintenance: " + m_tempsMaintenance;
            return vehicule;
        }
    }
}
