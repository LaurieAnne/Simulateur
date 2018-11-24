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

        public string[] obtenirPosAeroports() //Obtenir l'emplacement de l'aéroport
        {
            string[] aeroports = new string[m_aeroports.Count]; //Les infos de tous les aéroports
            string aeroport; //Les infos de l'aéroport
           
            for (int i = 0; i < m_aeroports.Count; i++)
            {
                PosCarte posCarte = m_aeroports[i].Pos;
                aeroport = m_aeroports[i].Nom + "," + posCarte.X + "," + posCarte.Y;
                aeroports[i] = aeroport;
            }

            return aeroports;
        }

        public string[] obtenirVehicules(int p_aeroport) //Obtenir tous les véhicules d'un aéroport
        {
            string[] vehicules = m_aeroports[p_aeroport].obtenirVehicules();
            return vehicules;
        }

        //TESTAGE DÉGUEULASSE =>

        public void avancerVehicules(int p_temps) //Avancer les véhicules
        {          
            for (int i = 0; i < m_aeroports.Count; i++)
            {
                m_aeroports[i].avancerVehicules(p_temps);
            }
        }

        public List<string> obtenirVehiculesEnVol() //Obtenir les avions en vol
        {
            List<string> vehicules = new List<string>(); //Infos de tous les véhicules en vol
            List<string> enVol; //Infos des véhicules en vol d'un aéroport

            for (int i = 0; i < m_aeroports.Count; i++)
            {
                enVol = m_aeroports[i].obtenirVehiculesEnVol();
                if (enVol.Count > 0) //Si l'aéroport a des avions en vol
                {
                    for (int j = 0; j < enVol.Count - 1; j++)
                    {
                        vehicules.Add(enVol[j]);
                    }
                }
            }

            return vehicules;
        }
    }
}
