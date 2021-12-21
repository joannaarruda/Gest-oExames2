using Desafio.Intelectah.Business.Models.Pacientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Infra.Data.Mappings
{
    public class PacienteConfig : EntityTypeConfiguration<Paciente>
    {
        public PacienteConfig()
        {
            HasKey(f => f.Id);

            Property(f => f.NmPaciente)
                .IsRequired()
                .HasMaxLength(100);

            Property(f => f.CpfPaciente)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnAnnotation("IX_CPF",
                    new IndexAnnotation(new IndexAttribute { IsUnique = true }))
                .IsFixedLength();

            ToTable("Pacientes");
        }
    }
}
