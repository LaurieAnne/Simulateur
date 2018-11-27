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
        private List<Client> m_clients; //Liste de clients

        public Scenario() //Constructeur
        {
            m_aeroports = new List<Aeroport>();
            m_clients = new List<Client>();
        }

        public List<Aeroport> ListeAeroports //Accesseur aéroports
        {
            get { return m_aeroports; }
            set { m_aeroports = value; }
        }

        public List<Client> ListeClients //Accesseur clients
        {
            get { return m_clients; }
            set { m_clients = value; }
        }

        public void assignerScenario() //Assigner le scénario à tous les véhicules
        {
            int compteAeroport = m_aeroports.Count;
            for (int i = 0; i < compteAeroport; i++)
            {
                m_aeroports[i].Scenario = this;
                m_aeroports[i].assignerScenarioVehicules();
            }
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

        public string[] obtenirPosAeroports() //Obtenir l'emplacement des aéroports
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
                    for (int j = 0; j < enVol.Count; j++)
                    {
                        vehicules.Add(enVol[j]);
                    }
                }
            }

            return vehicules;
        }

        public List<string> obtenirClients(int p_aeroport) //Obtenir les clients
        {
            return m_aeroports[p_aeroport].obtenirClients();
        }

        public void creerClients() //Créer les clients pour le tour
        {
            Random rnd = new Random();
            m_clients.Add(new Feu(rnd));
            m_clients.Add(new Feu(rnd));
            m_clients.Add(new Feu(rnd));
            m_clients.Add(new Observateur(rnd));
            m_clients.Add(new Observateur(rnd));
            m_clients.Add(new Secours(rnd));
            m_clients.Add(new Secours(rnd));

            List<PosCarte> posAeroports = aeroportsPosListe(); //Liste de pos
            creerPassager(rnd, posAeroports);
            creerMarchandise(rnd, posAeroports);
        }

        private void creerPassager(Random p_rnd, List<PosCarte> p_posAeroports) //Créer un client passager
        {
            Passager passager = new Passager(p_rnd); //Passager
            Aeroport aeroport; //Aéroport de départ

            passager.TrouverDestination(p_posAeroports);
            passager.TrouverDepart(p_posAeroports);
            aeroport = aeroportCorrespondant(passager.PositionDepart);

            aeroport.ajouterClient(passager); //Ajouter dans l'aéroport
        }

        private void creerMarchandise(Random p_rnd, List<PosCarte> p_posAeroports) //Créer un client marchandise
        {
            Marchandise marchandise = new Marchandise(p_rnd); //Passager
            Aeroport aeroport; //Aéroport de départ

            marchandise.TrouverDestination(p_posAeroports);
            marchandise.TrouverDepart(p_posAeroports);
            aeroport = aeroportCorrespondant(marchandise.PositionDepart);

            aeroport.ajouterClient(marchandise); //Ajouter dans l'aéroport
        }

        public void assignerClients() //Assigner les clients en attente
        {
            int compte = m_clients.Count - 1; //Nombre de clients à assigner

            for (int i = compte; i >= 0; i--)
            {
                if (assignerClient(m_clients[i]))
                {
                    m_clients.Remove(m_clients[i]);
                }
            }

            for (int i = 0; i < m_aeroports.Count; i++) //Transport
            {
                m_aeroports[i].assignerClientsTransport();
            }
        }

        private bool assignerClient(Client p_client) //Assigner le client à un aéroport proche
        {
            Aeroport AeroportProche = null; //Aéroport la plus proche

            int PosX = p_client.PositionX; //X du client
            int PosY = p_client.PositionY; //Y du client

            int DistancesX = 0; //Distance entre les X
            int DistancesY = 0; //Distance entre les Y
            int Distance = 0; //Distance entre le client et l'aéroport
            int DistanceProche = 9999999; //La distance la moins grande

            for (int i = 0; i < m_aeroports.Count; i++)
            {
                int PosXAeroport = m_aeroports[i].Pos.X; //X de l'aéroport
                int PosYAeroport = m_aeroports[i].Pos.Y; //Y de l'aéroport

                DistancesX = Math.Abs(PosX - PosXAeroport);
                DistancesY = Math.Abs(PosY - PosYAeroport);
                Distance = DistancesX + DistancesY;

                if (Distance < DistanceProche && m_aeroports[i].assignerClientPossible(p_client)) //Si moins loin
                {
                    DistanceProche = Distance;
                    AeroportProche = m_aeroports[i];
                }
            }          

            if ((AeroportProche != null) && (AeroportProche.assignerClientPossible(p_client))) //Si un véhicule est disponible
            {
                AeroportProche.assignerClient(p_client);
                return true;
            }

            return false;
        }

        private List<PosCarte> aeroportsPosListe() //Lister les emplacements des aéroports
        {
            List<PosCarte> posAeroports = new List<PosCarte>();

            for (int i = 0; i < m_aeroports.Count; i++)
            {
                posAeroports.Add(m_aeroports[i].Pos);
            }

            return posAeroports;
        }

        private Aeroport aeroportCorrespondant(PosCarte p_pos) //Trouver l'aéroport correspondant aux coordonnées
        {
            Aeroport aeroport = null; //Aéroport

            for (int i = 0; i < m_aeroports.Count; i++)
            {
                PosCarte posAero = m_aeroports[i].Pos; //Emplacement aéroport

                if ((posAero.X == p_pos.X) && (posAero.Y == p_pos.Y)) //Si c'est le même emplacement
                {
                    aeroport = m_aeroports[i];
                }
            }

            return aeroport;
        }
    }
}
