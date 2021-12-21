using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.TiposExames.Services
{
    public interface ITipoExameService : IDisposable
    {

        Task Adicionar(TipoExame tipoExame);

        Task Atualizar(TipoExame tipoExame);

        Task Remover(Guid id);
    }

}
