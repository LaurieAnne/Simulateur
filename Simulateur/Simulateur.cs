﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Simulateur
{
    [XmlRoot]
    public class Simulateur
    {
        private FormMenu m_menu; //Menu
        private FormSimulateur m_interface; //Interface
        private Scenario m_scenario; //Façade/Médiateur

        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Simulateur m_simulateur = new Simulateur();
        }

        public Simulateur() //Constructeur
        {
            m_menu = new FormMenu(this);
            Application.Run(m_menu);

            if (m_scenario != null)
            {
                m_interface = new FormSimulateur(this, m_scenario);
                Application.Run(m_interface);
                m_scenario.tuerThread();
            }
        }

        public bool recupererScenario(string p_nom) //Récupérer le scénario
        {
            XmlSerializer xs = new XmlSerializer(typeof(Scenario));
            string path = "..\\..\\..\\Scénarios XML\\" + p_nom + ".xml";

            if (File.Exists(path))
            {
                using (StreamReader rd = new StreamReader(path))
                {
                    m_scenario = xs.Deserialize(rd) as Scenario;
                    m_scenario.assignerScenario();
                    m_scenario.assignerSimulateur(this);
                    return true;
                }
            }

            return false;
        }

        public void refreshForm() //Rafraîchir les données
        {
            m_interface.refreshForm();
        }
    }
}
