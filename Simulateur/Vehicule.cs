using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Simulateur
{
    [XmlInclude(typeof(AvionPassagers))]
    [XmlInclude(typeof(AvionMarchandises))]
    [XmlInclude(typeof(AvionObservateur))]
    [XmlInclude(typeof(AvionCiterne))]
    [XmlInclude(typeof(HelicoSecours))]
    public abstract class Vehicule //Toutes les sortes de véhicule
    {
        protected string m_nom; //Nom
        protected int m_KMH; //Le nombre de KM à l'heure
        protected int m_tempsMaintenance; //Temps de maintenance
        protected Color m_couleur; //Couleur
        protected Etat m_etat; //Etat du véhicule
        protected PosCarte m_posDepart; //Position de départ du véhicule
        protected Scenario m_scenario; //Référence au scénario
        protected Aeroport m_aeroport; //Référence à l'aeroport

        /** Constructeur de véhicule
         * p_nom: le nom du véhicule
         * p_KMH: la vitesse de déplacement du véhicule
         * p_tempsMaintenance: le temps de maintenance du véhicule
         * p_couleur: la couleur de la ligne à l'affichage
         * p_aeroport: l'aeroport qui le contient (pour extraire ses coordonnées)
         */
        public Vehicule(string p_nom, int p_KMH, int p_tempsMain, Color p_couleur, PosCarte p_posAeroport, Scenario p_scenario, Aeroport p_aeroport)
        {
            m_nom = p_nom;
            m_KMH = p_KMH;
            m_tempsMaintenance = p_tempsMain;
            m_couleur = p_couleur;
            Usine usine = Usine.obtenirUsine();
            m_etat = usine.creerHangar(this);
            m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat);
            m_posDepart = p_posAeroport;
            m_scenario = p_scenario;
            m_aeroport = p_aeroport;
        }
        
        /**Constructeur vide pour XML
         */
        public Vehicule()
        {
            Usine usine = Usine.obtenirUsine();
            m_etat = usine.creerHangar(this); //Par défaut tous les véhicules sont dans le Hangar
            m_etat.eventEtatFini += new DelegateEtatFini(ChangerEtat); //Abonnement au délegué de l'État
        }


        /** Changer l'État du véhicule (Delegate)
         *  Effectue une action lorsque l'État annonce qu'il est prêt à changer
         */
        public abstract void ChangerEtat(object source); 

        /** Avance le véhicule dans le temps
         *  p_temps: le temps avant la prochaine action
         */
        public void Avance(int p_temps)
        {
            if (m_etat != null)
                m_etat.Avance(p_temps);
        }

        /** Assigne un client au véhicule
         *  p_client: le client qui lui est assigné
         */
        public abstract void AssignerClient(Client p_client);


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

        public Color Couleur
        {
            get { return m_couleur; }
            set { m_couleur = value; }
        }

        public PosCarte PositionCarte
        {
            get { return m_posDepart; }
            set { m_posDepart = value; }
        }

        public Scenario Scenario
        {
            get { return m_scenario; }
            set { m_scenario = value; }
        }

        public Aeroport Aeroport
        {
            get { return m_aeroport; }
            set { m_aeroport = value; }
        }

        public override string ToString()
        {
            string vehicule;
            vehicule = m_nom + " (Véhicule)";
            return vehicule;
        }

        public abstract string Type();

        //TESTAGE DÉGUEULASSE =>

        public bool enVol()
        {
            if (m_etat is Aller || m_etat is AllerRetour || m_etat is Observer)
            {
                return true;
            }
            return false;
        }

        public string obtenirPosVehicule() //Obtenir les stats de pos véhicule
        {
            return m_etat.obtenirPosVehicule();
        }

        public void ResetEtat()
        {
            m_etat = null;
        }

        /*public bool disponible() //Si c'est disponible
        {
            return (m_etat is Hangar);
        }*/

        public bool disponible() //Si c'est disponible
        {
            return ((m_etat is Hangar) && (Client() == null));
        }

        public abstract void ResetClient();

        public abstract Client Client();
    }
}
