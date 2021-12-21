using Desafio.Intelectah.Business.Core.Notificacoes;
using Desafio.Intelectah.Business.Core.Services;
using Desafio.Intelectah.Business.Models.Pacientes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.Pacientes.Services
{
    public class PacienteService : BaseService, IPacienteService
    {

        private readonly IPacienteRepository _pacienteRepository;


        public PacienteService(IPacienteRepository pacienteRepository,
                               INotificador notificador) : base(notificador)
        {
            _pacienteRepository = pacienteRepository;
        }
        public async Task Adicionar(Paciente paciente)
        {
            if (!ExecutarValidacao(new PacienteValidation(), paciente)) return;
            if (await PacienteExistente(paciente)) return;
            await _pacienteRepository.Adicionar(paciente);
        }

        public async Task Atualizar(Paciente paciente)
        {
            if (!ExecutarValidacao(new PacienteValidation(), paciente)) return;
            if (await PacienteExistente(paciente)) return;
            await _pacienteRepository.Atualizar(paciente);
        }



        public async Task Remover(Guid id)
        {
            await _pacienteRepository.Remover(id);
        }


        private async Task<bool> PacienteExistente(Paciente paciente)
        {
            var pacienteAtual = await _pacienteRepository.Buscar(f => f.CpfPaciente == paciente.CpfPaciente);
            if (!pacienteAtual.Any()) return false;

            Notificar("Já existe um paciente com esse CPF informado");

            return true;
        }

        //private async Task<bool> PacienteCadastrado(Paciente paciente)
        //{
        //    var pacienteAtual = await _pacienteRepository.Buscar(f => f.CpfPaciente == paciente.CpfPaciente);
        //    if (!pacienteAtual.Any()) return true;

        //    Notificar("Já existe um paciente com esse CPF informado");

        //    return false;
        //}

        public void Dispose()
        {
            _pacienteRepository?.Dispose();
        }
    }
}
