using Desafio.Intelectah.Business.Models.Exames;
using Desafio.Intelectah.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Infra.Data.Repository
{
    public class ExameRepository : Repository<Exame>, IExameRepository
    {
        public ExameRepository(GestaoExames2Context context) : base(context) { }
        public async Task<Exame> ObterExameTipo(Guid tipoExameId)
        {
            return await ObterPorId(tipoExameId);
        }
    }
}
