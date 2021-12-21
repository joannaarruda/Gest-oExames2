using Desafio.Intelectah.Business.Models.MarcacoesConsultas;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Infra.Data.Mappings
{
    public class MarcacaoConsultaConfig : EntityTypeConfiguration<MarcacaoConsulta>
    {

        public MarcacaoConsultaConfig()
        {
            HasRequired(m => m.Paciente)
              .WithMany(f => f.MarcacaoConsultas)
              .HasForeignKey(m => m.PacienteId);

        }

       
    }
}
