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
        private bool start = false;

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

        private void afficherClients() //Afficher les clients
        {
            int aeroport = lstAeroports.SelectedIndex; //Aéroport choisi
            List<string> clients = m_scenario.obtenirClients(aeroport); //Liste des clients
            string client = ""; //Le client
            string type; //Type client
            string qte; //Quantité de clients

            lstCl.Items.Clear();

            for (int i = 0; i < clients.Count; i++)
            {
                type = clients[i].Split(',')[0];

                switch (type)
                {
                    case "Passagers":
                        qte = clients[i].Split(',')[3];
                        client = qte + " passagers";
                        break;
                    case "Marchandises":
                        qte = clients[i].Split(',')[3];
                        client = qte + " marchandises";
                        break;
                    case "Observation":
                        client = "Observateur";
                        break;
                    case "Feu":
                        client = "Feu";
                        break;
                    case "Secours":
                        client = "Secours";
                        break;
                }

                lstCl.Items.Add(client);
            }
        }

        private void lstAeroports_SelectedValueChanged(object sender, EventArgs e) //sur un changement d'aéroport
        {
            int aeroport = lstAeroports.SelectedIndex; //Aéroport choisi

            if (aeroport > -1)
            {
                afficherVehicules();
                afficherClients();
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

        private void imgCarte_Paint(object sender, PaintEventArgs e) //Réafficher les objets
        {
            afficherClientsSurCarte(e);
            afficherVehiculesEnVol(e);
            afficherClients();
            afficherVehicules();
        }

        private void afficherVehiculesEnVol(PaintEventArgs e) //Afficher tous les véhicules en vol
        {
            List<string> enVol = m_scenario.obtenirVehiculesEnVol(); //Véhicules en vol
            string[] infos; //Infos des véhicules
            string type; //Le type du véhicule

            for (int i = 0; i < enVol.Count; i++)
            {
                infos = enVol[i].Split(',');
                int[] depart = new int[2];
                depart[0] = Convert.ToInt32(infos[1]);
                depart[1] = Convert.ToInt32(infos[2]);
                int[] pos = new int[2];
                pos[0] = Convert.ToInt32(infos[3]);
                pos[1] = Convert.ToInt32(infos[4]);
                type = infos[5];

                switch (type)
                {
                    case "Passagers":
                        dessinerVehiculePass(pos[0], pos[1], e);
                        dessinerLigne(depart, pos, Color.Green, e);
                        break;
                    case "Marchandises":
                        dessinerVehiculeMarch(pos[0], pos[1], e);
                        dessinerLigne(depart, pos, Color.Blue, e);
                        break;
                    case "Observation":
                        dessinerVehiculeObservateur(pos[0], pos[1], e);
                        dessinerLigne(depart, pos, Color.Gray, e);
                        break;
                    case "Feu":
                        dessinerVehiculePompier(pos[0], pos[1], e);
                        dessinerLigne(depart, pos, Color.Yellow, e);
                        break;
                    case "Secours":
                        dessinerVehiculeSecours(pos[0], pos[1], e);
                        dessinerLigne(depart, pos, Color.Red, e);
                        break;
                }              
            }
        }

        private void afficherClientsSurCarte(PaintEventArgs e) //Afficher tous les clients sur la carte
        {
            int nb = lstAeroports.Items.Count; //Nombre d'aéroports
            List<string> clients; //Liste des clients
            string[] infos; //Infos sur le client
            string type; //Le type de client

            for (int i = 0; i < nb; i++)
            {
                clients = m_scenario.obtenirClients(i);

                for (int j = 0; j < clients.Count; j++)
                {
                    infos = clients[j].Split(',');
                    type = infos[0];
                    int x = Convert.ToInt32(infos[1]);
                    int y = Convert.ToInt32(infos[2]);

                    switch (type)
                    {
                        case "Observation":
                            dessinerObservateur(x, y, e);
                            break;
                        case "Feu":
                            dessinerFeu(x, y, e);
                            break;
                        case "Secours":
                            dessinerSecours(x, y, e);
                            break;
                    }
                }
            }
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

        private void dessinerLigneCercle(int[] p_depart, int[] p_dest, Color p_couleur, PaintEventArgs e) //Dessiner une ligne qui se termine par un cercle
        {
            int rayon = 25; //Rayon du cercle
            Pen pen = new Pen(p_couleur, 2);
            e.Graphics.DrawLine(pen, p_depart[0], p_depart[1], p_dest[0], p_dest[1]);
            e.Graphics.DrawEllipse(pen, p_dest[0] - rayon, p_dest[1] - rayon, rayon * 2, rayon * 2);
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

        private void dessinerVehiculeSecours(int p_x, int p_y, PaintEventArgs e) //Dessiner un véhicule de secours
        {
            Image img = Image.FromFile("..\\..\\images\\vehsecours.png");
            Rectangle rect = new Rectangle(0, 0, 20, 20);
            e.Graphics.DrawImage(img, p_x - 10, p_y - 10, rect, GraphicsUnit.Pixel);
        }

        private void dessinerVehiculePass(int p_x, int p_y, PaintEventArgs e) //Dessiner un véhicule de passagers
        {
            Image img = Image.FromFile("..\\..\\images\\vehpass.png");
            Rectangle rect = new Rectangle(0, 0, 20, 20);
            e.Graphics.DrawImage(img, p_x - 10, p_y - 10, rect, GraphicsUnit.Pixel);
        }

        private void dessinerVehiculeMarch(int p_x, int p_y, PaintEventArgs e) //Dessiner un véhicule de marchandises
        {
            Image img = Image.FromFile("..\\..\\images\\vehmarch.png");
            Rectangle rect = new Rectangle(0, 0, 20, 20);
            e.Graphics.DrawImage(img, p_x - 10, p_y - 10, rect, GraphicsUnit.Pixel);
        }

        private void dessinerVehiculePompier(int p_x, int p_y, PaintEventArgs e) //Dessiner un véhicule pompier
        {
            Image img = Image.FromFile("..\\..\\images\\vehpompier.png");
            Rectangle rect = new Rectangle(0, 0, 20, 20);
            e.Graphics.DrawImage(img, p_x - 10, p_y - 10, rect, GraphicsUnit.Pixel);
        }

        private void dessinerVehiculeObservateur(int p_x, int p_y, PaintEventArgs e) //Dessiner un véhicule observateur
        {
            Image img = Image.FromFile("..\\..\\images\\vehobs.png");
            Rectangle rect = new Rectangle(0, 0, 20, 20);
            e.Graphics.DrawImage(img, p_x - 10, p_y - 10, rect, GraphicsUnit.Pixel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                button1.Text = "Création en cours...";
                timer1.Start();
                start = !start;
            }
            else
            {
                button1.Text = "Créer au X secondes.";
                timer1.Stop();
                start = !start;
            }

            imgCarte.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_simulateur.go();
            imgCarte.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_simulateur.creer();
        }
    }
}
