using AutoMapper;
using Desafio.Intelectah.Business.Models.Exames;
using Desafio.Intelectah.Business.Models.MarcacoesConsultas;
using Desafio.Intelectah.Business.Models.Pacientes;
using Desafio.Intelectah.Business.Models.TiposExames;
using Desafio.Intelectah.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Desafio.Intelectah.App_Start
{
    public class AutoMapperConfig
    {

        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Paciente, PacienteViewModel>().ReverseMap();
            CreateMap<MarcacaoConsulta, MarcacaoConsultaViewModel>().ReverseMap();
            CreateMap<TipoExame, TipoExameViewModel>().ReverseMap();
            CreateMap<Exame, ExameViewModel>().ReverseMap();
        }
    }
}