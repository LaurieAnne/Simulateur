using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur
{
    public class AvionObservateur : Vehicule //Véhicule de type Observateur
    {
        protected Observateur m_client; //Le client observateur

        /** Constructeur d'un avion observateur
         * p_nom: le nom du véhicule
         * p_KMH: la vitesse de déplacement de l'avion
         * p_tempsMain: le temps de maintenance
         * p_couleur: la couleur de la ligne à l'affichage
         * p_aeroport: l'aeroport qui le contient (pour extraire ses coordonnées)
         */
        public AvionObservateur(string p_nom, int p_KMH, int p_tempsMain, PosCarte p_posAeroport) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, Color.Gray, p_posAeroport)
        {
        }

        /**Constructeur vide pour XML
        */
        public AvionObservateur() : base() { }


        /** Changer l'État du véhicule (Delegate)
         *  Passer au prochain État lorsque l'État actuel annonce qu'il est prêt à changer
         */
        public override void ChangerEtat(object source)
        {
            if (m_client != null)
            {
                string EtatAvant = m_etat.ToString();
                int surplus = m_etat.Surplus;
                Usine usine = Usine.obtenirUsine();

                if (m_etat.ToString() == "Hangar")
                {
                    PosCarte posDestination = m_client.Position;
                    int tempsVol = m_KMH; //Formule ?
                    m_etat = usine.creerObserver(m_posDepart, posDestination, tempsVol, surplus, this);
                }
                else if (m_etat.ToString() == "Observation")
                {
                    m_etat = usine.creerMaintenance(m_tempsMaintenance, surplus, this);
                }
                else if (m_etat.ToString() == "Maintenance")
                {
                    m_etat = usine.creerHangar(this);
                }

                //To delete aide visuel
                MessageBox.Show(this.m_nom + " : " + EtatAvant + "->" + this.m_etat.ToString() + " ! Temps avant prochaine action: " + this.m_etat.Temps); //Ne pas oublier de delete la référence using System.Windows.Forms;

                //S'abonne au nouvel événement
                m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
            }
        }


        /** Assigne un client au véhicule
         *  p_client: le client qui lui est assigné
         */
        public override void AssignerClient(Client p_client)
        {
            if (p_client is Observateur)
                m_client = (Observateur)p_client;
        }



        /**Accesseurs
         */
        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Observateur)";
            return vehicule;
        }

        public override string Type()
        {
            return "Observateur";
        }
    }
}
