using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Desafio.Intelectah.ViewModels
{
    public class MarcacaoConsultaViewModel
    {

        public MarcacaoConsultaViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [DisplayName("Protocolo de agendamento")]
        [HiddenInput]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Exame")]
        public Guid ExameId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data e Hora do Exame")]
        [ScaffoldColumn(true)]
        public DateTime DataHoraConsulta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Paciente Obrigatório")]
        public Guid PacienteId { get; set; }


        //public PacienteViewModel Paciente { get; set; }
        //public IEnumerable<PacienteViewModel> Pacientes { get; set; }
    }
}