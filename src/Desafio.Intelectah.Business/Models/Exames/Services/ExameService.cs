using Desafio.Intelectah.Business.Core.Notificacoes;
using Desafio.Intelectah.Business.Core.Services;
using Desafio.Intelectah.Business.Models.Exames.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.Exames.Services
{
    public class ExameService : BaseService, IExameService
    {

        private readonly IExameRepository _exameRepository;

        public ExameService(IExameRepository exameRepository,
                            INotificador notificador) : base(notificador)
        {
            _exameRepository = exameRepository;
        }
        public async Task Adicionar(Exame exame)
        {

            if (!ExecutarValidacao(new ExameValidation(), exame)) return;
            await _exameRepository.Adicionar(exame);

        }

        public async Task Atualizar(Exame exame)
        {
            if (!ExecutarValidacao(new ExameValidation(), exame)) return;
            await _exameRepository.Atualizar(exame);
        }


        public async Task Remover(Guid id)
        {
            await _exameRepository.Remover(id);
        }
        public void Dispose()
        {
            _exameRepository?.Dispose();
        }


    }
}
