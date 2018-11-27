using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public sealed class Usine
    {
        private static Usine m_usine = null; //Usine

        private Usine()
        {

        }

        public static Usine obtenirUsine() //Obtenir l'usine
        {
            if (m_usine == null)
            {
                m_usine = new Usine();
            }
            return m_usine;
        }


        public PosCarte creerPosition(int p_x, int p_y)
        {
            int[] Taille = new int[2];
            Taille[0] = 900;
            Taille[1] = 528;
            return new PosCarte(p_x, p_y, Taille);
        }

        /**Créations des États
         */
        public Aller creerAller(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_nbClients, int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new Aller(p_posDepart, p_posActuelle, p_posDestination, p_nbClients, p_temps - p_surplus, p_vehicule);
        }

        public AllerRetour creerAllerRetour(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, int p_surplus, int p_compteur, Vehicule p_vehicule)
        {
            return new AllerRetour(p_posDepart, p_posActuelle, p_posDestination, p_temps - p_surplus, p_compteur, p_vehicule);
        }

        public AllerRetour creerAllerRetour(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new AllerRetour(p_posDepart, p_posActuelle, p_posDestination, p_temps - p_surplus, 1, p_vehicule);
        }

        public Observer creerObserver(PosCarte p_posDepart, PosCarte p_posActuelle, PosCarte p_posDestination, int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new Observer(p_posDepart, p_posActuelle, p_posDestination, p_temps - p_surplus, p_vehicule);
        }

        public Maintenance creerMaintenance(int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new Maintenance(p_temps - p_surplus, p_vehicule);
        }

        public Hangar creerHangar(Vehicule p_vehicule)
        {
            return new Hangar(0, p_vehicule);
        }

        public Embarquement creerEmbarquement(int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new Embarquement(p_temps - p_surplus, p_vehicule);
        }

        public Debarquement creerDebarquement(int p_nbClients, int p_temps, int p_surplus, Vehicule p_vehicule)
        {
            return new Debarquement(p_nbClients, p_temps - p_surplus, p_vehicule);
        }




        /**Créations des clients
         */
        public Feu creerFeu(Random p_rnd)
        {
            return new Feu(p_rnd);
        }

        public ClientTransport creerPassager(Random p_rnd, List<PosCarte> p_ListePosAeroport)
        {
            ClientTransport lePassager = new Passager(p_rnd, p_ListePosAeroport);
            return lePassager;
        }

        public ClientTransport creerMarchandise(Random p_rnd, List<PosCarte> p_ListePosAeroport)
        {
            ClientTransport laMarchandise = new Marchandise(p_rnd, p_ListePosAeroport);
            return laMarchandise;
        }

        public Observateur creerObservateur(Random p_rnd)
        {
            return new Observateur(p_rnd);
        }

        public Secours creerSecours(Random p_rnd)
        {
            return new Secours(p_rnd);
        }
    }
}
