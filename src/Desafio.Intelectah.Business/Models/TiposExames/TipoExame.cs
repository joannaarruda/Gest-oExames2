using Desafio.Intelectah.Business.Core.Models;
using Desafio.Intelectah.Business.Models.Exames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.TiposExames
{
    public class TipoExame : Entity
    {


        public string NmTipoExame { get; set; }
        public string DescricaoTipo { get; set; }


        /* EF Relation */

        public ICollection<Exame> Exames { get; set; }

    }
}
