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
using System.Threading;

namespace festival2.Business
{
    public class SceneViewModel : INotifyPropertyChanged
    {

        private Scene Scene = new Scene();

        #region Properties

        public string SceneNom
        {
            get { return Scene.Nom; }
            set
            {
                if (Scene.Nom != value)
                {
                    Scene.Nom = value;
                    RaisePropertyChanged("SceneNom");
                }
            }
        }
        
        public int SceneCapacite
        {
            get { return Scene.Capacite; }
            set
            {
                if (Scene.Capacite != value)
                {
                    Scene.Capacite = value;
                    RaisePropertyChanged("SceneCapacite");
                }
            }
        }


        #endregion


        public void PostSceneToAPI(SceneViewModel SceneViewModel)
        {
            Scene Scene = new Scene()
            {
                Nom = SceneViewModel.SceneNom,
                Capacite = SceneViewModel.SceneCapacite
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56058/api/scenes");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> postTask = client.PostAsJsonAsync<Scene>("scenes", Scene);
            postTask.Wait();
            Thread.Sleep(100);

            HttpResponseMessage result = postTask.Result;
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
        void AddSceneExecute()
        {
            PostSceneToAPI(new SceneViewModel());

        }

        bool CanAddSceneExecute()
        {
            return true;
        }

        public ICommand AddScene { get { return new RelayCommand(AddSceneExecute, CanAddSceneExecute); } }
        #endregion
    }
}
