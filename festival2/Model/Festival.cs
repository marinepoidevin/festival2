using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace festival2.Model
{
    public class Festival
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Lieu { get; set; }
        public int CodePostal { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int Scenes { get; set; }


        public Festival(int id, string nom, string lieu, DateTime dateDebut, DateTime dateFin, int scenes, int codePostal)
        {
            Id = id;
            Nom = nom;
            Lieu = lieu;
            CodePostal = codePostal;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Scenes = scenes;
            //cmmdentaire
        }

        public Festival(string nom, string lieu, DateTime dateDebut, DateTime dateFin, int codePostal)
        {
            Nom = nom;
            Lieu = lieu;
            CodePostal = codePostal;
            DateDebut = dateDebut;
            DateFin = dateFin;
        }


        public Festival(string nom, string lieu)
        {
            Nom = nom;
            Lieu = lieu;
        }

        public Festival()
        {
        }


        public override String ToString()
        {
            return "Festival " + Nom + "créé";
        }
    }
}
