using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur
{
    public class Marchandise : ClientTransport
    {
        public Marchandise(Aeroport p_aeDepart, Aeroport p_aeDestination, int p_nbClients) : base(p_aeDepart, p_aeDestination, p_nbClients) //Constructeur
        {

        }
    }
}
