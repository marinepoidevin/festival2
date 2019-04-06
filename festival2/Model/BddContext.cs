using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace festival2.Model
{
    public class BddContext : DbContext
    {
        public DbSet<Festival> Festivals { get; set; }
    }
}
