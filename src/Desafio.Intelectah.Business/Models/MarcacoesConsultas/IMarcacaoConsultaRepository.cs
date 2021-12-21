using Desafio.Intelectah.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.MarcacoesConsultas
{
    public interface IMarcacaoConsultaRepository : IRepository<MarcacaoConsulta>
    {
        Task<IEnumerable<MarcacaoConsulta>> ObterPacientesPorExame(Guid pacienteId);
        Task<IEnumerable<MarcacaoConsulta>> ObterPacientesExames();
        Task<MarcacaoConsulta> ObterPacienteExame(Guid id);

    }
}
