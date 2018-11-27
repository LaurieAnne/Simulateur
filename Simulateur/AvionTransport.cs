using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur
{
    public abstract class AvionTransport : Vehicule //Véhicule de type transport
    {
        const int nbMax = 500; //Le nombre maximum de clients (passager/marchandises)
        const double pourcentage = 0.75; //Le % avant d'être prêt à partir
        protected int m_tempsEmbarquement; //Temps d'embarquement
        protected int m_tempsDebarquement; //Temps de débarquement
        protected ClientTransport m_client; //Le client de transport


        /** Constructeur d'un avion de transport
         * p_nom: le nom du véhicule
         * p_KMH: la vitesse de déplacement de l'avion
         * p_tempsMain: le temps de maintenance
         * p_couleur: la couleur de la ligne à l'affichage
         * p_aeroport: l'aeroport qui le contient (pour extraire ses coordonnées)
         * p_tempsEmb: le temps d'embarquement de l'avion
         * p_tempsDeb: le temps de debarquement de l'avion
         */
        public AvionTransport(string p_nom, int p_KMH, int p_tempsMain, int p_tempsEmb, int p_tempsDeb, Color p_couleur, PosCarte p_posAeroport, Scenario p_scenario) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, p_couleur, p_posAeroport, p_scenario)
        {
            m_tempsEmbarquement = p_tempsEmb;
            m_tempsDebarquement = p_tempsDeb;
        }

        /**Constructeur vide pour XML
         */
        public AvionTransport() : base()
        {
        }


        /** Changer l'État du véhicule (Delegate)
         *  Passer au prochain État lorsque l'État actuel annonce qu'il est prêt à changer
         */
        public override void ChangerEtat(object source)
        {
            if ((m_client != null) && (m_client.NbClients >= (nbMax * pourcentage)))
            {
                string EtatAvant = m_etat.ToString();
                int surplus = m_etat.Surplus;
                Usine usine = Usine.obtenirUsine();

                if (m_etat.ToString() == "Hangar")
                {
                    m_etat = usine.creerEmbarquement(m_tempsEmbarquement, surplus, this);
                    //S'abonne au nouvel événement
                    m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
                }
                else if (m_etat.ToString() == "Embarquement")
                {
                    PosCarte posDestination = m_client.Destination;
                    PosCarte posActuelle = usine.creerPosition(m_posDepart.X, m_posDepart.Y); //Position actuelle

                    int nbClients = m_client.NbClients;
                    int tempsVol = PosCarte.Distance(m_posDepart, posDestination) * 4;
                    m_etat = usine.creerAller(m_posDepart, posActuelle, posDestination, nbClients, tempsVol, surplus, this);
                    //S'abonne au nouvel événement
                    m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
                }
                else if (m_etat.ToString() == "Aller")
                {
                    int nbClients = m_client.NbClients;
                    m_etat = usine.creerDebarquement(nbClients, m_tempsDebarquement, surplus, this);
                    //S'abonne au nouvel événement
                    m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
                }
                else if (m_etat.ToString() == "Debarquement")
                {
                    m_etat = usine.creerMaintenance(m_tempsMaintenance, surplus, this);
                    //S'abonne au nouvel événement
                    m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
                }
                else if (m_etat.ToString() == "Maintenance")
                {
                    m_etat = usine.creerHangar(this);
                    m_client = null;
                    this.ResetEtat();
                    //To delete aide visuel
                    //MessageBox.Show("Terminé: " + this.m_nom + " est au hangar"); //Ne pas oublier de delete la référence using System.Windows.Forms;
                }
            }
        }

        /** Assigne un client au véhicule
          *  p_client: le client qui lui est assigné
          */
        public override void AssignerClient(Client p_client)
        {
            if (p_client is ClientTransport)
                m_client = (ClientTransport)p_client;
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

        public Client Client
        {
            get { return m_client; }
        }
    }
}
