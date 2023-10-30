namespace simulateurPret.Classe
{
    public class Personne
    {
        public int nbPers { get; set; }
        public double malusBonus { get; set; }

        public Personne(int NbPers, double MalusBonus) 
        {
            this.nbPers = NbPers;
            this.malusBonus = MalusBonus;
        }
    }
}