namespace simulateurPret.Classe
{
    public class Energie
    {
        public string typeEnergie { get; set; }
        public double point { get; set; }
        public Energie(string TypeEnergie, double Point) 
        {
            this.typeEnergie = TypeEnergie;
            this.point = Point;

        }
    }
}