using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Scenario
    {
        private List<Aeroport> m_aeroports; //Liste d'aéroports

        public Scenario() //Constructeur
        {
            m_aeroports = new List<Aeroport>();
        }

        public List<Aeroport> ListeAeroports
        {
            get { return m_aeroports; }
            set { m_aeroports = value; }
        }

        public string[] obtenirAeroports() //Obtenir tous les aéroports
        {
            string[] aeroports = new string[m_aeroports.Count];

            for (int i = 0; i < m_aeroports.Count; i++)
            {
                aeroports[i] = m_aeroports[i].ToString();
            }

            return aeroports;
        }

        public string[] obtenirVehicules(int p_aeroport) //Obtenir tous les véhicules d'un aéroport
        {
            string[] vehicules = m_aeroports[p_aeroport].obtenirVehicules();
            return vehicules;
        }
    }
}
