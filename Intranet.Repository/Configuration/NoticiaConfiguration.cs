using Intranet.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Data.Configuration
{
    /// <summary>
    /// Classe de configuração para a Entidade Noticia.
    /// </summary>
    public class NoticiaConfiguration : EntityTypeConfiguration<Noticia>
    {
        public NoticiaConfiguration()
        {
            //chave primária.
            HasKey(n => n.IdNoticia);

            Property(n => n.Titulo)
                .HasMaxLength(50)
                .IsRequired();

            Property(n => n.Corpo)
                .HasMaxLength(400)
                .IsRequired();

            Property(n => n.DataPostagem).IsRequired();

            ToTable("TB_Noticia");

        }
    }
}
