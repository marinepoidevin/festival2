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

namespace festival2.View
{
    /// <summary>
    /// Logique d'interaction pour CreationScene.xaml
    /// </summary>
    public partial class CreationScene : Window
    {
        public CreationScene()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Suivant2(object sender, RoutedEventArgs e)
        {
            CreationScene cs = new CreationScene();
            cs.Show();
            this.Close();
        }

        private void Button_Terminer(object sender, RoutedEventArgs e)
        {
            Model.Scene scene = new Model.Scene(TextBox3.Text, int.Parse(TextBox4.Text));
            this.Close();
        }

       
    }
}
