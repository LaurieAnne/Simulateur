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
        public AvionTransport(string p_nom, int p_KMH, int p_tempsMain, int p_tempsEmb, int p_tempsDeb, Color p_couleur, Aeroport p_aeroport) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, p_couleur, p_aeroport)
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
            if (m_client != null)
            {
                string EtatAvant = m_etat.ToString();
                int surplus = m_etat.Surplus;

                if (m_etat.ToString() == "Hangar")
                {
                    m_etat = new Embarquement(m_tempsEmbarquement - surplus, this);
                }
                else if (m_etat.ToString() == "Embarquement")
                {
                    PosCarte posDestination = m_client.Position;
                    int nbClients = m_client.NbClients;
                    int tempsVol = m_KMH; //Formule ?
                    m_etat = new Aller(m_posDepart, m_posDepart, posDestination, nbClients, tempsVol - surplus, this);
                }
                else if (m_etat.ToString() == "Aller")
                {
                    int nbClients = m_client.NbClients;
                    m_etat = new Debarquement(nbClients, m_tempsDebarquement - surplus, this);
                }
                else if (m_etat.ToString() == "Debarquement")
                {
                    m_etat = new Maintenance(m_tempsMaintenance - surplus, this);
                }
                else if (m_etat.ToString() == "Maintenance")
                {
                    m_etat = new Hangar(0, this);
                }

                //To delete aide visuel
                MessageBox.Show(this.m_nom + " : " + EtatAvant + "->" + this.m_etat.ToString() + " ! Temps avant prochaine action: " + this.m_etat.Temps); //Ne pas oublier de delete la référence using System.Windows.Forms;

                //S'abonne au nouvel Etat
                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
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
    }
}
