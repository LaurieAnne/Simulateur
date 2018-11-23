using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur
{
    public class AvionObservateur : Vehicule
    {
        protected Observateur m_client; //Le client d'observateur

        public AvionObservateur(string p_nom, int p_KMH, int p_tempsMain, Aeroport p_aeroport, Observateur p_client) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, ConsoleColor.Gray, p_aeroport)
        {
            m_client = p_client;
        }

        //Changer d'Etat
        public override void ChangerEtat(object source)
        {
            if (m_client != null)
            {
                string EtatAvant = m_etat.ToString();

                if (m_etat.ToString() == "Hangar")
                {
                    Aeroport aeDepart = m_client.AeroportDepart;
                    PosCarte posDestination = m_client.PositionDestination;
                    int tempsVol = m_KMH; //Formule ?
                    m_etat = new Observer(aeDepart, m_posActuelle, tempsVol, posDestination);
                }
                else if (m_etat.ToString() == "Observation")
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
            if (p_client is Observateur)
                m_client = (Observateur)p_client;
        }





        //Constructeur vide pour XML
        public AvionObservateur() : base(){}

        /**Accesseurs
         */
        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Observateur)";
            return vehicule;
        }
    }
}
