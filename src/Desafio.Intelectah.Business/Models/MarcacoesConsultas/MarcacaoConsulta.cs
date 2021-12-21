using Desafio.Intelectah.Business.Core.Models;
using Desafio.Intelectah.Business.Models.Exames;
using Desafio.Intelectah.Business.Models.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.MarcacoesConsultas
{
    public class MarcacaoConsulta : Entity
    {
        public Guid PacienteId { get; set; }
        public Guid ExameId { get; set; }
        public DateTime DataHoraConsulta { get; set; }

        /* EF Relation */

        public Paciente Paciente { get; set; }
        public Exame Exame { get; set; }



    }
}
