using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;
using festival2;
using festival2.Model;
using festival2.Business;
using festival2.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;

namespace festival2.Business
{
    public class FestivalViewModel : INotifyPropertyChanged
    {

        private Festival Festival = new Festival();

        #region Properties

        public string FestivalNom
        {
            get { return Festival.Nom; }
            set
            {
                if (Festival.Nom != value)
                {
                    Festival.Nom = value;
                    RaisePropertyChanged("FestivalNom");
                }
            }
        }

        
        public int FestivalCodePostal
        {
            get { return Festival.CodePostal; }
            set
            {
                if (Festival.CodePostal != value)
                {
                    Festival.CodePostal = value;
                    RaisePropertyChanged("FestivalCodePostal");
                }
            }
        }

        public string FestivalLieu
        {
            get { return Festival.Lieu; }
            set
            {
                if (Festival.Lieu != value)
                {
                    Festival.Lieu = value;
                    RaisePropertyChanged("FestivalLieu");
                }
            }
        }

        public DateTime? FestivalDateDebut
        {
            get { return Festival.DateDebut; }
            set
            {
                if (Festival.DateDebut != value)
                {
                    Festival.DateDebut = value;
                    RaisePropertyChanged("FestivalDateDebut");
                }
            }
        }

        public DateTime? FestivalDateFin
        {
            get { return Festival.DateFin; }
            set
            {
                if (Festival.DateFin != value)
                {
                    Festival.DateFin = value;
                    RaisePropertyChanged("FestivalDateFin");
                }
            }
        }

        public int FestivalScenes
        {
            get { return Festival.Scenes; }
            set
            {
                if (Festival.Scenes != value)
                {
                    Festival.Scenes = value;
                    RaisePropertyChanged("FestivalScenes");
                }
            }
        }


        #endregion


        public void PostFestivalToAPI(FestivalViewModel FestivalViewModel)
        {
            Festival Fesival = new Festival()
            {
                Nom = FestivalViewModel.FestivalNom,
                Lieu = FestivalViewModel.FestivalLieu,
                CodePostal = FestivalViewModel.FestivalCodePostal,
                DateDebut = FestivalViewModel.FestivalDateDebut,
                DateFin = FestivalViewModel.FestivalDateFin,
                Scenes = FestivalViewModel.FestivalScenes
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56058/api/festivals");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> postTask = client.PostAsJsonAsync<Festival>("festivals", Festival);
            postTask.Wait();

            HttpResponseMessage result = postTask.Result;

            //if (result.IsSuccessStatusCode)
            //{
            //    CreationScene creationscene = new CreationScene();
            //    creationscene.Show();
            //}

        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods

        private void RaisePropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Commands
        void AddFestivalExecute()
        {
            PostFestivalToAPI(new FestivalViewModel());

        }

        bool CanAddFestivalExecute()
        {
            return true;
        }

        public ICommand AddFestival { get { return new RelayCommand(AddFestivalExecute, CanAddFestivalExecute); } }
        #endregion
    }
}
