﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur
{
    public partial class FormSimulateur : Form
    {
        private Simulateur m_simulateur; //Le simulateur
        private Scenario m_scenario; //Le scénario

        public FormSimulateur(Simulateur p_simulateur, Scenario p_scenario) //Constructeur
        {
            InitializeComponent();
            m_simulateur = p_simulateur;
            m_scenario = p_scenario;
            afficherAeroports();
            afficherImagesAeroports();
            lstAeroports.SelectedIndex = 0;
        }

        private void afficherAeroports() //Afficher les aéroports
        {
            string[] aeroports = m_scenario.obtenirAeroports(); //Tableau des aéroports

            lstAeroports.Items.Clear();
            lstVehicules.Items.Clear();

            for (int i = 0; i < aeroports.Length; i++)
            {
                lstAeroports.Items.Add(aeroports[i]);
            }
        }

        private void afficherVehicules() //Afficher les véhicules
        {
            int aeroport = lstAeroports.SelectedIndex; //Aéroport choisi
            string[] vehicules = m_scenario.obtenirVehicules(aeroport); //Tableau des véhicules

            lstVehicules.Items.Clear();

            for (int i = 0; i < vehicules.Length; i++)
            {
                lstVehicules.Items.Add(vehicules[i]);
            }
        }

        private void lstAeroports_SelectedValueChanged(object sender, EventArgs e) //sur un changement d'aéroport
        {
            int aeroport = lstAeroports.SelectedIndex; //Aéroport choisi

            if (aeroport > -1)
            {
                afficherVehicules();
            }
            else
            {
                lstVehicules.Items.Clear();
            }
        }

        private void afficherImagesAeroports() //Afficher les icônes d'aéroport sur la carte
        {
            string[] aeroports = m_scenario.obtenirPosAeroports(); //Les infos
            int x, y; //L'emplacement
            string nom; //Le nom de l'aéroport

            for (int i = 0; i < aeroports.Length; i++)
            {
                string[] infos = aeroports[i].Split(','); //Séparer le nom, le x et le y
                nom = infos[0];
                x = Convert.ToInt32(infos[1]);
                y = Convert.ToInt32(infos[2]);
                PictureBox img = new PictureBox();
                img.Image = Properties.Resources.airport;
                img.Location = new Point(x, y);
                img.Name = "img" + i;
                img.Size = new Size(25, 25);
                img.TabStop = false;
                this.imgCarte.Controls.Add(img); //Ajouter l'image
                ToolTip tt = new ToolTip();
                tt.ShowAlways = true;
                tt.SetToolTip(img, nom);
            }
        }
    }
}
