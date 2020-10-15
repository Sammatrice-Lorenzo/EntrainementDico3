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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MetierDico;
namespace WpfEntrainementDico3
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Dictionary<string, List<Commercial>> dico;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dico = new Dictionary<string, List<Commercial>>();
            List<Commercial> comNord = new List<Commercial>();
            List<Commercial> comSud = new List<Commercial>();
            List<Commercial> comOuest = new List<Commercial>();

            Commercial com1 = new Commercial("Jean");
            Commercial com2 = new Commercial("Isa");
            Commercial com3 = new Commercial("Steph");

            Vente v1 = new Vente("AAA", 100);
            Vente v2 = new Vente("BBB", 200);
            Vente v3 = new Vente("CCC", 300);
            Vente v4 = new Vente("DDD", 400);
            Vente v5 = new Vente("EEE", 500);

            com1.AjouterVente(v1);
            com1.AjouterVente(v2);
            com2.AjouterVente(v3);
            com2.AjouterVente(v4);
            com3.AjouterVente(v5);

            comNord.Add(com1);
            comSud.Add(com2);
            comOuest.Add(com3);

            dico.Add("Nord", comNord);
            dico.Add("Sud", comSud);
            dico.Add("Ouest", comOuest);

            lstSecteurs.ItemsSource = dico.Keys;
        }

        private void btnInserer_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomSecteur.Text == "")
            {
                MessageBox.Show("Veiuller  insérer un secteur", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (txtNomCommercial.Text == "")
                {
                    MessageBox.Show("Veiuller  insérer un commercial ", "Erreur d'insertion", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (txtNomClient.Text == "")
                    {
                        MessageBox.Show("Veiuller  insérer le nom du client ", "Erreur d'insertion", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (txtNbMontant.Text == "")
                        {
                            MessageBox.Show("Veiuller  insérer le montant ", "Erreur d'insertion", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            Vente v = new Vente(txtNomClient.Text, Convert.ToInt32(txtNbMontant.Text));
                            if(dico.ContainsKey(txtNomSecteur.Text)==false)
                            {
                                List<Commercial> comEst = new List<Commercial>();
                                dico.Add(txtNomSecteur.Text, comEst);
                                Commercial com = new Commercial(txtNomCommercial.Text);
                                comEst.Add(com);
                                com.AjouterVente(v);
                                lstSecteurs.Items.Refresh();

                            }
                            else
                            {
                                if (dico[txtNomSecteur.Text].Exists(com => com.NomCommercial == txtNomCommercial.Text))
                                {
                                    dico[txtNomSecteur.Text].Find(com => com.NomCommercial == txtNomCommercial.Text).AjouterVente(v);
                                }
                                else
                                {
                                    Commercial com = new Commercial(txtNomCommercial.Text);
                                    com.AjouterVente(v);
                                    dico[txtNomSecteur.Text].Add(com);

                                }
                                lstSecteurs.Items.Refresh();
                                lstCommerciaux.Items.Refresh();
                                lstVentes.Items.Refresh();
                            }
                        }
                    }
                   
                }
            }
        }

        private void lstSecteurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSecteurs.SelectedItem != null)
            {
                lstCommerciaux.ItemsSource = dico[lstSecteurs.SelectedItem as string];
            }

        }

        private void lstCommerciaux_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstCommerciaux.SelectedItem != null)
            {
                lstVentes.ItemsSource = dico[lstSecteurs.SelectedItem as string].Find(com => com.NomCommercial == (lstCommerciaux.SelectedItem as Commercial).NomCommercial).LesVentes;
            }
        }
    }
}
