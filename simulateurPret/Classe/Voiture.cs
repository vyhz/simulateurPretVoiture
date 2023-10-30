using System.Collections.Generic;

namespace simulateurPret.Classe
{
    public class Voiture
    {
        public string type { get; set; }
        public string poids { get; set; }
        public double valeurs { get; set; }

        public Voiture(string type, string poids, double valeurs)
        {
            this.type = type;
            this.poids = poids;
            this.valeurs = valeurs;
        }

      

    }
}