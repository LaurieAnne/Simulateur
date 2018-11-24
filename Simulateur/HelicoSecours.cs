using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur
{
    public class HelicoSecours : Vehicule
    {
        protected Secours m_client; //Le client Feu

        public HelicoSecours(string p_nom, int p_KMH, int p_tempsMain, Aeroport p_aeroport) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, ConsoleColor.Red, p_aeroport)
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
                    PosCarte posDestination = m_client.Position;
                    int tempsVol = m_KMH; //Formule ?
                    m_etat = new AllerRetour(m_posDepart, m_posDepart, posDestination, tempsVol);
                }
                else if (m_etat.ToString() == "AllerRetour")
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


        //?Todelete?
        public override void AssignerClient(Client p_client)
        {
            if (p_client is Secours)
                m_client = (Secours)p_client;
        }

        //Constructeur vide pour XML
        public HelicoSecours() : base(){}

        /** Accesseurs
         */
        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Secours)";
            return vehicule;
        }
    }
}
