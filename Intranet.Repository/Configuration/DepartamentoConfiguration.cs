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
    /// Classe de configuração para a entidade Departamento.
    /// </summary>
    public class DepartamentoConfiguration : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfiguration()
        {
            //chave primária
            HasKey(d => d.IdDepartamento);

            //Demais colunas da tabela
            Property(d => d.Nome)
                .HasMaxLength(250)
                .IsRequired();

            Property(d => d.Endereco)
                .HasMaxLength(400)
                .IsRequired();

            ToTable("TB_Departamento");

            //Relacionamento.
            HasMany(d => d.NoticiaList).WithMany(n => n.DepartamentoList)
                                      .Map(d => d.ToTable("TB_Departamento_Noticia")
                                      .MapLeftKey("IdDepartamento")
                                      .MapRightKey("IdNoticia"));



        }
    }
}
