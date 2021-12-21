using Desafio.Intelectah.Business.Models.Exames;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Infra.Data.Mappings
{
    public class ExameConfig : EntityTypeConfiguration<Exame>
    {
        public ExameConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Observacao)
                .HasMaxLength(1000);

            HasRequired(e => e.TipoExame)
               .WithMany(p => p.Exames)
              .HasForeignKey(e => e.TipoExameId);


            ToTable("Exames");
        }
    }
}
