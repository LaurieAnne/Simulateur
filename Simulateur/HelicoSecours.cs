using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur
{
    public class HelicoSecours : Vehicule //Véhicule de type Hélicoptère de Secours
    {
        protected Secours m_client; //Le client Secours

        /** Constructeur d'un hélicoptère de secours
         * p_nom: le nom du véhicule
         * p_KMH: la vitesse de déplacement de l'avion
         * p_tempsMain: le temps de maintenance
         * p_couleur: la couleur de la ligne à l'affichage
         * p_aeroport: l'aeroport qui le contient (pour extraire ses coordonnées)
         */
        public HelicoSecours(string p_nom, int p_KMH, int p_tempsMain, PosCarte p_posAeroport, Scenario p_scenario, Aeroport p_aeroport) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, Color.Red, p_posAeroport, p_scenario, p_aeroport)
        {
        }

        /**Constructeur vide pour XML
         */
        public HelicoSecours() : base() { }

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
                    PosCarte posDestination = m_client.PositionDepart;
                    PosCarte posActuelle = usine.creerPosition(m_posDepart.X, m_posDepart.Y); //Position actuelle
                    int tempsVol = m_KMH; //Formule ?
                    m_etat = usine.creerAllerRetour(m_posDepart, posActuelle, posDestination, tempsVol, surplus, this);
                    //S'abonne au nouvel événement
                    m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
                }
                else if (m_etat.ToString() == "AllerRetour")
                {
                    m_etat = usine.creerMaintenance(m_tempsMaintenance, surplus, this);
                    //S'abonne au nouvel événement
                    m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
                }
                else if (m_etat.ToString() == "Maintenance")
                {
                    m_etat = usine.creerHangar(this);
                    ResetClient();
                    ResetEtat();
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
            if (p_client is Secours)
                m_client = (Secours)p_client;
        }

        /** Accesseurs
         */
        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Secours)";
            return vehicule;
        }

        public override string Type()
        {
            return "Secours";
        }

        public override Client Client()
        {
            return m_client;
        }

        public override void ResetClient()
        {
            m_client = null;
        }
    }
}
