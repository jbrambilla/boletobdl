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
    class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<MembroViewModel, Membro>();
            Mapper.CreateMap<MembroEnderecoViewModel, Membro>();

            Mapper.CreateMap<EnderecoViewModel, Endereco>();
            Mapper.CreateMap<MembroEnderecoViewModel, Endereco>();

            Mapper.CreateMap<ContatoViewModel, Contato>();
            Mapper.CreateMap<MembroEnderecoViewModel, Contato>();

            Mapper.CreateMap<GraduacaoViewModel, Graduacao>();

            Mapper.CreateMap<ContatoTipoViewModel, ContatoTipo>();
        }
    }
}
