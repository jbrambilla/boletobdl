using AutoMapper;
using Bdl.BoletoBdl.Application.ViewModels;
using Bdl.BoletoBdl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Application.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Membro, MembroViewModel>();
            Mapper.CreateMap<Membro, MembroEnderecoViewModel>();

            Mapper.CreateMap<Endereco, EnderecoViewModel>();
            Mapper.CreateMap<Endereco, MembroEnderecoViewModel>();

            Mapper.CreateMap<Contato, ContatoViewModel>();
            Mapper.CreateMap<Contato, MembroEnderecoViewModel>();

            Mapper.CreateMap<Graduacao, GraduacaoViewModel>();

            Mapper.CreateMap<ContatoTipo, ContatoTipoViewModel>();

        }
    }
}
