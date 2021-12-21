using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.Pacientes.Services
{
    public interface IPacienteService : IDisposable
    {
        Task Adicionar(Paciente paciente);

        Task Atualizar(Paciente paciente);

        Task Remover(Guid id);

    }
}
