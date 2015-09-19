using Intranet.Model;
using Intranet.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Data.Context
{
    /// <summary>
    /// Classe de contexto para acesso ao banco de dados
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["projeto"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removendo a convenção de pluralização de nomes de tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //removendo delete on cascade.
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            modelBuilder.Configurations.Add(new NoticiaConfiguration());
        }

        //Declarando um DbSet para cada entidade.
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
    }
}
