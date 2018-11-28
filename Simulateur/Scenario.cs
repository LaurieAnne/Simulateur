using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Scenario
    {
        private List<Aeroport> m_aeroports; //Liste d'aéroports
        private List<Client> m_clients; //Liste de clients
        private Chrono m_chrono; //Le chrono du scénario
        private Simulateur m_simulateur; //Le simulateur
        private Thread thread; //Thread de la boucle

        public Scenario() //Constructeur
        {
            m_aeroports = new List<Aeroport>();
            m_clients = new List<Client>();
            m_chrono = new Chrono();
        }

        public void assignerSimulateur(Simulateur p_simulateur) //Assigner simulateur
        {
            m_simulateur = p_simulateur;
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
            Usine usine = Usine.obtenirUsine();
            m_clients.Add(usine.creerFeu(rnd));
            m_clients.Add(usine.creerFeu(rnd));
            m_clients.Add(usine.creerObservateur(rnd));
            m_clients.Add(usine.creerObservateur(rnd));
            m_clients.Add(usine.creerSecours(rnd));
            m_clients.Add(usine.creerSecours(rnd));
            creerClientsTransport(rnd);
        }

        private void creerClientsTransport(Random p_rnd)
        {
            List<PosCarte> posAeroports = aeroportsPosListe(); //Liste de pos
            Aeroport aeroport; //Aéroport de départ
            Usine usine = Usine.obtenirUsine();

            Passager passager1 = usine.creerPassager(p_rnd, posAeroports);
            aeroport = aeroportCorrespondant(passager1.PositionDepart);
            aeroport.ajouterClient(passager1);

            Passager passager2 = usine.creerPassager(p_rnd, posAeroports);
            aeroport = aeroportCorrespondant(passager2.PositionDepart);
            aeroport.ajouterClient(passager2);

            Marchandise marchandise1 = usine.creerMarchandise(p_rnd, posAeroports);
            aeroport = aeroportCorrespondant(marchandise1.PositionDepart);
            aeroport.ajouterClient(marchandise1);

            Marchandise marchandise2 = usine.creerMarchandise(p_rnd, posAeroports);
            aeroport = aeroportCorrespondant(marchandise2.PositionDepart);
            aeroport.ajouterClient(marchandise2);
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

        public void transfererVehicule(Vehicule p_vehicule, PosCarte p_posAero) //Transférer le véhicule entre aéroports
        {
            Aeroport aeroport = aeroportCorrespondant(p_posAero);

            aeroport.ajouterVehicule(p_vehicule);
        }

        public string obtenirTemps() //Obtenir le temps pour l'afficher
        {
            return m_chrono.ToString();
        }

        public void changerTemps(int p_temps) //Changer le temps des sauts
        {
            m_chrono.changerSauts(p_temps);
        }
        
        public void start() //Démarrer la boucle
        {
            thread = new Thread(Go);
            thread.Start();
            creerClients();
        }

        public void Go() //Boucle
        {
            int heure = m_chrono.Heures;

            while (true)
            {
                Thread.Sleep(700);
                m_chrono.avancerTemps();

                if (m_chrono.Heures > heure) //Si c'est une nouvelle heure
                {
                    creerClients();
                }
                assignerClients();
                avancerVehicules(m_chrono.Saut);
                m_simulateur.refreshForm();
            }
        }

        public void tuerThread() //Arrêter la boucle
        {
            thread.Abort();
        }
    }
}
