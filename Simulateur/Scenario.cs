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
        private List<PosCarte> m_posAeroports; //Liste de positions des aéroports

        public Scenario() //Constructeur
        {
            m_aeroports = new List<Aeroport>();
            m_clients = new List<Client>();
            m_posAeroports = new List<PosCarte>();
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

        /*public List<string> obtenirClients(int p_aeroport) //Obtenir les clients
        {
            return m_aeroports[p_aeroport].obtenirClients();
        }*/

        public void creerClients() //Créer les clients pour le tour
        {
            trouverPositionAeroports();

            Random rnd = new Random();

            //Créer les clients
            Passager lePassager = new Passager(rnd);
            lePassager.TrouverDestination(m_posAeroports);
            lePassager.TrouverDepart(m_posAeroports);


            Marchandise laMarchandise = new Marchandise(rnd);
            laMarchandise.TrouverDestination(m_posAeroports);
            laMarchandise.TrouverDepart(m_posAeroports);

            m_clients.Add(new Feu(rnd));
            m_clients.Add(lePassager);
            m_clients.Add(laMarchandise);
            m_clients.Add(new Observateur(rnd));
            m_clients.Add(new Secours(rnd));
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

            //m_aeroports.assignerClients (Passagers et marchandises)
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

        private void trouverPositionAeroports() //Trouver les positions des aéroports sur la carte
        {
            for (int i = 0; i < m_aeroports.Count; i++)
            {
                m_posAeroports.Add(m_aeroports[i].Pos);
            }
        }

        public List<PosCarte> ListePositionAeroports
        {
            get { return m_posAeroports; }
        }
    }
}
