using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public sealed class Usine //Usine de création des Clients et États
    { 
        private static Usine m_usine = null; //l'Usine elle-même

        private Usine(){} //Constructeur vide et privé!

        public static Usine obtenirUsine() //Obtenir l'usine
        {
            if (m_usine == null)
            {
                m_usine = new Usine();
            }
            return m_usine;
        }

        /**Créer une position sur la carte
         * p_x: la coordonnée x
         * p_y: la coordonée y
         */
        public PosCarte creerPosition(int p_x, int p_y)
        {
            int[] Taille = new int[2];
            Taille[0] = 900;
            Taille[1] = 528;
            return new PosCarte(p_x, p_y, Taille);
        }





        /**Créations des États
         */


        /**Créer un Etat d'Aller
        * p_posDepart: la position de départ
        * p_posActuelle: la position actuelle
        * p_posDestination: la position de destination
        * p_nbClients: le nombre de clients à bord
        * p_temps: le temps avant le prochain etat
        * p_surplus: le temps de surplus
        * p_vehicule: le véhicule qui contient l'etat
        */
        public Aller creerAller(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_nbClients, int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new Aller(p_posDepart, p_posActuelle, p_posDestination, p_nbClients, p_temps - p_surplus, p_vehicule);
        }

        /**Créer un Etat d'AllerRetour avec compteur
        * p_posDepart: la position de départ
        * p_posActuelle: la position actuelle
        * p_posDestination: la position de destination
        * p_temps: le temps avant le prochain etat
        * p_surplus: le temps de surplus
        * p_compteur: le nombre d'aller retour
        * p_vehicule: le véhicule qui contient l'etat
        */
        public AllerRetour creerAllerRetour(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, int p_surplus, int p_compteur, Vehicule p_vehicule)
        {
            return new AllerRetour(p_posDepart, p_posActuelle, p_posDestination, p_temps - p_surplus, p_compteur, p_vehicule);
        }

        /**Créer un Etat d'AllerRetour sans intensité
        * p_posDepart: la position de départ
        * p_posActuelle: la position actuelle
        * p_posDestination: la position de destination
        * p_temps: le temps avant le prochain etat
        * p_surplus: le temps de surplus
        * p_vehicule: le véhicule qui contient l'etat
        */
        public AllerRetour creerAllerRetour(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new AllerRetour(p_posDepart, p_posActuelle, p_posDestination, p_temps - p_surplus, 1, p_vehicule);
        }

        /**Créer un Etat d'observation
        * p_posDepart: la position de départ
        * p_posActuelle: la position actuelle
        * p_posDestination: la position de destination
        * p_temps: le temps avant le prochain etat
        * p_surplus: le temps de surplus
        * p_vehicule: le véhicule qui contient l'etat
        */
        public Observer creerObserver(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new Observer(p_posDepart, p_posActuelle, p_posDestination, p_temps - p_surplus, p_vehicule);
        }


        /**Créer un Etat de maintenance
        * p_temps: le temps avant le prochain etat
        * p_surplus: le temps de surplus
        * p_vehicule: le véhicule qui contient l'etat
        */
        public Maintenance creerMaintenance(int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new Maintenance(p_temps - p_surplus, p_vehicule);
        }

        /**Créer un Etat de Hangar
        * p_vehicule: le véhicule qui contient l'etat
        */
        public Hangar creerHangar(Vehicule p_vehicule)
        {
            return new Hangar(0, p_vehicule);
        }

        /**Créer un Etat de d'embarquement
        * p_temps: le temps avant le prochain etat
        * p_surplus: le temps de surplus
        * p_vehicule: le véhicule qui contient l'etat
        */
        public Embarquement creerEmbarquement(int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new Embarquement(p_temps - p_surplus, p_vehicule);
        }

        /**Créer un Etat de débarquement
        * p_nbClients: le nombre de clients à bord
        * p_temps: le temps avant le prochain etat
        * p_surplus: le temps de surplus
        * p_vehicule: le véhicule qui contient l'etat
        */
        public Debarquement creerDebarquement(int p_nbClients, int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new Debarquement(p_nbClients, p_temps - p_surplus, p_vehicule);
        }






        /**Créations des clients
         */

        /**Creer un client de type Feu
         * p_rnd: seed Random
         */
        public Feu creerFeu(Random p_rnd)
        {
            return new Feu(p_rnd);
        }

        /**Créer un client de type Passager
         * p_rnd: seed random
         * p_ListePosAeroport: La liste des positions des aéroport
         */
        public Passager creerPassager(Random p_rnd, List<PosCarte> p_ListePosAeroport)
        {
            return new Passager(p_rnd, p_ListePosAeroport);
        }

        /**Créer un client de type Marchandise
         * p_rnd: seed random
         * p_ListePosAeroport: La liste des positions des aéroport
         */
        public Marchandise creerMarchandise(Random p_rnd, List<PosCarte> p_ListePosAeroport)
        {
            return new Marchandise(p_rnd, p_ListePosAeroport);
        }

        /**Créer un client de type Observateur
         * p_rnd: seed random
         */
        public Observateur creerObservateur(Random p_rnd)
        {
            return new Observateur(p_rnd);
        }

        /**Créer un client de type Secours
         * p_rnd: seed random
         */
        public Secours creerSecours(Random p_rnd)
        {
            return new Secours(p_rnd);
        }

    }
}
