using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur
{
    public abstract class AvionTransport : Vehicule
    {
        protected int m_tempsEmbarquement; //Temps d'embarquement
        protected int m_tempsDebarquement; //Temps de débarquement
        protected ClientTransport m_client; //Le client de transport

        public AvionTransport(string p_nom, int p_KMH, int p_tempsMain, int p_tempsEmb, int p_tempsDeb, ConsoleColor p_couleur, Aeroport p_aeroport, ClientTransport p_client) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, p_couleur, p_aeroport)
        {
            m_tempsEmbarquement = p_tempsEmb;
            m_tempsDebarquement = p_tempsDeb;
            m_client = p_client;
        }



        //?Todelete?
        public override void AssignerClient(Client p_client)
        {
            if (p_client is ClientTransport)
                m_client = (ClientTransport)p_client;
        }


        //Constructeur vide pour XML
        public AvionTransport() : base()
        {
        }


        //Changer d'Etat
        public override void ChangerEtat(object source)
        {
            if (m_client != null)
            {
                string EtatAvant = m_etat.ToString();

                if (m_etat.ToString() == "Hangar")
                {
                    m_etat = new Embarquement(m_tempsEmbarquement);
                }
                else if (m_etat.ToString() == "Embarquement")
                {
                    Aeroport aeDepart = m_client.AeroportDepart;
                    Aeroport aeDestination = m_client.AeroportDestination;
                    int nbClients = m_client.NbClients;
                    int tempsVol = m_KMH; //Formule ?
                    m_etat = new Aller(aeDepart, m_posActuelle, nbClients, tempsVol, aeDestination);
                }
                else if (m_etat.ToString() == "Aller")
                {
                    int nbClients = m_client.NbClients;
                    m_etat = new Debarquement(nbClients, m_tempsDebarquement);
                }
                else if (m_etat.ToString() == "Debarquement")
                {
                    m_etat = new Maintenance(m_tempsMaintenance);
                }
                else if (m_etat.ToString() == "Maintenance")
                {
                    m_etat = new Hangar(0);
                }

                MessageBox.Show(this.m_nom + " : " + EtatAvant + "->" + this.m_etat.ToString() + " ! Temps avant prochaine action: " + this.m_etat.Temps); //Ne pas oublier de delete la référence using System.Windows.Forms;
                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
            }
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
