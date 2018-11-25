using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
         * p_aeroport: l'aeroport qui le contient (pour extraire ses coordonnées)
         * p_tempsChargement: le temps de chargement de l'avion
         * p_tempsLargage: le temps de largage de l'avion
         */
        public AvionCiterne(string p_nom, int p_KMH, int p_tempsMain, int p_tempsCharg, int p_tempsLarg, PosCarte p_posAeroport)
            : base(p_nom, p_KMH, p_tempsMain, Color.Yellow, p_posAeroport)
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
            if (m_client != null)
            {
                string EtatAvant = m_etat.ToString(); //To delete aide visuel
                int surplus = m_etat.Surplus;
                Usine usine = Usine.obtenirUsine();

                if (m_etat.ToString() == "Hangar")
                {
                    PosCarte posDestination = m_client.Position; //Position destination
                    int intensite = 2;
                    int tempsVol = m_KMH; //Formule ?
                    m_etat = usine.creerAllerRetour(m_posDepart, posDestination, tempsVol, surplus, intensite, this);
                    //To delete aide visuel
                    MessageBox.Show(this.m_nom + " : " + EtatAvant + "->" + this.m_etat.ToString() + " ! Temps avant prochaine action: " + this.m_etat.Temps); //Ne pas oublier de delete la référence using System.Windows.Forms;
                }
                else if (m_etat.ToString() == "AllerRetour")
                {
                    AllerRetour m_etatz;//To delete aide visuel
                    m_etatz = (AllerRetour)this.m_etat;//To delete aide visuel

                    m_etat = usine.creerMaintenance(m_tempsMaintenance, surplus, this);

                    //To delete aide visuel
                    MessageBox.Show(this.m_nom + " : " + EtatAvant + "->" + this.m_etat.ToString() + " ! Temps avant prochaine action: " + this.m_etat.Temps + "*" + m_etatz.Compte.ToString()); //Ne pas oublier de delete la référence using System.Windows.Forms;
                }
                else if (m_etat.ToString() == "Maintenance")
                {
                    m_etat = usine.creerHangar(this);
                    //To delete aide visuel
                    MessageBox.Show(this.m_nom + " : " + EtatAvant + "->" + this.m_etat.ToString() + " ! Temps avant prochaine action: " + this.m_etat.Temps); //Ne pas oublier de delete la référence using System.Windows.Forms;
                }

                //S'abonne au nouvel événement
                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
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
            vehicule = m_nom + " (Pompier)";
            return vehicule;
        }
    }
}
