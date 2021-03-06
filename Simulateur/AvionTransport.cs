﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public abstract class AvionTransport : Vehicule //Véhicule de type transport
    {
        const int nbMax = 500; //Le nombre maximum de clients (passager/marchandises)
        const double pourcentage = 0.75; //Le % avant d'être prêt à partir
        protected int m_tempsEmbarquement; //Temps d'embarquement
        protected int m_tempsDebarquement; //Temps de débarquement
        protected ClientTransport m_client; //Le client du véhicule


        /** Constructeur d'un avion de transport
         * p_nom: le nom du véhicule
         * p_KMH: la vitesse de déplacement de l'avion
         * p_tempsMain: le temps de maintenance
         * p_couleur: la couleur de la ligne à l'affichage
         * p_posAeroport: l'aeroport qui le contient
         * p_tempsEmb: le temps d'embarquement de l'avion
         * p_tempsDeb: le temps de debarquement de l'avion
         * p_scenario: référence au scenario
         * p_aeroport: référence à l'aeroport dans lequel il est
         */
        public AvionTransport(string p_nom, int p_KMH, int p_tempsMain, int p_tempsEmb, int p_tempsDeb, Color p_couleur, PosCarte p_posAeroport, Scenario p_scenario, Aeroport p_aeroport) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, p_couleur, p_posAeroport, p_scenario, p_aeroport)
        {
            m_tempsEmbarquement = p_tempsEmb;
            m_tempsDebarquement = p_tempsDeb;
        }

        /**Constructeur vide pour XML
         */
        public AvionTransport() : base(){}


        /** Changer l'État du véhicule (Delegate)
         *  Passer au prochain État lorsque l'État actuel annonce qu'il est prêt à changer
         */
        public override void ChangerEtat(object source)
        {
            int surplus = m_etat.Surplus;
            Usine usine = Usine.obtenirUsine();

            //Si l'etat de l'avion est dans le hangar et que le minimum de clients est atteint
            if (m_etat.ToString() == "Hangar" && (m_client != null) && (m_client.NbClients >= (nbMax * pourcentage)))
            {
                //Créer l'Etat et s'abonner (Embarquement)
                m_etat = usine.creerEmbarquement(m_tempsEmbarquement, surplus, this);
                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);

                if (surplus > 0)
                    m_etat.Avance(surplus);
            }
            else if (m_etat.ToString() == "Embarquement")
            {
                PosCarte posDestination = m_client.Destination;
                PosCarte posActuelle = usine.creerPosition(m_posDepart.X, m_posDepart.Y);
                int nbClients = m_client.NbClients;
                int tempsVol = PosCarte.Distance(m_posDepart, posDestination) * 4; //Calcul du temps de vol

                //Créer l'Etat et s'abonner (Aller)
                m_etat = usine.creerAller(m_posDepart, posActuelle, posDestination, nbClients, tempsVol, surplus, this);
                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);

                if (surplus > 0)
                    m_etat.Avance(surplus);
            }
            else if (m_etat.ToString() == "Aller")
            {
                int nbClients = m_client.NbClients;
                m_aeroport.transfererVehicule(this, m_etat.DestinationFinale());

                //Créer l'Etat et s'abonner (Debarquement)
                m_etat = usine.creerDebarquement(nbClients, m_tempsDebarquement, surplus, this);
                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);

                if (surplus > 0)
                    m_etat.Avance(surplus);
            }
            else if (m_etat.ToString() == "Debarquement")
            {
                m_client.NbClients = 0;

                //Créer l'Etat et s'abonner (Maintenance)
                m_etat = usine.creerMaintenance(m_tempsMaintenance, surplus, this);
                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);

                if (surplus > 0)
                    m_etat.Avance(surplus);
            }
            else if (m_etat.ToString() == "Maintenance")
            {
                //Créer l'Etat et s'abonner  (Hangar)
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
            if (p_client is ClientTransport)
            {
                if (m_client == null)
                {
                    m_client = (ClientTransport)p_client;
                }
                else
                {
                    m_client.NbClients += ((ClientTransport)p_client).NbClients;
                }
            }
        }

        public override void ResetClient()
        {
            m_client = null;
        }

        /** Accesseurs
         */
        public int Embarquement
        {
            get { return m_tempsEmbarquement; }
            set { m_tempsEmbarquement = value; }
        }

        public int Debarquement
        {
            get { return m_tempsDebarquement; }
            set { m_tempsDebarquement = value; }
        }

        public override Client Client()
        {
            return m_client;
        }

        public override int CapaciteMaximum
        {
            get{ return nbMax; }
        }

        public override int CapaciteRestante
        {
            get
            {
                if (m_client != null)
                    return nbMax - m_client.NbClients;
                else
                    return nbMax;
            }
        }

        public int CapaciteMinimale
        {
            get { return (int)(nbMax * pourcentage); }
        }

        public override bool disponible()
        {
            if (m_etat is Hangar)
            {
                if ((m_client == null) || (m_client.NbClients < nbMax))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
