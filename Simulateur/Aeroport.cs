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
        private List<Client> m_clients; //Clients passagers et marchandises en attente
        private Scenario m_scenario; //Référence au scénario

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

        public Aeroport() //Constructeur vide xml
        {
            m_clients = new List<Client>();
        }

        public void assignerScenarioVehicules() //Assigner le scénario aux véhicules
        {
            int compteVehicules = m_vehicules.Count;
            for (int i = 0; i < compteVehicules; i++)
            {
                m_vehicules[i].Scenario = m_scenario;
                m_vehicules[i].Aeroport = this;
            }
        }

        public Scenario Scenario //Accesseur scénario
        {
            get { return m_scenario; }
            set { m_scenario = value; }
        }

        public List<Client> ListeClients //Accesseur clients
        {
            get { return m_clients; }
            set { m_clients = value; }
        }

        public List<Vehicule> ListeVehicules //Accesseur véhicules
        {
            get { return m_vehicules; }
            set { m_vehicules = value; }
        }

        public string Nom //Accesseur nom
        {
            get { return m_nom; }
            set { m_nom = value; }
        }

        public int MinPass //Accesseur min passagers
        {
            get { return m_minPassagers; }
            set { m_minPassagers = value; }
        }

        public int MaxPass //Accesseur max passagers
        {
            get { return m_maxPassagers; }
            set { m_maxPassagers = value; }
        }

        public int MinMarch //Accesseur min marchandises
        {
            get { return m_minMarchandises; }
            set { m_minMarchandises = value; }
        }

        public int MaxMarch //Accesseur max marchandises
        {
            get { return m_maxMarchandises; }
            set { m_maxMarchandises = value; }
        }

        public PosCarte Pos //Accesseur emplacement
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

        public void avancerVehicules(int p_temps) //Avancer tous les véhicules
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
                    string infos = m_vehicules[i].Couleur + "," + m_vehicules[i].obtenirPosVehicule() + "," + m_vehicules[i].Type();
                    vehicules.Add(infos);
                }
            }

            return vehicules;
        }

        public List<string> obtenirClients() //Obtenir les clients de l'aéroport
        {
            List<string> clients = new List<string>(); //Infos des clients

            for (int i = 0; i < m_vehicules.Count; i++)
            {
                Client client = m_vehicules[i].Client();

                if (client != null) //Si le véhicule a un client
                {                  
                    clients.Add(client.obtenirInfoClient());
                }
            }

            return clients;
        }

        public bool assignerClientPossible(Client p_client) //Si c'est possible d'assigner le client à un véhicule
        {
            string type = p_client.ToString(); //Type du client

            for (int i = 0; i < m_vehicules.Count; i++)
            {
                if ((type == m_vehicules[i].Type()) && m_vehicules[i].disponible()) //Si c'est le bon type
                {
                    return true;
                }
            }

            return false;
        }

        public void assignerClient(Client p_client) //Assigner le client à un véhicule
        {
            string type = p_client.ToString(); //Type du client

            for (int i = 0; i < m_vehicules.Count; i++)
            {
                if ((type == m_vehicules[i].Type()) && m_vehicules[i].disponible()) //Si c'est le bon type
                {
                    m_vehicules[i].AssignerClient(p_client);
                    return;
                }
            }
        }

        public void ajouterClient(Client p_client) //Ajouter un client en attente
        {
            m_clients.Add(p_client);
        }

        public void assignerClientsTransport() //Assigner les clients de ce type
        {
            int compte = m_clients.Count - 1; //Nombre de clients à assigner

            for (int i = compte; i >= 0; i--)
            {
                if (assignerClientPossible(m_clients[i]))
                {
                    assignerClientTransport(m_clients[i]);
                }
            }
        }

        private void assignerClientTransport(Client p_client) //Assigner le client à un véhicule
        {
            string type = p_client.ToString(); //Type du client
            string[] infos = p_client.obtenirInfoClient().Split(',');
            int qte = Convert.ToInt32(infos[3]); //Quantité du client
            int qteMax; //Quantité maximale du véhicule

            for (int i = 0; i < m_vehicules.Count; i++)
            {
                if ((type == m_vehicules[i].Type()) && m_vehicules[i].disponible()) //Si c'est le bon type
                {
                    qteMax = m_vehicules[i].CapaciteRestante;

                    if (qte <= qteMax) //S'il y a de l'espace
                    {
                        m_vehicules[i].AssignerClient(p_client);
                        m_clients.Remove(p_client);
                    }
                    else
                    {
                        int surplus = qte - qteMax; //Le nombre de clients en surplus

                        if (type == "Passagers")
                        {
                            Passager newPass = p_client.separerClientPassager(surplus);
                            m_vehicules[i].AssignerClient(p_client);
                            m_clients.Remove(p_client);
                            m_clients.Add(newPass);
                        }
                        else
                        {
                            Marchandise newMarch = p_client.separerClientMarchandise(surplus);
                            m_vehicules[i].AssignerClient(p_client);
                            m_clients.Remove(p_client);
                            m_clients.Add(newMarch);
                        }                      
                    }
                    return;
                }
            }
        }

        public void transfererVehicule(Vehicule p_vehicule, PosCarte p_posAero) //Transférer le véhicule entre aéroports
        {
            m_scenario.transfererVehicule(p_vehicule, p_posAero);
            m_vehicules.Remove(p_vehicule);
        }

        public void ajouterVehicule(Vehicule p_vehicule) //Ajouter le véhicule dans l'aéroport
        {
            m_vehicules.Add(p_vehicule);
        }
    }
}
