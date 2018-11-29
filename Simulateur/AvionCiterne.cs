using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class AvionCiterne : Vehicule //Véhicule de type citerne (pour éteindre les feux)
    {
        int m_tempsChargement; //Temps de chargement
        int m_tempsLargage; //Temps de largage
        protected Feu m_client; //Le client Feu

        /** Constructeur d'un avion citerne
         * p_nom: le nom du véhicule
         * p_KMH: la vitesse de déplacement de l'avion
         * p_tempsMain: le temps de maintenance
         * p_couleur: la couleur de la ligne à l'affichage
         * p_posAeroport: position de l'aeroport qui le contient (pour extraire ses coordonnées)
         * p_tempsCharg: le temps d'embarquement de l'avion
         * p_tempsLarg: le temps de debarquement de l'avion
         * p_scenario: référence sur le scenario
         * p_aeroport: référence sur l'aeroport dans lequel il est
         */
        public AvionCiterne(string p_nom, int p_KMH, int p_tempsMain, int p_tempsCharg, int p_tempsLarg, PosCarte p_posAeroport, Scenario p_scenario, Aeroport p_aeroport)
            : base(p_nom, p_KMH, p_tempsMain, Color.Yellow, p_posAeroport, p_scenario, p_aeroport)
        {
            m_tempsChargement = p_tempsCharg;
            m_tempsLargage = p_tempsLarg;
        }

        /**Constructeur vide pour XML
         */
        public AvionCiterne() : base() { }

        /** Changer l'État du véhicule (Delegate)
         *  Passer au prochain État lorsque l'État actuel annonce qu'il est prêt à changer
         */
        public override void ChangerEtat(object source)
        {
            string EtatAvant = m_etat.ToString(); //To delete aide visuel
            int surplus = m_etat.Surplus;
            Usine usine = Usine.obtenirUsine();

            //Si l'etat de l'avion est dans le hangar et qu'un client est assigné
            if (m_etat.ToString() == "Hangar" && m_client != null)
            {
                PosCarte posDestination = m_client.PositionDepart;
                PosCarte posActuelle = usine.creerPosition(m_posDepart.X, m_posDepart.Y);
                int intensite = m_client.IntensiteFeu;
                int tempsVol = PosCarte.Distance(m_posDepart, posDestination) * 4; //Calcul du temps de vol

                //Créer l'Etat et s'abonner (AllerRetour)
                m_etat = usine.creerAllerRetour(m_posDepart, posActuelle, posDestination, tempsVol, surplus, intensite, this);
                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);

                if (surplus > 0)
                    m_etat.Avance(surplus);
            }
            else if (m_etat.ToString() == "AllerRetour")
            {
                //Créer l'Etat et s'abonner (Maintenance)
                m_etat = usine.creerMaintenance(m_tempsMaintenance, surplus, this);
                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);

                if (surplus > 0)
                    m_etat.Avance(surplus);
            }
            else if (m_etat.ToString() == "Maintenance")
            {
                //Créer l'Etat et s'abonner (Hangar)
                m_etat = usine.creerHangar(this);
                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);

                ResetClient();
            }
        }

        /** Assigne un client au véhicule
         *  p_client: le client qui lui est assigné
         */
        public override void AssignerClient(Client p_client)
        {
            if (p_client is Feu)
                m_client = (Feu)p_client;
        }

        public override void ResetClient()
        {
            m_client = null;
        }

        /** Accesseurs
         */
        public int Chargement
        {
            get { return m_tempsChargement; }
            set { m_tempsChargement = value; }
        }

        public int Largage
        {
            get { return m_tempsLargage; }
            set { m_tempsLargage = value; }
        }

        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Pompier)->(" + m_etat.ToString() + ")";
            return vehicule;
        }

        public override string Type()
        {
            return "Feu";
        }

        public override Client Client()
        {
            return m_client;
        }
    }
}
