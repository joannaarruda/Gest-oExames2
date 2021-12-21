using Desafio.Intelectah.Business.Models.Exames;
using Desafio.Intelectah.Business.Models.MarcacoesConsultas;
using Desafio.Intelectah.Business.Models.Pacientes;
using Desafio.Intelectah.Business.Models.TiposExames;
using Desafio.Intelectah.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Infra.Data.Context
{
    public class GestaoExames2Context : DbContext
    {
        public GestaoExames2Context() : base(nameOrConnectionString: "DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

        }

        public DbSet<TipoExame> TipoExames { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<MarcacaoConsulta> MarcacoesConsultas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new PacienteConfig());
            modelBuilder.Configurations.Add(new ExameConfig());
            modelBuilder.Configurations.Add(new MarcacaoConsultaConfig());
            modelBuilder.Configurations.Add(new TipoExameConfig());

            base.OnModelCreating(modelBuilder);

        }

    }
}
