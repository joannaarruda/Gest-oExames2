using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Intelectah.Business.Models.MarcacoesConsultas.Services
{
    public interface IMarcacaoConsultaService : IDisposable
    {

        Task Adicionar(MarcacaoConsulta marcacaoConsulta);
        Task Atualizar(MarcacaoConsulta marcacaoConsulta);
        Task Remover(Guid id);
    }
}
