using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur
{
    public class AvionCiterne : Vehicule
    {
        int m_tempsChargement; //Temps de chargement
        int m_tempsLargage; //Temps de largage
        protected Feu m_client; //Le client Feu

        public AvionCiterne(string p_nom, int p_KMH, int p_tempsMain, int p_tempsCharg, int p_tempsLarg, Aeroport p_aeroport) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, ConsoleColor.Yellow, p_aeroport)
        {
            m_tempsChargement = p_tempsCharg;
            m_tempsLargage = p_tempsLarg;
        }

        //Changer d'Etat
        public override void ChangerEtat(object source)
        {
            if (m_client != null)
            {
                string EtatAvant = m_etat.ToString();

                if (m_etat.ToString() == "Hangar")
                {
                    PosCarte posDestination = m_client.Position;
                    int tempsVol = m_KMH; //Formule ?
                    m_etat = new AllerRetour(m_posDepart, m_posDepart, posDestination, tempsVol);
                    MessageBox.Show(this.m_nom + " : " + EtatAvant + "->" + this.m_etat.ToString() + " ! Temps avant prochaine action: " + this.m_etat.Temps); //Ne pas oublier de delete la référence using System.Windows.Forms;
                }
                else if (m_etat.ToString() == "AllerRetour")
                {
                    AllerRetour m_etatz;
                    m_etatz = (AllerRetour)this.m_etat;
                    m_etat = new Maintenance(m_tempsMaintenance);
                    MessageBox.Show(this.m_nom + " : " + EtatAvant + "->" + this.m_etat.ToString() + " ! Temps avant prochaine action: " + this.m_etat.Temps + "*" + m_etatz.Compte.ToString()); //Ne pas oublier de delete la référence using System.Windows.Forms;
                }
                else if (m_etat.ToString() == "Maintenance")
                {
                    m_etat = new Hangar(0);
                    MessageBox.Show(this.m_nom + " : " + EtatAvant + "->" + this.m_etat.ToString() + " ! Temps avant prochaine action: " + this.m_etat.Temps); //Ne pas oublier de delete la référence using System.Windows.Forms;
                }

                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
            }
        }

        //?Todelete?
        public override void AssignerClient(Client p_client)
        {
            if (p_client is Feu)
                m_client = (Feu)p_client;
        }


        





        //Constructeur vide pour XML
        public AvionCiterne() : base(){}

        /**Accesseurs
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
            vehicule = m_nom + " (Pompier)";
            return vehicule;
        }
    }
}
