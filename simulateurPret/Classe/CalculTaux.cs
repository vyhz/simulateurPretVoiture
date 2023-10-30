using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulateurPret.Classe
{
    public class CalculTaux
    {

        public double Calcul(double ValeurTotal) 
        {
            double tauxEmprunt;

            if (ValeurTotal <= 10) {
                tauxEmprunt = 3;
            }
            else if(ValeurTotal <= 15)
            {
                tauxEmprunt = 2.74;
            }
            else if(ValeurTotal <= 25) { 
                tauxEmprunt= 2.52;
            }
            else if (ValeurTotal <= 33) {
                tauxEmprunt = 2.10;
            }
            else {
                tauxEmprunt = 1.85;
            }
            return tauxEmprunt;
        }
    }
}
