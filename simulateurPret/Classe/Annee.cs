namespace simulateurPret.Classe
{
    public class Annee
    {
        public string date { get; set; }
        public double points { get; set; }

        public Annee(string Date, double Points) 
        {
            this.date = Date;
            this.points = Points;
        }

        
    }
}