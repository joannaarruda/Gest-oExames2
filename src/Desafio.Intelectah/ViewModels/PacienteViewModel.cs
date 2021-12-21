using Desafio.Intelectah.Business.Models.Pacientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Desafio.Intelectah.ViewModels
{
    public class PacienteViewModel
    {
        public PacienteViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }


        [DisplayName("CPF do Paciente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$",
      //  ErrorMessage = "Cpf inválido.")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter 11 caracteres")]
        public string CpfPaciente { get; set; }

        [DisplayName("Nome do Paciente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string NmPaciente { get; set; }

        [DisplayName("Data de nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DtNascimento { get; set; }


        [DisplayName("Sexo")]
        public int SexoPaciente { get; set; }

        [DisplayName("Telefone do Paciente")]
      //  [RegularExpression(@"^(\+\d{1,2}\s)?((\(\d{3}\))|(\d{3}))[\s.-]\d{3}[\s.-]\d{4}$",
      //      ErrorMessage = "Telefone Inválido")]
        public string TelefonePaciente { get; set; }

        [DisplayName("E-mail do Paciente")]
      // [RegularExpression(@"[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,64}",
       //ErrorMessage = "E-mail em formato inválido.")]
        public string EmailPaciente { get; set; }

        [DisplayName("Imagem do Paciente")]
        public HttpPostedFileBase ImagemUpload { get; set; }
        public string ImagemPaciente { get; set; }

        //public bool CompararCpf(string cpf, Paciente cpfExistente)
        //{


        //    int cpf2 = Int32.Parse(cpf);
        //    int cpf3 = Int32.Parse(cpfExistente.CpfPaciente);

        //    if (cpf2 == cpf3)
        //    {
        //        System.Console.WriteLine("Cpf cadastrado no sistema");
        //        return true;
        //    }
        //    return false;
        //}
        public MarcacaoConsultaViewModel MarcacaoConsulta { get; set; }
        public IEnumerable<MarcacaoConsultaViewModel> MarcacaoConsultas { get; set; }




    }
}