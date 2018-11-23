using System;
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
            string[] infos; //Séparer le nom, le x et le y

            for (int i = 0; i < aeroports.Length; i++)
            {
                infos = aeroports[i].Split(',');
                nom = infos[0];
                x = Convert.ToInt32(infos[1]);
                y = Convert.ToInt32(infos[2]);

                PictureBox img = new PictureBox();
                img.Image = Properties.Resources.airport;
                img.Location = new Point(x - 12, y - 12);
                img.Name = "img" + i;
                img.Size = new Size(20, 20);
                img.TabStop = false;
                imgCarte.Controls.Add(img);

                ToolTip tt = new ToolTip();
                tt.ShowAlways = true;
                tt.SetToolTip(img, nom);
            }
        }

        private void imgCarte_Paint(object sender, PaintEventArgs e)
        {
            Random rnd = new Random();
            int x = rnd.Next(5, 895);
            int y = rnd.Next(5, 523);
            Graphics graphics = e.Graphics;
            Image img = Image.FromFile("..\\..\\images\\feu.png");
            Rectangle rect = new Rectangle(0, 0, 20, 20);       
            graphics.DrawImage(img, x, y, rect, GraphicsUnit.Pixel);           
        }
    }
}
