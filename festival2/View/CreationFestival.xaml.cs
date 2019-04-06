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
using System.Windows.Shapes;
using festival2.Model;


namespace festival2.View
{
    /// <summary>
    /// Logique d'interaction pour CreationFestival.xaml
    /// </summary>
    public partial class CreationFestival : Window
    {
        public CreationFestival()
        {
            InitializeComponent();
        }
        

        private void Button_Suivant(object sender, RoutedEventArgs e)
        {
            DateTime dt1;
            DateTime dt2;

            if (DateTime.TryParse(DatePicker1.Text, out dt1) && DateTime.TryParse(DatePicker2.Text, out dt2))
            {
                if (dt1 > dt2 || dt1 < DateTime.Today || dt2 < DateTime.Today || dt1 == null || dt2 == null)
                { 
                    MessageBox.Show("Les dates rentrées sont incohérentes.", "ERREUR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    Model.Festival festival = new Model.Festival(TextBox1.Text, TextBox2.Text, int.Parse(TextBox5.Text), dt1, dt2); //int.Parse(ComboBox.Text)

                    CreationScene cs = new CreationScene();
                    cs.Show();
                    this.Close();

                }
            }   
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
