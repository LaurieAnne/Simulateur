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
    public partial class FormMenu : Form
    {
        private Simulateur m_simulateur; //Simulateur

        public FormMenu(Simulateur p_sim) //Constructeur
        {
            InitializeComponent();
            m_simulateur = p_sim;
        }

        private void cmdRecuperer_Click(object sender, EventArgs e) //Loader le scénario
        {
            string nom = txtRecuperer.Text; //Nom du scénario

            if (nom != "")
            {
                if (m_simulateur.recupererScenario(nom))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cet XML n'existe pas dans le dossier 'Scénarios XML'.");
                }
            }
        }
    }
}
