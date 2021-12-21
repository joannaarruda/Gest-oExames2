using Desafio.Intelectah.Business.Core.Models;
using Desafio.Intelectah.Business.Models.TiposExames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.Exames
{
    public class Exame : Entity
    {

        public Guid TipoExameId { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        /* EF Relation */
        public ICollection<TipoExame> TipoExames { get; set; }

        public TipoExame TipoExame { get; set; }

    }
}
