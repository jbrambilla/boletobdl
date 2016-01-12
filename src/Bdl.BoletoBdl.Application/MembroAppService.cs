using AutoMapper;
using Bdl.BoletoBdl.Application.Interfaces;
using Bdl.BoletoBdl.Application.ViewModels;
using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Interfaces.Services;
using Bdl.BoletoBdl.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Application
{
    public class MembroAppService : ApplicationService, IMembroAppService
    {
        private readonly IMembroService _membroService;

        public MembroAppService(IMembroService membroService, IUnitOfWork uow)
            : base(uow)
        {
            _membroService = membroService;
        }

        public MembroEnderecoViewModel Add(MembroEnderecoViewModel membroEnderecoViewModel)
        {
            var membro = Mapper.Map<MembroEnderecoViewModel, Membro>(membroEnderecoViewModel);
            var endereco = Mapper.Map<MembroEnderecoViewModel, Endereco>(membroEnderecoViewModel);
            var contato = Mapper.Map<MembroEnderecoViewModel, Contato>(membroEnderecoViewModel);

            membro.EnderecoList.Add(endereco);
            membro.ContatoList.Add(contato);

            BeginTransaction();

            var membroReturn = _membroService.Add(membro);
            membroEnderecoViewModel = Mapper.Map<Membro, MembroEnderecoViewModel>(membroReturn);

            if (membroReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            return membroEnderecoViewModel;
        }

        public MembroViewModel GetById(Guid id)
        {
            return Mapper.Map<Membro, MembroViewModel>(_membroService.GetById(id));
        }

        public MembroViewModel GetByCpf(string cpf)
        {
            return Mapper.Map<Membro, MembroViewModel>(_membroService.GetByCpf(cpf));
        }

        public MembroViewModel GetByEmail(string email)
        {
            return Mapper.Map<Membro, MembroViewModel>(_membroService.GetByEmail(email));
        }

        public IEnumerable<MembroViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Membro>, IEnumerable<MembroViewModel>>(_membroService.GetAll());
        }

        public MembroViewModel Update(MembroViewModel membroViewModel)
        {
            BeginTransaction();

            var membroReturn = _membroService.Update(Mapper.Map<MembroViewModel, Membro>(membroViewModel));
            membroViewModel = Mapper.Map<Membro, MembroViewModel>(membroReturn);

            if (membroReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            return membroViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _membroService.Remove(id);
            Commit();
        }

        public EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _membroService.AddEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _membroService.UpdateEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel GetEnderecoById(Guid id)
        {
            return Mapper.Map<Endereco, EnderecoViewModel>(_membroService.GetEnderecoById(id));
        }

        public void RemoveEndereco(Guid id)
        {
            BeginTransaction();
            _membroService.RemoveEndereco(id);
            Commit();
        }

        public ContatoViewModel AddContato(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<ContatoViewModel, Contato>(contatoViewModel);

            BeginTransaction();
            _membroService.AddContato(contato);
            Commit();

            return contatoViewModel;
        }

        public ContatoViewModel UpdateContato(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<ContatoViewModel, Contato>(contatoViewModel);

            BeginTransaction();
            _membroService.UpdateContato(contato);
            Commit();

            return contatoViewModel;
        }

        public ContatoViewModel GetContatoById(Guid id)
        {
            return Mapper.Map<Contato, ContatoViewModel>(_membroService.GetContatoById(id));
        }

        public void RemoveContato(Guid id)
        {
            BeginTransaction();
            _membroService.RemoveContato(id);
            Commit();
        }

        public IEnumerable<GraduacaoViewModel> GetAllGraduacoes()
        {
            return  Mapper.Map<IEnumerable<Graduacao>, IEnumerable<GraduacaoViewModel>>(_membroService.GetAllGraduacoes());
        }

        public IEnumerable<ContatoTipoViewModel> GetAllContatoTipo()
        {
            return Mapper.Map<IEnumerable<ContatoTipo>, IEnumerable<ContatoTipoViewModel>>(_membroService.GetAllContatoTipo());
        }

        public void Dispose()
        {
            _membroService.Dispose();
            GC.SuppressFinalize(this);
        }



    }
}
