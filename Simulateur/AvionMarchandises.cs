using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class AvionMarchandises : AvionTransport //Véhicule de type marchandises
    {

        /** Constructeur d'un avion de marchandises
         * p_nom: le nom du véhicule
         * p_KMH: la vitesse de déplacement de l'avion
         * p_tempsMain: le temps de maintenance
         * p_couleur: la couleur de la ligne à l'affichage
         * p_aeroport: l'aeroport qui le contient (pour extraire ses coordonnées)
         * p_tempsEmb: le temps d'embarquement de l'avion
         * p_tempsDeb: le temps de debarquement de l'avion
         */
        public AvionMarchandises(string p_nom, int p_KMH, int p_tempsMain, int p_tempsEmb, int p_tempsDeb, PosCarte p_posAeroport, Scenario p_scenario, Aeroport p_aeroport) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, p_tempsEmb, p_tempsDeb, Color.Blue, p_posAeroport, p_scenario, p_aeroport)
        {
        }

        /**Constructeur vide pour XML
         */
        public AvionMarchandises() : base(){}



        /**Accesseurs
        */
        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Marchandises)";
            return vehicule;
        }

        public override string Type()
        {
            return "Marchandises";
        }

    }
}
