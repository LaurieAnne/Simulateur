using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class AvionPassagers : AvionTransport
    {
        public AvionPassagers(string p_nom, int p_KMH, int p_tempsMain, int p_tempsEmb, int p_tempsDeb, Aeroport p_aeroport) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, p_tempsEmb, p_tempsDeb, ConsoleColor.Green, p_aeroport)
        {
        }







        //Constructeur vide pour XML
        public AvionPassagers() : base(){ }

        /**Accesseurs
         */
        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Passagers)";
            return vehicule;
        }
    }
}
