using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.Pacientes.Validation
{
    public class PacienteValidation : AbstractValidator<Paciente>

    {
        
        public PacienteValidation()
        {

          

            RuleFor(f => f.NmPaciente)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 100).WithMessage("O campo {PropertyName} precisa estar entre {MinLenght} e {MaxLenght} caracteres");

            RuleFor(f => f.EmailPaciente).NotEmpty().WithMessage("É necessario informar o e-mail)")
                .EmailAddress().WithMessage("O e-mail terá que ser valido");

            RuleFor(f => f.TelefonePaciente).NotEmpty().WithMessage("É necessário informa {PropertyName}");

           

         //   RuleFor(f => f.CompararCpf).NotNull().WithMessage("É necessário informa {PropertyName}");


        }
    }
}
