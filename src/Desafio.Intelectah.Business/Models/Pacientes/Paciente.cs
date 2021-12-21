using Desafio.Intelectah.Business.Core.Models;
using Desafio.Intelectah.Business.Models.MarcacoesConsultas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.Pacientes
{
    public class Paciente : Entity
    {
        public string NmPaciente { get; set; }
        public SexoPaciente SexoPaciente { get; set; }
        public string CpfPaciente { get; set; }
        public DateTime DtNascimento { get; set; }

      //  [RegularExpression(@"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/",
       // ErrorMessage = "E-mail em formato inválido.")]
        public string EmailPaciente { get; set; }
        public string ImagemPaciente { get; set; }

       // [RegularExpression(@"^(\+\d{1,2}\s)?((\(\d{3}\))|(\d{3}))[\s.-]\d{3}[\s.-]\d{4}$",
         //   ErrorMessage = "Telefone Inválido")]
        public string TelefonePaciente { get; set; }




        public bool CompararCpf (string cpf, Paciente cpfExistente)
        {


            int cpf2 = Int32.Parse(cpf);
            int cpf3 = Int32.Parse(cpfExistente.CpfPaciente);

            if (cpf2 == cpf3)
            {
                System.Console.WriteLine("Cpf cadastrado no sistema");
                return true;
            }
            return false;
        }

        /* EF Relation */

        public ICollection<MarcacaoConsulta> MarcacaoConsultas { get; set; }
    }
}
