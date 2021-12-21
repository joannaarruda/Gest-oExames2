using Desafio.Intelectah.Business.Models.TiposExames;
using Desafio.Intelectah.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Infra.Data.Repository
{
    public class TipoExameRepository : Repository<TipoExame>, ITipoExameRepository
    {

        public TipoExameRepository(GestaoExames2Context context) : base(context) { }
    }
}
