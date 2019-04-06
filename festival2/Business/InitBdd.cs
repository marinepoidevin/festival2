using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace festival2.Business
{
    public class InitBdd
    {
        public void Init()
        {
            IDatabaseInitializer<Model.BddContext> init = new CreateDatabaseIfNotExists<Model.BddContext>();
            //IDatabaseInitializer<Model.BddContext> init = new DropCreateDatabaseAlways<Model.BddContext>();
            //IDatabaseInitializer<Model.BddContext> init = new DropCreateDatabaseIfModelChanges<Model.BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new Model.BddContext());
        }
        public void AddDatas()
        {

        }
    }
}
