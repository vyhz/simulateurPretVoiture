using simulateurPret.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace simulateurPret
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Kilometre> kilometreElements;
        public List<Voiture> voitureElements;
        public List<Energie> energieElements;
        public List<Annee> anneeElements;
        public List<Personne> personneElements;
        double pointTotal;

        public MainWindow()
        {
            InitializeComponent();


            #region voiture 
            voitureElements = new List<Voiture>
            {
                new Voiture("Citadine", "800-1300Kg", 8),
                new Voiture("Cabriolet", "1300-2000kg", 6),
                new Voiture("Berline", "1300-1800kg", 8.5),
                new Voiture("SUV / 4x4", "1500-2500kg", 4)
            };

            foreach (Voiture element in voitureElements)
            {
                VoitureType.Items.Add(element.type);
            }
            #endregion
            #region Energie
            energieElements = new List<Energie>
            {
                new Energie("Essence", 5),
                new Energie("Electrique", 9),
                new Energie("Gaz", 6),
                new Energie("Diesel", 4),
                new Energie("Hybride", 7)
            };

            foreach (Energie element in energieElements)
            {
                energieType.Items.Add(element.typeEnergie);
            }


            #endregion

            #region Annee
            anneeElements = new List<Annee>
            {
                new Annee("1960-1970", 1),
                new Annee("1970-1980", 2),
                new Annee("1990-2000", 4),
                new Annee("2000-2010", 5),
                new Annee("Après 2010", 7)
            };

            foreach (Annee element in anneeElements)
            {
                anneeType.Items.Add(element.date);
            }


            #endregion

            #region Kilometre
            kilometreElements = new List<Kilometre>
            {
                new Kilometre("5-10K/km", 9),
                new Kilometre("10-15K/km", 7),
                new Kilometre("15-20K/km", 5),
                new Kilometre("20-25K/km", 3),
                new Kilometre("25-30K/km", 1)
            };

            foreach (Kilometre element in kilometreElements)
            {
                kilometrageType.Items.Add(element.nbKilometre);
            }
            #endregion

            #region personne
            personneElements = new List<Personne>
            {
                new Personne(1, 0.11),
                new Personne(2, 0.17),
                new Personne(3, 0.29),
                new Personne(4, 0.53),
            };

            foreach (Personne personne in personneElements)
            {
                nbPersonne.Items.Add(personne.nbPers);
            }
            #endregion


        }
        #region Simulation
        private void Simulation_Click(object sender, RoutedEventArgs e)
        {
            // Récupérez l'élément sélectionné de la ComboBox
            var kilometreItem = kilometrageType.SelectedItem;
            var voitureItem = VoitureType.SelectedItem;
            var energieItem = energieType.SelectedItem;
            var anneeItem = anneeType.SelectedItem;
            var personneItem = nbPersonne.SelectedItem;
            int testeurCalcul = 0;

            #region calculKilometre
            // Vérifiez si l'élément n'est pas null (au cas où rien n'a été sélectionné)
            if (kilometreItem != null)
            {
                // Convertissez l'objet en type approprié (par exemple, string)
                string selectedValue = kilometreItem.ToString();
                foreach(var kilometre in kilometreElements)
                {
                    if(kilometre.nbKilometre == selectedValue) 
                    {
                        pointTotal += kilometre.points; 
                    }
                }
                testeurCalcul += 1;
            }
            else
            {
               MessageBox.Show("Le champ kilomètre ne peut pas être vide. Veuillez le remplir.", "Erreur");
                
            }
            #endregion

            #region calculVoiture
            if (voitureItem != null)
            {
                // Convertissez l'objet en type approprié (par exemple, string)
                string voitureValue = voitureItem.ToString();
                foreach (var voiture in voitureElements)
                {
                    if (voiture.type == voitureValue)
                    {
                        pointTotal += voiture.valeurs;
                    }
                }
                testeurCalcul += 1;
            }
            else
            {
                MessageBox.Show("Le champ voiture ne peut pas être vide. Veuillez le remplir.", "Erreur");
                
            }
            #endregion

            #region calculEnergie
            if (energieItem != null)
            {
                // Convertissez l'objet en type approprié (par exemple, string)
                string energieValue = energieItem.ToString();
                foreach (var energie in energieElements)
                {
                    if (energie.typeEnergie == energieValue)
                    {
                        pointTotal += energie.point;
                    }
                }
                testeurCalcul += 1;
            }
            else
            {
                MessageBox.Show("Le champ energie ne peut pas être vide. Veuillez le remplir.", "Erreur");
            }
            #endregion

            #region calculAnnee
            if (anneeItem != null)
            {
                // Convertissez l'objet en type approprié (par exemple, string)
                string anneeValue = anneeItem.ToString();
                foreach (var annee in anneeElements)
                {
                    if (annee.date == anneeValue)
                    {
                        pointTotal += annee.points;
                    }
                }
                testeurCalcul += 1;
            }
            else
            {
                MessageBox.Show("Le champ annee ne peut pas être vide. Veuillez le remplir.", "Erreur");
            }
            #endregion
            if(testeurCalcul>=4)
            {
                CalculTaux calculTaux = new CalculTaux();

                double taux = calculTaux.Calcul(pointTotal);

                #region calculPersonne
                if (personneItem != null)
                {
                    // Convertissez l'objet en type approprié (par exemple, string)
                    int personneValue = (int)personneItem;
                    foreach (var personne in personneElements)
                    {
                        if (personne.nbPers == personneValue & personne.nbPers == 1)
                        {
                            taux += personne.malusBonus;
                        }
                        else if (personne.nbPers == personneValue & personne.nbPers > 1)
                        {
                            taux -= personne.malusBonus;
                        }
                    }
                    MessageBox.Show("Votre taux pour un Emprunt sera de : " + taux, "Résultat");
                }
                else
                {
                    MessageBox.Show("Le champ personne ne peut pas être vide. Veuillez le remplir.", "Erreur");
                }
            }
            
            #endregion


        }
        #endregion
    }
}
