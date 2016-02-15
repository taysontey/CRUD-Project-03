using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity;
using Projeto.Entity.Entities;
using Projeto.InfraEstructure.Configuration;


namespace Projeto.InfraEstructure.DataSource
{
    public class Conexao : DbContext
    {
        public Conexao()
            : base(ConfigurationManager.ConnectionStrings["projeto"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TimeConfiguration());
            modelBuilder.Configurations.Add(new JogadorConfiguration());
        }

        public DbSet<Time> Time { get; set; }
        public DbSet<Jogador> Jogador { get; set; }
    }
}
