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

        public AvionTransport(string p_nom, int p_KMH, int p_tempsMain, int p_tempsEmb, int p_tempsDeb, ConsoleColor p_couleur, Aeroport p_aeroport) //Constructeur
            : base(p_nom, p_KMH, p_tempsMain, p_couleur, p_aeroport)
        {
            m_tempsEmbarquement = p_tempsEmb;
            m_tempsDebarquement = p_tempsDeb;
        }


        //Constructeur vide pour XML
        public AvionTransport() : base()
        {
        }


        //Changer d'Etat
        public override void ChangerEtat(object source)
        {
            //PosCarte posDepart = m_aeroport.Pos;
            PosCarte posDepart = new PosCarte();
            PosCarte posDestination = new PosCarte();
            int nbClients = 30;
            int tempsVol = 60;
            string EtatAvant = m_etat.ToString();

            if (m_etat.ToString() == "Hangar")
                m_etat = new Embarquement(m_tempsEmbarquement);
            else if (m_etat.ToString() == "Embarquement")
                m_etat = new Aller(posDepart, posDepart, posDestination, nbClients, tempsVol);
            else if (m_etat.ToString() == "Aller")
                m_etat = new Debarquement(nbClients, m_tempsDebarquement);
            else if (m_etat.ToString() == "Debarquement")
                m_etat = new Maintenance(m_tempsMaintenance);
            else if (m_etat.ToString() == "Maintenance")
                m_etat = new Hangar(0);

            MessageBox.Show(this.m_nom + " : " + EtatAvant + "->" + this.m_etat.ToString() + " ! Temps avant prochaine action: " + this.m_etat.Temps); //Ne pas oublier de delete la référence using System.Windows.Forms;
            m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
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
