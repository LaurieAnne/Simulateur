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
    }
}
