using Desafio.Intelectah.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.Pacientes
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<Paciente> ObterPacienteExame(Guid id);


    }
}
