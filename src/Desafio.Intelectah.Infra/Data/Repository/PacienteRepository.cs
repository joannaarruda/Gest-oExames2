using Desafio.Intelectah.Business.Models.Pacientes;
using Desafio.Intelectah.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Infra.Data.Repository
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(GestaoExames2Context context) : base(context) { }

        public async Task<Paciente> ObterPacienteExame(Guid id)
        {
            return await Db.Pacientes.AsNoTracking()
                .Include(f => f.MarcacaoConsultas)
                .FirstOrDefaultAsync(f => f.Id == id);
        }


    }
}
