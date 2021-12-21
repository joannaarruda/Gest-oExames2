using Desafio.Intelectah.Business.Core.Notificacoes;
using Desafio.Intelectah.Business.Core.Services;
using Desafio.Intelectah.Business.Models.MarcacoesConsultas.Validation;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.MarcacoesConsultas.Services
{
    public class MarcacaoConsultaService : BaseService, IMarcacaoConsultaService
    {

        private readonly IMarcacaoConsultaRepository _marcacaoConsultaRepository;

        public MarcacaoConsultaService(IMarcacaoConsultaRepository marcacaoConsultaRepository,
                                        INotificador notificador) : base(notificador)
        {
            _marcacaoConsultaRepository = marcacaoConsultaRepository;
        }


        public async Task Adicionar(MarcacaoConsulta marcacaoConsulta)
        {
            if (!ExecutarValidacao(new MarcacaoConsultaValidation(), marcacaoConsulta)) return;
            if (await AgendaExistente(marcacaoConsulta)) return;
            await _marcacaoConsultaRepository.Adicionar(marcacaoConsulta);
        }

        public async Task Atualizar(MarcacaoConsulta marcacaoConsulta)
        {
            if (!ExecutarValidacao(new MarcacaoConsultaValidation(), marcacaoConsulta)) return;
            if (await AgendaExistente(marcacaoConsulta)) return;
            await _marcacaoConsultaRepository.Atualizar(marcacaoConsulta);
        }



        private async Task<bool> AgendaExistente(MarcacaoConsulta marcacaoConsulta)
        {
            var marcacaoConsultaAtual = await _marcacaoConsultaRepository.Buscar(m => m.DataHoraConsulta == marcacaoConsulta.DataHoraConsulta && m.Id != marcacaoConsulta.Id && m.PacienteId == marcacaoConsulta.PacienteId);
            if (!marcacaoConsultaAtual.Any()) return false;

            Notificar("Já existe um agendamento para essa Data e Hora Informada");

            return true;
        }

        public async Task Remover(Guid id)
        {
            await _marcacaoConsultaRepository.Remover(id);
        }

        public void Dispose()
        {
            _marcacaoConsultaRepository?.Dispose();
        }

    }
}
