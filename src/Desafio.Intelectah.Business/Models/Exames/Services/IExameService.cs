using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.Exames.Services
{
    public interface IExameService : IDisposable
    {

        Task Adicionar(Exame exame);

        Task Atualizar(Exame exame);

        Task Remover(Guid id);

    }
}
