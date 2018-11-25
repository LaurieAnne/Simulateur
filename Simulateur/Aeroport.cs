using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Simulateur
{
    public class Aeroport
    {
        private string m_nom; //Nom
        private int m_minPassagers; //Minimum de passagers
        private int m_maxPassagers; //Maxiumum de passagers
        private int m_minMarchandises; //Minimum de marchandises
        private int m_maxMarchandises; //Maximum de marchandises
        private List<Vehicule> m_vehicules; //Liste de véhicules
        private PosCarte m_pos; //Emplacement de l'aéroport

        public Aeroport(string p_nom, int p_minPass, int p_maxPass, int p_minMarch, int p_maxMarch, PosCarte p_pos) //Constructeur
        {
            m_nom = p_nom;
            m_minPassagers = p_minPass;
            m_maxPassagers = p_maxPass;
            m_minMarchandises = p_minMarch;
            m_maxMarchandises = p_maxMarch;
            m_vehicules = new List<Vehicule>();
            m_pos = p_pos;
        }

        public Aeroport()
        {

        }

        public List<Vehicule> ListeVehicules
        {
            get { return m_vehicules; }
            set { m_vehicules = value; }
        }

        public string Nom
        {
            get { return m_nom; }
            set { m_nom = value; }
        }

        public int MinPass
        {
            get { return m_minPassagers; }
            set { m_minPassagers = value; }
        }

        public int MaxPass
        {
            get { return m_maxPassagers; }
            set { m_maxPassagers = value; }
        }

        public int MinMarch
        {
            get { return m_minMarchandises; }
            set { m_minMarchandises = value; }
        }

        public int MaxMarch
        {
            get { return m_maxMarchandises; }
            set { m_maxMarchandises = value; }
        }

        public PosCarte Pos
        {
            get { return m_pos; }
            set { m_pos = value; }
        }

        public override string ToString() //ToString
        {
            string aeroport;
            string coord = m_pos.ToString();
            aeroport = m_nom + " (" + coord + ")";
            return aeroport;
        }

        public string[] obtenirVehicules() //Obtenir tous les véhicules
        {
            string[] vehicules = new string[m_vehicules.Count];

            for (int i = 0; i < m_vehicules.Count; i++)
            {
                vehicules[i] = m_vehicules[i].ToString();
            }

            return vehicules;
        }

        //TESTAGE DÉGUEULASSE =>

        public void avancerVehicules(int p_temps) //Avancer les véhicules
        {
            for (int i = 0; i < m_vehicules.Count; i++)
            {
                m_vehicules[i].Avance(p_temps);
            }
        }

        public List<string> obtenirVehiculesEnVol() //Obtenir les avions en vol
        {
            List<string> vehicules = new List<string>(); //Infos des véhicules en vol

            for (int i = 0; i < m_vehicules.Count; i++)
            {
                if (m_vehicules[i].enVol()) //Si le véhicule est en vol
                {
                    string infos = m_vehicules[i].Couleur + "," + m_vehicules[i].obtenirPosVehicule();
                    vehicules.Add(infos);
                }
            }

            return vehicules;
        }

        public bool assignerClient(Client p_client) //Assigner le client à un véhicule
        {
            string type = p_client.ToString(); //Type du client

            for (int i = 0; i < m_vehicules.Count; i++)
            {
                if (type = m_vehicules[i].Type) //Si c'est le bon type
                {
                    m_vehicules[i].AssignerClient(p_client);
                    return true;
                }
            }
            return false;
        }
    }
}
