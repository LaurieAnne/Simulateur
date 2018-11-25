using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class AvionPassagers : AvionTransport
    {
        public AvionPassagers(string p_nom, int p_KMH, int p_tempsMain, int p_tempsEmb, int p_tempsDeb, Aeroport p_aeroport, ClientTransport p_client) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, p_tempsEmb, p_tempsDeb, ConsoleColor.Green, p_aeroport, p_client)
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
