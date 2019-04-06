using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Logique d'interaction pour BDD.xaml
    /// </summary>
    public partial class BDD : Window
    {
        public BDD()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IDatabaseInitializer<Model.BddContext> init = new CreateDatabaseIfNotExists<Model.BddContext>();
            //IDatabaseInitializer<Model.BddContext> init = new DropCreateDatabaseAlways<Model.BddContext>();
            //IDatabaseInitializer<Model.BddContext> init = new DropCreateDatabaseIfModelChanges<Model.BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new Model.BddContext());
        }
    }
}
