using Bdl.BoletoBdl.Application;
using Bdl.BoletoBdl.Application.Interfaces;
using Bdl.BoletoBdl.Domain.Interfaces.Repository;
using Bdl.BoletoBdl.Domain.Interfaces.Services;
using Bdl.BoletoBdl.Domain.Services;
using Bdl.BoletoBdl.Infra.Data.Context;
using Bdl.BoletoBdl.Infra.Data.Interfaces;
using Bdl.BoletoBdl.Infra.Data.Repository;
using Bdl.BoletoBdl.Infra.Data.UoW;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            // APP
            container.Register<IMembroAppService, MembroAppService>(Lifestyle.Scoped);
            container.Register<IGraduacaoAppService, GraduacaoAppService>(Lifestyle.Scoped);
            container.Register<IContatoTipoAppService, ContatoTipoAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IMembroService, MembroService>(Lifestyle.Scoped);
            container.Register<IGraduacaoService, GraduacaoService>(Lifestyle.Scoped);
            container.Register<IContatoTipoService, ContatoTipoService>(Lifestyle.Scoped);

            // Infra Data
            container.Register<IMembroRepository, MembroRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IContatoRepository, ContatoRepository>(Lifestyle.Scoped);
            container.Register<IGraduacaoRepository, GraduacaoRepository>(Lifestyle.Scoped);
            container.Register<IContatoTipoRepository, ContatoTipoRespository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<BoletoBdlContext>(Lifestyle.Scoped);

            //container.Register(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
