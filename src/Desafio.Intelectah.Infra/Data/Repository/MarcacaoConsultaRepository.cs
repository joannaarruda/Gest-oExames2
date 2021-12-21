using Desafio.Intelectah.Business.Models.MarcacoesConsultas;
using Desafio.Intelectah.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Infra.Data.Repository
{
    public class MarcacaoConsultaRepository : Repository<MarcacaoConsulta>, IMarcacaoConsultaRepository
    {
        public MarcacaoConsultaRepository(GestaoExames2Context context) : base(context) { }
        public async Task<MarcacaoConsulta> ObterPacienteExame(Guid id)
        {
            return await Db.MarcacoesConsultas.AsNoTracking()
                .Include(f => f.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MarcacaoConsulta> ObterExame(Guid exameId)
        {
            return await Db.MarcacoesConsultas.AsNoTracking()
                .FirstOrDefaultAsync(e => e.ExameId == exameId);
        }

        public async Task<IEnumerable<MarcacaoConsulta>> ObterPacientesExames()
        {
            return await Db.MarcacoesConsultas.AsNoTracking()
                .Include(f => f.Paciente)
                .OrderBy(m => m.ExameId).ToListAsync();
        }

        public async Task<IEnumerable<MarcacaoConsulta>> ObterPacientesPorExame(Guid pacienteId)
        {
            return await Buscar(m => m.PacienteId == pacienteId);
        }
    }
}
