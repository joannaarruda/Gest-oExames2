using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.TiposExames.Validation
{
    public class TipoExameValidation : AbstractValidator<TipoExame>
    {

        public TipoExameValidation()
        {
            RuleFor(p => p.NmTipoExame)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .Length(3, 100).WithMessage("O campo {PropertyName} precisa estar entre {MinLenght} e {MaxLenght} caracteres");


            RuleFor(p => p.DescricaoTipo)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .Length(3, 100).WithMessage("O campo {PropertyName} precisa estar entre {MinLenght} e {MaxLenght} caracteres");

        }
    }
}
