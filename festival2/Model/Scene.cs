using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace festival2.Model
{
    public class Scene
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Capacite { get; set; }

        public Scene(int id, string nom, int capacite)
        {
            Id = id;
            Nom = nom;
            Capacite = capacite;
            //fygjhkj
            //kuyjhd
        }

        public Scene(string nom, int capacite)
        {
            Nom = nom;
            Capacite = capacite;
        }

        public Scene()
        {
        }
    }
}
