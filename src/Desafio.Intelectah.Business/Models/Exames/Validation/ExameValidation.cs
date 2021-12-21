using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.Exames.Validation
{
    public class ExameValidation : AbstractValidator<Exame>
    {

        public ExameValidation()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 100).WithMessage("O campo {PropertyName} precisa estar entre {MinLenght} e {MaxLenght} caracteres");


            RuleFor(e => e.Observacao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 1000).WithMessage("O campo {PropertyName} precisa estar entre {MinLenght} e {MaxLenght} caracteres");



            RuleFor(e => e.TipoExame).NotEmpty().WithMessage("É necessario o Tipo de Exame)");

        }
    }
}
