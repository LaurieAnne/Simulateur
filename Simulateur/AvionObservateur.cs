﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur
{
    public class AvionObservateur : Vehicule
    {
        public AvionObservateur(string p_nom, int p_KMH, int p_tempsMain, Aeroport p_aeroport) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, ConsoleColor.Gray, p_aeroport)
        {

        }

        //Changer d'Etat
        public override void ChangerEtat(object source)
        {
            //PosCarte posDepart = m_aeroport.Pos;
            PosCarte posDepart = new PosCarte();
            PosCarte posDestination = new PosCarte();
            string EtatAvant = m_etat.ToString();

            if (m_etat.ToString() == "Hangar")
                m_etat = new Observer(posDepart, posDepart, posDestination, 100);
            else if (m_etat.ToString() == "Observation")
                m_etat = new Maintenance(m_tempsMaintenance);
            else if (m_etat.ToString() == "Maintenance")
                m_etat = new Hangar(0);

            MessageBox.Show(this.m_nom + " : " + EtatAvant + "->" + this.m_etat.ToString() + " ! Temps avant prochaine action: " + this.m_etat.Temps); //Ne pas oublier de delete la référence using System.Windows.Forms;
            m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
        }








        //Constructeur vide pour XML
        public AvionObservateur() : base(){}

        /**Accesseurs
         */
        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Observateur)";
            return vehicule;
        }
    }
}