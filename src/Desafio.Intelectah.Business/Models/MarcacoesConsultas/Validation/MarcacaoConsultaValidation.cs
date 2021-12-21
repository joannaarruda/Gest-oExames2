using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.MarcacoesConsultas.Validation
{
    public class MarcacaoConsultaValidation : AbstractValidator<MarcacaoConsulta>
    {

        DateTime dataInformada;
        public MarcacaoConsultaValidation()
        {


            RuleFor(m => m.DataHoraConsulta).Equal(dataInformada).WithMessage("Data e Hora Já informada");

        }
    }
}
