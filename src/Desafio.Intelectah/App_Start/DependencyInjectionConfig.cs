using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using Desafio.Intelectah.Infra.Data.Context;
using Desafio.Intelectah.Business.Models.Pacientes;
using Desafio.Intelectah.Business.Models.Pacientes.Services;
using Desafio.Intelectah.Business.Models.MarcacoesConsultas;
using Desafio.Intelectah.Business.Models.MarcacoesConsultas.Services;
using Desafio.Intelectah.Business.Models;
using Desafio.Intelectah.Infra.Data.Repository;
using Desafio.Intelectah.Business.Models.Exames;
using Desafio.Intelectah.Business.Models.TiposExames;
using Desafio.Intelectah.Business.Models.Exames.Services;
using Desafio.Intelectah.Business.Core.Notificacoes;
using Desafio.Intelectah.Business.Models.TiposExames.Services;

namespace Desafio.Intelectah.App_Start
{
    public class DependencyInjectionConfig
    {


        public static void RegisterDIContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            // Lifestyle.Singleton
            // Uma única instância por aplicação

            // Lifestyle.Transient
            // Cria uma nova instância para cada injeção

            //Lifestyle.Scoped
            // Uma única instância por request

            container.Register<GestaoExames2Context>(Lifestyle.Scoped);
            container.Register<IPacienteRepository, PacienteRepository>(Lifestyle.Scoped);
            container.Register<IPacienteService, PacienteService>(Lifestyle.Scoped);
            container.Register<IMarcacaoConsultaRepository, MarcacaoConsultaRepository>(Lifestyle.Scoped);
            container.Register<IMarcacaoConsultaService, MarcacaoConsultaService>(Lifestyle.Scoped);
            container.Register<IExameRepository, ExameRepository>(Lifestyle.Scoped);
            container.Register<IExameService, ExameService>(Lifestyle.Scoped);
            container.Register<ITipoExameRepository, TipoExameRepository>(Lifestyle.Scoped);
            container.Register<ITipoExameService, TipoExameService>(Lifestyle.Scoped);
            container.Register<INotificador, Notificador>(Lifestyle.Scoped);

            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance));
        }



    }

}