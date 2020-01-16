using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ScoreContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}
