using Desafio.Intelectah.Business.Models.TiposExames;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Infra.Data.Mappings
{
    public class TipoExameConfig : EntityTypeConfiguration<TipoExame>
    {

        public TipoExameConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.NmTipoExame)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.DescricaoTipo)
               .IsRequired()
               .HasMaxLength(256);

            ToTable("TipoExames");
        }
    }
}
