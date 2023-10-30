using System.Collections.Generic;

namespace simulateurPret.Classe
{
    public class Kilometre
    {
        public string nbKilometre { get; set; }
        public double points { get; set; }

        public Kilometre(string NbKilometre, double Points) 
        {
            this.nbKilometre = NbKilometre;
            this.points = Points;
        }

    }
}