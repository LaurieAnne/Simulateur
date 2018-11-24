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
                img.Location = new Point(x - 10, y - 10);
                img.Name = "img" + i;
                img.Size = new Size(20, 20);
                img.TabStop = false;
                img.BackColor = Color.Transparent;
                imgCarte.Controls.Add(img);

                ToolTip tt = new ToolTip();
                tt.ShowAlways = true;
                tt.SetToolTip(img, nom);
            }
        }

        private void imgCarte_Paint(object sender, PaintEventArgs e)
        {
            Random rnd = new Random();
            int x = rnd.Next(15, 885);
            int y = rnd.Next(15, 510);
            dessinerFeu(x, y, e);

            x = rnd.Next(15, 885);
            y = rnd.Next(15, 510);
            dessinerObservateur(x, y, e);

            x = rnd.Next(15, 885);
            y = rnd.Next(15, 510);
            dessinerSecours(x, y, e);

            int[] depart = new int[2];
            depart[0] = 500;
            depart[1] = 50;
            int[] dest = new int[2];
            dest[0] = 600;
            dest[1] = 300;
            dessinerLigne(depart, dest, Color.Black, e);

            //bouton this.invalidate
        }

        private void dessinerFeu(int p_x, int p_y, PaintEventArgs e) //Dessiner un feu
        {
            Image img = Image.FromFile("..\\..\\images\\feu.png");
            Rectangle rect = new Rectangle(0, 0, 16, 16);
            e.Graphics.DrawImage(img, p_x - 8, p_y - 8, rect, GraphicsUnit.Pixel);
        }

        private void dessinerLigne(int[] p_depart, int[] p_dest, Color p_couleur, PaintEventArgs e) //Dessiner une ligne
        {
            Pen pen = new Pen(p_couleur, 2);
            e.Graphics.DrawLine(pen, p_depart[0], p_depart[1], p_dest[0], p_dest[1]);
            pen.Dispose();
        }

        private void dessinerObservateur(int p_x, int p_y, PaintEventArgs e) //Dessiner un observateur
        {
            Image img = Image.FromFile("..\\..\\images\\observateur.png");
            Rectangle rect = new Rectangle(0, 0, 16, 16);
            e.Graphics.DrawImage(img, p_x - 8, p_y - 8, rect, GraphicsUnit.Pixel);
        }

        private void dessinerSecours(int p_x, int p_y, PaintEventArgs e) //Dessiner un secours
        {
            Image img = Image.FromFile("..\\..\\images\\secours.png");
            Rectangle rect = new Rectangle(0, 0, 16, 16);
            e.Graphics.DrawImage(img, p_x - 8, p_y - 8, rect, GraphicsUnit.Pixel);
        }
    }
}
