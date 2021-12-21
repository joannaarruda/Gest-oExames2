using Desafio.Intelectah.Business.Core.Notificacoes;
using Desafio.Intelectah.Business.Core.Services;
using Desafio.Intelectah.Business.Models.TiposExames.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.TiposExames.Services
{
    public class TipoExameService : BaseService, ITipoExameService
    {

        private readonly ITipoExameRepository _tipoExameRepository;


        public TipoExameService(ITipoExameRepository tipoExameRepository,
                               INotificador notificador) : base(notificador)
        {
            _tipoExameRepository = tipoExameRepository;
        }

        public async Task Adicionar(TipoExame tipoExame)
        {
            if (!ExecutarValidacao(new TipoExameValidation(), tipoExame)) return;
            await _tipoExameRepository.Adicionar(tipoExame);
        }

        public async Task Atualizar(TipoExame tipoExame)
        {
            if (!ExecutarValidacao(new TipoExameValidation(), tipoExame)) return;
            await _tipoExameRepository.Atualizar(tipoExame);
        }

        public async Task Remover(Guid id)
        {
            await _tipoExameRepository.Remover(id);
        }


        public void Dispose()
        {
            _tipoExameRepository?.Dispose();
        }
    }
}
