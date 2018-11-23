using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Simulateur
{
    [XmlInclude(typeof(AvionPassagers))]
    [XmlInclude(typeof(AvionMarchandises))]
    [XmlInclude(typeof(AvionObservateur))]
    [XmlInclude(typeof(AvionCiterne))]
    [XmlInclude(typeof(HelicoSecours))]
    public abstract class Vehicule
    {
        protected string m_nom; //Nom
        protected int m_KMH; //Le nombre de KM à l'heure
        protected int m_tempsMaintenance; //Temps de maintenance
        protected ConsoleColor m_couleur; //Couleur
        protected Etat m_etat; //Etat du véhicule
        protected Aeroport m_aeroport; //L'Aéroport ou il est

        public Vehicule(string p_nom, int p_KMH, int p_tempsMain, ConsoleColor p_couleur, Aeroport p_aeroport) //Constructeur
        {
            m_nom = p_nom;
            m_KMH = p_KMH;
            m_tempsMaintenance = p_tempsMain;
            m_couleur = p_couleur;
            m_etat = new Hangar(0);
            m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
            m_aeroport = p_aeroport;
        }

        public abstract void ChangerEtat(object source);


        public void Avance(int p_temps)
        {
            
            m_etat.Avance(p_temps);
        }



        //Constructeur vide
        public Vehicule()
        {
            m_etat = new Hangar(0);
            m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
        }


        /** Accesseurs
         */
        public string Nom
        {
            get { return m_nom; }
            set { m_nom = value; }
        }

        public int KMH
        {
            get { return m_KMH; }
            set { m_KMH = value; }
        }

        public int Maintenance
        {
            get { return m_tempsMaintenance; }
            set { m_tempsMaintenance = value; }
        }

        public ConsoleColor Couleur
        {
            get { return m_couleur; }
            set { m_couleur = value; }
        }

        public override string ToString() //ToString
        {
            string vehicule;
            vehicule = m_nom + " (Véhicule)";
            return vehicule;
        }
    }
}
