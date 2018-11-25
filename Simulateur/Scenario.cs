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

        public void creerClients() //Créer les clients pour le tour
        {
            m_clients.Add(new Feu());

            for (int i = 0; i < m_clients.Count; i++)
            {
                assignerClient(m_clients[i]);
            }             
        }

        public void assignerClient(Client p_client) //Assigner le client à un aéroport proche
        {
            Aeroport AeroportPlusProche = null; //Aéroport la plus proche

            int PosX = p_client.PositionX; //X du client
            int PosY = p_client.PositionY; //Y du client

            int DistancesX = 0; //Distance entre les X
            int DistancesY = 0; //Distance entre les Y
            int DistanceTotal = 0; //Distance entre le client et l'aéroport
            int DistancePlusProche = 0; //La distance la moins grande
            int IndAeroport = 0; //L'aéroport le moins loin

            for (int i = 0; i < m_aeroports.Count; i++)
            {
                int PosXAeroport = m_aeroports[i].Pos.X; //X de l'aéroport
                int PosYAeroport = m_aeroports[i].Pos.Y; //Y de l'aéroport

                DistancesX = Math.Abs(PosX - PosXAeroport);
                DistancesY = Math.Abs(PosY - PosYAeroport);
                DistanceTotal = DistancesX + DistancesY;

                if (i == 0)
                {
                    DistancePlusProche = DistanceTotal;
                    IndAeroport = i;
                }
                else if (DistanceTotal < DistancePlusProche) //Si moins loin
                {
                    DistancePlusProche = DistanceTotal;
                    IndAeroport = i;
                }
            }

            AeroportPlusProche = m_aeroports[IndAeroport];

            if (AeroportPlusProche.assignerClient(p_client)) //Si un véhicule est disponible
            {
                m_clients.Remove(p_client);
            }
        }
    }
}
